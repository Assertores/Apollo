using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Value", menuName = "Game/AstronautInput/Value")]
	public class ValueAstronautInput : AstronautInputTemplateMethod
	{
		[SerializeField] ValueType myType;
		[SerializeField] float myValue;
		[SerializeField] bool myAbsolute = true;

		public override void UpdateData() {
			if(myAbsolute) {
				GameState.s_instance.myValues[(int)myType].value = myValue;
			} else {
				GameState.s_instance.myValues[(int)myType].value += myValue;
			}
		}

		protected override bool AcceptInput(AstronautInput aInput) {
			return aInput == this;
		}
	}
}
