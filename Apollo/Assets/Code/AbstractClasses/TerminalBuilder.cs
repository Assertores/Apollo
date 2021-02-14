using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class TerminalBuilder
	{
		protected MissionControle myMissionControle;

		protected abstract void OnInit();
		public abstract string GetHtml();

		public void Init(MissionControle aMissionControle) {
			myMissionControle = aMissionControle;
			OnInit();
		}

		protected static string GetStaticBeginning(string title) {
			//return "<!doctype html><html lang = \"en\"><head><meta charset = \"utf-8\"><title>" + title + "</title><link rel = \"stylesheet\" href = \"css/styles.css?v=1.0\"><script src = \"js/scripts.js\" ></script></head><body>";
			return "<!doctype html><html lang = \"en\"><head><meta charset = \"utf-8\"><title>" + title + "</title><link rel = \"stylesheet\" href = \"css/styles.css?v=1.0\"><script src = \"js/scripts.js\" ></script></head><body onload=\"sendUpdateRequest()\">";
		}

		protected static string GetStaticEnd() {
			return "</body></html>";
		}
	}
}
