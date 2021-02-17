using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class DummyTerminalBuilder : TerminalBuilder
	{
		string myHtmlTemplate;

		public override sealed string GetHtml() {
			return string.Format(myHtmlTemplate, GameState.s_instance.myValues[(int)ValueType.Altitude].value, GameState.s_instance.myButtons[(int)ButtonType.COM].value);
		}

		protected override sealed void OnInit() {
			myHtmlTemplate = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/CapCom.html");
			GameState.s_instance.myValues[(int)ValueType.Altitude].OnValueChange += Update;
			GameState.s_instance.myButtons[(int)ButtonType.COM].OnValueChange += Update;
		}

		void Update() {
			myMissionControl.SendAllUpdate(Terminals.CapCom);
		}
	}
}
