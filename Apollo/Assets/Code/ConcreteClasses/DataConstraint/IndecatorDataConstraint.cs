using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_Indecator_State", menuName = "Game/DataConstraint/IndecatorState")]
	public class IndecatorDataConstraint : DataConstraint
	{
		[SerializeField] IndecatorType myType;
		[SerializeField] IndecatorState[] myStates;
		[SerializeField] bool myNonOfThem = false;

		public override bool IsInConstraint() {
			var currentState = GameState.s_instance.myIndecators[(int)myType].value;
			foreach(var it in myStates) {
				if(it == currentState) {
					return !myNonOfThem;
				}
			}
			return myNonOfThem;
		}
	}
}
