using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_OnValidated_Element", menuName = "Game/AstronautInput/OnValidateDecorator")]
	public class AstronautInputOnValidateDecorator : AstronautInput
	{
		[Tooltip("the actual Input object funktion calls get delegated to if validator succeds")]
		[SerializeField] AstronautInput myRealInput;
		[Tooltip("wether or not the funktion call should be delegated to the real thing")]
		[SerializeField] DataConstraint myValidator;
		bool myLastValidatorValue;

		public override bool ReactToInput(AstronautInput aInput) {
			if(!DoValidation()) {
				return false;
			}
			return myRealInput.ReactToInput(aInput);
		}

		public override void OnStartWait() {
			if(!DoValidation()) {
				return;
			}
			myRealInput.OnStartWait();
		}

		public override void OnStopWait() {
			if(!DoValidation()) {
				return;
			}
			myRealInput.OnStopWait();
		}

		public override void UpdateData() {
			if(!DoValidation()) {
				return;
			}
			myRealInput.UpdateData();
		}

		public override void DoReset() {
			myRealInput.DoReset();
		}

		bool DoValidation() {
			bool validatorValue = myValidator.IsInConstraint();

			if(myLastValidatorValue && !validatorValue) {
				myRealInput.DoReset();
			}

			myLastValidatorValue = validatorValue;
			return validatorValue;
		}
	}
}
