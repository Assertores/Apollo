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
		[Tooltip("in with state this constraint is valide")]
		[SerializeField] IndecatorState[] myStates;
		[Tooltip("if this bool is set the coresponding indecator is not alowed to be in the states given in the array above")]
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
			sb.Append("<div class='text'>Indicator " + myType.ToString() + ": ");
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
			sb.Append("</div>");
			return sb.ToString();
		}
	}
}
