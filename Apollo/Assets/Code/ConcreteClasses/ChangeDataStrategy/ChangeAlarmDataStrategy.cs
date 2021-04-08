using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataStrategy_Alarm_Change", menuName = "Game/ChangeDataStrategy/ChangeAlarm")]
	public sealed class ChangeAlarmDataStrategy : Command
	{
		[SerializeField] AlarmState myNewState;

		public override void Execute() {
			GameState.s_instance.myAlarm.value = myNewState;
		}
	}
}
