using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Apollo
{
	public class AstronautInputBus : Singleton<AstronautInputBus>
	{
		List<IInputSubscription> mySubscriptions;

		public void AddSubscription(IInputSubscription aSub) {
			mySubscriptions.Add(aSub);
		}

		public void RemoveSubscription(IInputSubscription aSub) {
			mySubscriptions.Remove(aSub);
		}

		public void RunInput(AstronautInput aInput) {
			foreach(var it in mySubscriptions) {
				it.OnNewInput(aInput);
			}
		}
	}
}
