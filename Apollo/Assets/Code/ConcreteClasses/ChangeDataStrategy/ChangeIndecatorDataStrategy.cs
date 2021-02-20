using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataStrategy_Indecator_Change", menuName = "Game/ChangeDataStrategy/ChangeIndecator")]
	public sealed class ChangeIndecatorDataStrategy : ChangeDataStrategy
	{
		[SerializeField] IndecatorType myType;
		[SerializeField] IndecatorState myStrategy;

		public override void DoChange() {
			GameState.s_instance.myIndecators[(int)myType].value = myStrategy;
		}
	}
}
