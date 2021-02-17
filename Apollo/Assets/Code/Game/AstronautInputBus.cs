using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Apollo
{
	public class AstronautInputBus : Singleton<AstronautInputBus>
	{
		System.Action<AstronautInput> mySubscriptions;

		public void AddSubscription(IInputSubscription aSub) {
			mySubscriptions += aSub.OnNewInput;
		}

		public void RemoveSubscription(IInputSubscription aSub) {
			mySubscriptions -= aSub.OnNewInput;
		}

		public void RunInput(AstronautInput aInput) {
			aInput.UpdateData();
			mySubscriptions?.Invoke(aInput);
		}
	}
}
