using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Apollo
{
	public class OandPTerminalBuilder : TerminalBuilder
	{
		string myHtmlTemplate;

		public override string GetHtml() {
			var sb = new StringBuilder();

			var inputs = RegisterData.s_instance.GetAstronautInputs;
			sb.Append("<table><tr><th>Input</th><th>Condition</th><tr>");
			foreach(var it in inputs) {
				sb.Append("<tr><td>" + it.ToHtml() + "</td><td>" + it.GetConstraintHtml() + "</td></tr>");
			}
			sb.Append("</table>");

			return string.Format(myHtmlTemplate, sb.ToString());
		}

		protected override void OnInit() {
			myHtmlTemplate = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/O&P.html");
		}
	}
}
