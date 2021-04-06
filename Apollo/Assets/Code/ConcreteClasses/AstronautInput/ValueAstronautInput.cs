using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Value", menuName = "Game/AstronautInput/Value")]
	public sealed class ValueAstronautInput : AstronautInputTemplateMethod
	{
		[SerializeField] ValueType myType;
		[SerializeField] float myValue;
		[Tooltip("wether or not the value is a absolut value or a relative one")]
		[SerializeField] bool myAbsolute = true;

		public override string ToHtml() {
			return "<div class='text'>" + myType.ToString() + (myAbsolute ? "Abs: " : "Rel: ") + myValue.ToString() + "</div>";
		}

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
