using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "ChangeData", menuName = "Game/ChangeData")]
	public class ChangeData : ScriptableObject, IInputSubscription
	{
		[SerializeField] AstronautInput myInput;
		[SerializeField] ChangeDataStrategy myStrategy;

		public void Start() {
			myInput.OnStartWait();
		}

		public void Stop() {
			myInput.OnStopWait();
		}

		public void OnNewInput(AstronautInput aInput) {
			if(!myInput.Action(aInput)) {
				return;
			}
			myStrategy.DoChange();
		}
	}
}
