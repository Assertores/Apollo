using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "GameEvent_Dummy", menuName = "Game/GameEvent/Dummy")]
	public class DummyGameEvent : GameEvent
	{
		protected override void OnFinished(bool aSuccessfull) {
			Debug.Log("you where " + (aSuccessfull ? "" : "not ") + "Successfull for event " + name);
		}

		protected override void OnStart() {
			Debug.Log("GameEvent " + name + "has started");
		}
	}
}
