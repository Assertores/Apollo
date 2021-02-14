using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class AstronautInputTemplateMethod : AstronautInput
	{
		[SerializeField] DataConstraint myConstraint;
		[SerializeField] GameEvent myFailerEvent;

		protected abstract bool AcceptInput(AstronautInput aInput);

		public override bool Action(AstronautInput aInput) {
			if(AcceptInput(aInput)) {
				return false;
			}
			if(!myConstraint.IsInConstraint()) {
				var concreteEvent = Instantiate(myFailerEvent);
				concreteEvent.OnInstanciation();
			}
			return true;
		}
	}
}
