using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class DummyTerminalBuilder : TerminalBuilder
	{
		string myHtmlTemplate;

		public override sealed string GetHtml() {
			return string.Format(myHtmlTemplate, GameState.s_instance.values[(int)ValueTypes.Altitude].value, GameState.s_instance.buttons[(int)ButtonTypes.COM].value);
		}

		protected override sealed void OnInit() {
			myHtmlTemplate = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/CapCom.html");
			GameState.s_instance.values[(int)ValueTypes.Altitude].OnValueChange += Update;
			GameState.s_instance.buttons[(int)ButtonTypes.COM].OnValueChange += Update;
		}

		void Update() {
			myMissionControl.SendAllUpdate(Terminals.CapCom);
		}
	}
}
