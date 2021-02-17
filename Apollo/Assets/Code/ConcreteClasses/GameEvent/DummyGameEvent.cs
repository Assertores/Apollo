using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "GameEvent_Dummy", menuName = "Game/GameEvent/Dummy")]
	public class DummyGameEvent : GameEvent
	{
		protected override void OnFinished(bool aSuccessfull) {
			Debug.Log("you where " + (aSuccessfull ? "" : "not ") + "Successfull");
		}

		protected override void OnStart() {
		}
	}
}
