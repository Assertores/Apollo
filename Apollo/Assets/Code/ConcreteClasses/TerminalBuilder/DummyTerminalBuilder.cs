using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class DummyTerminalBuilder : TerminalBuilder
	{
		int myCounter = 23;

		public override sealed string GetHtml() {
			myCounter++;
			return GetStaticBeginning("Dummy") + "test Nr. " + myCounter + GetStaticEnd();
		}

		protected override sealed void OnInit() {
			CorountineHolder.s_instance.StartCoroutine(Dummy());
		}

		IEnumerator Dummy() {
			while(true) {
				yield return new WaitForSeconds(30);

				myMissionControle.SendAllUpdate(Terminals.CapCom);
			}
		}
	}
}
