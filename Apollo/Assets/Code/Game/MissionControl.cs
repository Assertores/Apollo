using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System;
using AsserTOOLres;
using System.Text;

namespace Apollo
{
	public enum Terminals
	{
		T1,
		T2,
		T3,
		T4,
		T5,
		T6,
	}

	// In Desperate Needs of rewriting
	public class MissionControl : Singleton<MissionControl>
	{
		static readonly string LOCALHOST = "http://localhost:";
		static readonly string TERMINATE = "terminate";
		static readonly string UPDATE = "update";

		static readonly IDictionary<string, string> myMimeTypeMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) {
			{ ".asf", "video/x-ms-asf" },
			{ ".asx", "video/x-ms-asf" },
			{ ".avi", "video/x-msvideo" },
			{ ".bin", "application/octet-stream" },
			{ ".cco", "application/x-cocoa" },
			{ ".crt", "application/x-x509-ca-cert" },
			{ ".css", "text/css" },
			{ ".deb", "application/octet-stream" },
			{ ".der", "application/x-x509-ca-cert" },
			{ ".dll", "application/octet-stream" },
			{ ".dmg", "application/octet-stream" },
			{ ".ear", "application/java-archive" },
			{ ".eot", "application/octet-stream" },
			{ ".exe", "application/octet-stream" },
			{ ".flv", "video/x-flv" },
			{ ".gif", "image/gif" },
			{ ".hqx", "application/mac-binhex40" },
			{ ".htc", "text/x-component" },
			{ ".htm", "text/html" },
			{ ".html", "text/html" },
			{ ".ico", "image/x-icon" },
			{ ".img", "application/octet-stream" },
			{ ".svg", "image/svg+xml" },
			{ ".iso", "application/octet-stream" },
			{ ".jar", "application/java-archive" },
			{ ".jardiff", "application/x-java-archive-diff" },
			{ ".jng", "image/x-jng" },
			{ ".jnlp", "application/x-java-jnlp-file" },
			{ ".jpeg", "image/jpeg" },
			{ ".jpg", "image/jpeg" },
			{ ".js", "application/x-javascript" },
			{ ".mml", "text/mathml" },
			{ ".mng", "video/x-mng" },
			{ ".mov", "video/quicktime" },
			{ ".mp3", "audio/mpeg" },
			{ ".mpeg", "video/mpeg" },
			{ ".mp4", "video/mp4" },
			{ ".mpg", "video/mpeg" },
			{ ".msi", "application/octet-stream" },
			{ ".msm", "application/octet-stream" },
			{ ".msp", "application/octet-stream" },
			{ ".pdb", "application/x-pilot" },
			{ ".pdf", "application/pdf" },
			{ ".pem", "application/x-x509-ca-cert" },
			{ ".pl", "application/x-perl" },
			{ ".pm", "application/x-perl" },
			{ ".png", "image/png" },
			{ ".prc", "application/x-pilot" },
			{ ".ra", "audio/x-realaudio" },
			{ ".rar", "application/x-rar-compressed" },
			{ ".rpm", "application/x-redhat-package-manager" },
			{ ".rss", "text/xml" },
			{ ".run", "application/x-makeself" },
			{ ".sea", "application/x-sea" },
			{ ".shtml", "text/html" },
			{ ".sit", "application/x-stuffit" },
			{ ".swf", "application/x-shockwave-flash" },
			{ ".tcl", "application/x-tcl" },
			{ ".tk", "application/x-tcl" },
			{ ".txt", "text/plain" },
			{ ".war", "application/java-archive" },
			{ ".wbmp", "image/vnd.wap.wbmp" },
			{ ".wmv", "video/x-ms-wmv" },
			{ ".xml", "text/xml" },
			{ ".xpi", "application/x-xpinstall" },
			{ ".zip", "application/zip" },
		};

		[Tooltip("the port over with the terminals can join to the game.")]
		[SerializeField] int myPort;
		[System.Serializable]
		class TerminalDictEntry
		{
			[Tooltip("the internals terminal designation")]
			public Terminals myTerminal;
			[Tooltip("the coresponding file the user is send")]
			public string myFile;
		}
		[Tooltip("all available terminals for this game")]
		[SerializeField] List<TerminalDictEntry> myTerminals;
		Dictionary<string, Terminals> myFileToTerminals = new Dictionary<string, Terminals>();
		Dictionary<Terminals, TerminalBuilder> myTerminalToBuilder = new Dictionary<Terminals, TerminalBuilder>();

		Thread myServerThread = null;
		Dictionary<Terminals, List<HttpListenerResponse>> myTerminalRequests = new Dictionary<Terminals, List<HttpListenerResponse>>();

