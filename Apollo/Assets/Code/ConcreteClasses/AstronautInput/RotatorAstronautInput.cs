using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Rotator", menuName = "Game/AstronautInput/Rotator")]
	public class RotatorAstronautInput : AstronautInputTemplateMethod
	{
		[SerializeField] RotatorTypes myType;
		[SerializeField] int myValue;
		[SerializeField] bool myAbsolute = true;

		public override void UpdateData() {
			if(myAbsolute) {
				GameState.s_instance.myRotators[(int)myType].value = myValue;
			} else {
				GameState.s_instance.myRotators[(int)myType].value += myValue;
			}
		}

		protected override bool AcceptInput(AstronautInput aInput) {
			return aInput == this;
		}
	}
}
