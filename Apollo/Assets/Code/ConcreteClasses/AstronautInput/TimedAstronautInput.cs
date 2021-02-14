using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "TimedAstronautInput", menuName = "Game/AstronautInput/Timed")]
	public class TimedAstronautInput : AstronautInput
	{
		[SerializeField] float myDelayInSeconds;
		Coroutine myCoroutine = null;

		protected void OnStart() { }
		protected void OnEnd() { }

		public override sealed bool Action(AstronautInput aInput) {
			return aInput == this;
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
			AstronautInputBus.s_instance.RunInput(this);
		}
	}
}
