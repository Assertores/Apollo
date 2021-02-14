using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class GameEvent : ScriptableObject
	{
		[SerializeField] AstronautInput mySuccess;
		[SerializeField] AstronautInput myFailiar;

		protected abstract void OnStart();
		protected abstract void OnFinished(bool aSuccessfull);

		public void OnInstanciation() {
			mySuccess.OnStartWait();
			myFailiar.OnStartWait();
			OnStart();
		}

		public void OnNewInput(AstronautInput aInput) {
			if(mySuccess.Action(aInput)) {
				OnFinished(true);
				goto onFinish;
			}
			if(myFailiar.Action(aInput)) {
				OnFinished(false);
				goto onFinish;
			}
			return;
onFinish:
			mySuccess.OnStopWait();
			myFailiar.OnStopWait();
		}
	}
}
