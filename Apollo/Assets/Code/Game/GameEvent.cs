using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class GameEvent : ScriptableObject, IInputSubscription
	{
		[SerializeField] AstronautInput mySuccess;
		[SerializeField] AstronautInput myFailiar;

		protected abstract void OnStart();
		protected abstract void OnFinished(bool aSuccessfull);

		public void OnInstanciation() {
			mySuccess.OnStartWait();
			myFailiar.OnStartWait();

			AstronautInputBus.s_instance.AddSubscription(this);
			OnStart();
		}

		public static void OnInstanciation(GameEvent aEvent) {
			if(aEvent == null) {
				return;
			}
			Instantiate(aEvent).OnInstanciation();
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
			AstronautInputBus.s_instance.RemoveSubscription(this);
			mySuccess.OnStopWait();
			myFailiar.OnStopWait();
			Destroy(this);
		}
	}
}
