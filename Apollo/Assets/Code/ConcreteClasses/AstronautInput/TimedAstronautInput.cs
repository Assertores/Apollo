using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Timed", menuName = "Game/AstronautInput/Timed")]
	public sealed class TimedAstronautInput : AstronautInput
	{
		[SerializeField] float myDelayInSeconds;
		Coroutine myCoroutine = null;
		AstronautInput myInstance = null;

		protected void OnStart() { }
		protected void OnEnd() { }

		public override sealed bool Action(AstronautInput aInput) {
			return aInput == myInstance;
		}

		public override sealed void OnStartWait() {
			myCoroutine = CorountineHolder.s_instance.StartCoroutine(DelayRunInput(myDelayInSeconds));
			OnStart();
		}

		public override sealed void OnStopWait() {
			CorountineHolder.s_instance.StopCoroutine(myCoroutine);
			OnEnd();
		}

		IEnumerator DelayRunInput(float aDelayInSeconds) {
			yield return new WaitForSeconds(aDelayInSeconds);
			myInstance = new TimedAstronautInput();
			AstronautInputBus.s_instance.RunInput(myInstance);
		}

		public override void UpdateData() {
		}
	}
}
