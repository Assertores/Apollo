using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_Button_State", menuName = "Game/DataConstraint/Button")]
	public sealed class ButtonDataConstraint : DataConstraint
	{
		[SerializeField] ButtonType myType;
		[SerializeField] ButtonState myState;

		public override bool IsInConstraint() {
			return GameState.s_instance.myButtons[(int)myType].value == myState;
		}

		public override string ToHtml() {
			return "Button " + myType + ": " + myState + " ";
		}
	}
}
