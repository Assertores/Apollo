using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_OnValidated_Element", menuName = "Game/AstronautInput/OnValidateDecorator")]
	public class AstronautInputOnValidateDecorator : AstronautInput
	{
		[SerializeField] AstronautInput myRealInput;
		[SerializeField] DataConstraint myValidator;

		public override bool ReactToInput(AstronautInput aInput) {
			if(!myValidator.IsInConstraint()) {
				return false;
			}
			return myRealInput.ReactToInput(aInput);
		}

		public override void OnStartWait() {
			if(!myValidator.IsInConstraint()) {
				return;
			}
			myRealInput.OnStartWait();
		}

		public override void OnStopWait() {
			if(!myValidator.IsInConstraint()) {
				return;
			}
			myRealInput.OnStopWait();
		}

		public override void UpdateData() {
			if(!myValidator.IsInConstraint()) {
				return;
			}
			myRealInput.UpdateData();
		}
	}
}
