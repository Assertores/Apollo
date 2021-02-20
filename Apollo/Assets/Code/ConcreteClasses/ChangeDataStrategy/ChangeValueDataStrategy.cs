using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataStrategy_Value_Change", menuName = "Game/ChangeDataStrategy/ChangeValue")]
	public sealed class ChangeValueDataStrategy : ChangeDataStrategy
	{
		[SerializeField] ValueType myType;
		[SerializeField] float myValue;
		[SerializeField] bool myAbsolute = true;

		public override void DoChange() {
			if(myAbsolute) {
				GameState.s_instance.myValues[(int)myType].value = myValue;
			} else {
				GameState.s_instance.myValues[(int)myType].value += myValue;
			}
		}
	}
}
