using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_Alarm_State", menuName = "Game/DataConstraint/AlarmState")]
	public class AlarmDataConstraint : DataConstraint
	{
		[SerializeField] AlarmState[] myStates;
		[SerializeField] bool myNonOfThem = false;

		public override bool IsInConstraint() {
			var currentState = GameState.s_instance.myAlarm.value;
			foreach(var it in myStates) {
				if(it == currentState) {
					return !myNonOfThem;
				}
			}
			return myNonOfThem;
		}
	}
}
