using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class AstronautInputTemplateMethod : AstronautInput
	{
		[SerializeField] DataConstraint myConstraint;
		[SerializeField] GameEvent myFailerEvent;

		public override void OnStartWait() {
		}

		public override void OnStopWait() {
		}

		protected abstract bool AcceptInput(AstronautInput aInput);

		public override bool Action(AstronautInput aInput) {
			if(!AcceptInput(aInput)) {
				return false;
			}
			if(!DataConstraint.IsInConstraint(myConstraint)) {
				GameEvent.OnInstanciation(myFailerEvent);
			}
			return true;
		}
	}
}
