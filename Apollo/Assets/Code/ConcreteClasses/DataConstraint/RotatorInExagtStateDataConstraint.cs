using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_Rotator_State", menuName = "Game/DataConstraint/RotatorInExagtState")]
	public sealed class RotatorInExagtStateDataConstraint : DataConstraint
	{
		[SerializeField] RotatorTypes myType;
		[SerializeField] int myState;
		[SerializeField] bool myEverythingButThisState = false;

		public override bool IsInConstraint() {
			if(myEverythingButThisState) {
				return GameState.s_instance.myRotators[(int)myType].value != myState;
			}
			return GameState.s_instance.myRotators[(int)myType].value == myState;
		}

		public override string ToHtml() {
			return "<div class='text'>Rotator " + myType + ": " + (myEverythingButThisState ? "not " : "") + myState + "</div>";
		}
	}
}
