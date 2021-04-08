using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class DummyTerminalBuilder : TerminalBuilder
	{
		string myHtmlTemplate;
		Coroutine myCurrentCoroutine = null;

		public override sealed string GetHtml() {
			return string.Format(myHtmlTemplate,
				GameState.s_instance.myAlarm.value,
				GameState.s_instance.myIndecators[(int)IndecatorType.I1].value,
				GameState.s_instance.myIndecators[(int)IndecatorType.I2].value,
				GameState.s_instance.myIndecators[(int)IndecatorType.I3].value,
				GameState.s_instance.myIndecators[(int)IndecatorType.I4].value,
				GameState.s_instance.myIndecators[(int)IndecatorType.I5].value,
				GameState.s_instance.myIndecators[(int)IndecatorType.I6].value);
		}

		protected override sealed void OnInit() {
			myHtmlTemplate = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/CapCom.html");

			GameState.s_instance.myAlarm.OnValueChange += Update;
			GameState.s_instance.myIndecators[(int)IndecatorType.I1].OnValueChange += Update;
			GameState.s_instance.myIndecators[(int)IndecatorType.I2].OnValueChange += Update;
			GameState.s_instance.myIndecators[(int)IndecatorType.I3].OnValueChange += Update;
			GameState.s_instance.myIndecators[(int)IndecatorType.I4].OnValueChange += Update;
			GameState.s_instance.myIndecators[(int)IndecatorType.I5].OnValueChange += Update;
			GameState.s_instance.myIndecators[(int)IndecatorType.I6].OnValueChange += Update;
		}

		void Update() {
			if(myCurrentCoroutine != null) {
				CorountineHolder.s_instance.StopCoroutine(myCurrentCoroutine);
			}
			myCurrentCoroutine = CorountineHolder.s_instance.StartCoroutine(SendDelayedUpdate());
		}

		// NOTE(andreas): bundles multiple changes in one frame together
		IEnumerator SendDelayedUpdate() {
			yield return new WaitForEndOfFrame();
			myMissionControl.SendAllUpdate(Terminals.T1);
		}
	}
}
