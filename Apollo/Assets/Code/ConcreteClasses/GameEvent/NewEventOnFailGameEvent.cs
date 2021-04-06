using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class NewEventOnFailGameEvent : GameEvent
	{
		[Tooltip("the way this game event makes it self known to the players")]
		[SerializeField] ChangeDataStrategy myStartDataChange;
		[Tooltip("the effect this event has on the system if it succeads")]
		[SerializeField] ChangeDataStrategy mySuccessDataChange;
		[Tooltip("the effect this event has on the system if it fails")]
		[SerializeField] ChangeDataStrategy myFailiarDataChange;
		[Tooltip("gets triggered if this event failes")]
		[SerializeField] GameEvent myFailiarEvent;

		protected override void OnStart() {
			myStartDataChange?.DoChange();
		}

		protected override void OnFinished(bool aSuccessfull) {
			if(aSuccessfull) {
				myStartDataChange?.DoChange();
			} else {
				myFailiarDataChange?.DoChange();
				OnInstanciation(myFailiarEvent);
			}
		}
	}
}
