using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class TerminalBuilder
	{
		protected MissionControl myMissionControl; // the html server responcable for this Builder

		protected abstract void OnInit(); // if terminal specific stuff hast to be initialiced
		public abstract string GetHtml(); // returns the terminal as html

		public void Init(MissionControl aMissionControl) {
			myMissionControl = aMissionControl;
			OnInit();
		}
	}
}