		void Start() {
			foreach(var it in myTerminals) {
				myFileToTerminals["/" + it.myFile] = it.myTerminal;
			}
			myTerminals = null;
			myTerminalToBuilder[Terminals.T1] = new DummyTerminalBuilder();
			myTerminalToBuilder[Terminals.T2] = new OandPTerminalBuilder();
			myTerminalToBuilder[Terminals.T3] = new DummyTerminalBuilder();
			myTerminalToBuilder[Terminals.T4] = new DummyTerminalBuilder();
			myTerminalToBuilder[Terminals.T5] = new DummyTerminalBuilder();
			myTerminalToBuilder[Terminals.T6] = new DummyTerminalBuilder();
			foreach(var it in myTerminalToBuilder) {
				it.Value.Init(this);
			}

			myServerThread = new Thread(ServerThread);
			myServerThread.Start();
		}

		private void OnDestroy() {
			var request = HttpWebRequest.CreateHttp(LOCALHOST + myPort);
			request.Headers.Add(TERMINATE, "true");
			request.GetResponseAsync();
			myServerThread?.Join();
		}

		public void SendAllUpdate(Terminals aTerminal) {
			if(!myTerminalRequests.ContainsKey(aTerminal)) {
				return;
			}
			var terminals = myTerminalRequests[aTerminal];
			myTerminalRequests.Remove(aTerminal);

			
			var content = FromTerminal(aTerminal);
			foreach(var it in terminals) {
				SendUpdate(content, it);
			}
		}

		void ServerThread() {
			var listener = new HttpListener();
			listener.Prefixes.Add("http://*:" + myPort + "/");
			listener.Start();


			while(true) {
				var context = listener.GetContext();
				
				if(context.Request.Headers.Get(TERMINATE) != null) {
					context.Response.StatusCode = (int)HttpStatusCode.Continue;
					context.Response.OutputStream.Flush();
					context.Response.OutputStream.Close();
					break;
				}

				Terminals terminal;
				var exisits = FromFileName(context.Request.Url.LocalPath, out terminal);

				if(!exisits) {
					SendFile(context.Request.Url.LocalPath, context.Response);
					continue;
				}
				if(context.Request.Headers.Get(UPDATE) == null) {
					SendUpdate(FromTerminal(terminal), context.Response);
					continue;
				}

				if(!myTerminalRequests.ContainsKey(terminal)) {
					myTerminalRequests[terminal] = new List<HttpListenerResponse>();
				}
				myTerminalRequests[terminal].Add(context.Response);
			}
			listener.Stop();
		}

		void SendFile(string aFilename, HttpListenerResponse aResponse) {
			aResponse.StatusCode = (int)HttpStatusCode.OK;
			aFilename = Application.streamingAssetsPath + aFilename;

			try {

				Stream input = new FileStream(aFilename, FileMode.Open);

				string mime;
				aResponse.ContentType = myMimeTypeMappings.TryGetValue(Path.GetExtension(aFilename), out mime) ? mime : "application/octet-stream";
				aResponse.ContentLength64 = input.Length;
				aResponse.AddHeader("Date", DateTime.Now.ToString("r"));
				aResponse.AddHeader("Last-Modified", System.IO.File.GetLastWriteTime(aFilename).ToString("r"));

				byte[] buffer = new byte[1024 * 16];
				int nbytes;
				while((nbytes = input.Read(buffer, 0, buffer.Length)) > 0)
					aResponse.OutputStream.Write(buffer, 0, nbytes);
				input.Close();
			} catch(Exception ex) {
				aResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
				print(ex);
			}

			aResponse.OutputStream.Flush();
			aResponse.OutputStream.Close();
		}


		void SendUpdate(string aHtml, HttpListenerResponse aResponse) {

			aResponse.StatusCode = (int)HttpStatusCode.OK;

			try {
				aResponse.ContentType = "text/html";
				aResponse.ContentLength64 = aHtml.Length;
				aResponse.AddHeader("Date", DateTime.Now.ToString("r"));
				aResponse.AddHeader("Last-Modified", System.DateTime.Today.ToString("r"));

				byte[] buffer = UTF8Encoding.Default.GetBytes(aHtml);
				aResponse.OutputStream.Write(buffer, 0, buffer.Length);
			} catch(Exception ex) {
				aResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
				print(ex);
			}

			aResponse.OutputStream.Flush();
			aResponse.OutputStream.Close();
		}

		string FromTerminal(Terminals aTerminal) {
			return myTerminalToBuilder[aTerminal].GetHtml();
		}

		bool FromFileName(string aFile, out Terminals aTerminal) {
			if(!myFileToTerminals.ContainsKey(aFile)) {
				aTerminal = Terminals.T1;
				return false;
			}
			aTerminal = myFileToTerminals[aFile];
			return true;
		}
	}
}
