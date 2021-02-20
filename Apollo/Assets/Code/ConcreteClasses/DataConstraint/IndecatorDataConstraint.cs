using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_Indecator_State", menuName = "Game/DataConstraint/IndecatorState")]
	public sealed class IndecatorDataConstraint : DataConstraint
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

		public override string ToHtml() {
			var sb = new StringBuilder();
			sb.Append("Indicator: " + myType.ToString());
			if(myStates.Length > 0) {
				if(myNonOfThem) {
					sb.Append("not ");
				}
				sb.Append(myStates[0].ToString());
				for(int i = 1; i < myStates.Length; i++) {
					sb.Append(", " + myStates[i].ToString());
				}
			} else {
				sb.Append("NONE");
			}
			sb.Append(" ");
			return sb.ToString();
		}
	}
}
