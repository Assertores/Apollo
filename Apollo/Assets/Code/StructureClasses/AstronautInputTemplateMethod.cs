using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class AstronautInputTemplateMethod : AstronautInput, IToHtml
	{
		[Tooltip("the constraint that has to be valide to when this input is invoked")]
		[SerializeField] DataConstraint myConstraint;
		[Tooltip("the gameevent that gets instanciated when the constraint was not fullfiled")]
		[SerializeField] GameEvent myFailerEvent;

		public override void OnStartWait() {
		}

		public override void OnStopWait() {
		}

		public override void DoReset() {
		}

		protected abstract bool AcceptInput(AstronautInput aInput);
		public abstract string ToHtml();

		public override bool ReactToInput(AstronautInput aInput) {
			if(!AcceptInput(aInput)) {
				return false;
			}
			if(!DataConstraint.IsInConstraint(myConstraint)) {
				GameEvent.OnInstanciation(myFailerEvent);
			}
			return true;
		}

		public string GetConstraintHtml() {
			return (myConstraint == null ? "" : myConstraint.ToHtml());
		}
	}
}
