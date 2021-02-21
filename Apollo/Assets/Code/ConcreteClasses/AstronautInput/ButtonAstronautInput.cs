using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Button", menuName = "Game/AstronautInput/Button")]
	public sealed class ButtonAstronautInput : AstronautInputTemplateMethod
	{
		[SerializeField] ButtonType myType;
		[SerializeField] ButtonState myState;

		public override string ToHtml() {
			return "<div class='text'>" + myType.ToString() + ": " + myState.ToString() + "</div>";
		}

		public override void UpdateData() {
			GameState.s_instance.myButtons[(int)myType].value = myState;
		}

		protected override bool AcceptInput(AstronautInput aInput) {
			return aInput == this;
		}
	}
}
