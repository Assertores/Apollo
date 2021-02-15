using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class TerminalBuilder
	{
		protected MissionControl myMissionControl;

		protected abstract void OnInit();
		public abstract string GetHtml();

		public void Init(MissionControl aMissionControl) {
			myMissionControl = aMissionControl;
			OnInit();
		}
	}
}
