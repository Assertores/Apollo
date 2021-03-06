﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class GameEvent : ScriptableObject, IInputSubscription
	{
		[Tooltip("what to do to succeed the event")]
		[SerializeField] AstronautInput mySuccess;
		[Tooltip("what to do to fail the event")]
		[SerializeField] AstronautInput myFailiar;

		protected abstract void OnStart();
		protected abstract void OnFinished(bool aSuccessfull);

		public void OnInstanciation() {
			mySuccess.OnStartWait();
			myFailiar?.OnStartWait();

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
			if(mySuccess.ReactToInput(aInput)) {
				OnFinished(true);
				goto onFinish;
			}
			if(myFailiar && myFailiar.ReactToInput(aInput)) {
				OnFinished(false);
				goto onFinish;
			}
			return;
onFinish:
			AstronautInputBus.s_instance.RemoveSubscription(this);
			mySuccess.OnStopWait();
			myFailiar?.OnStopWait();
			Destroy(this);
		}
	}
}
