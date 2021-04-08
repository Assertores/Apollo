using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataStrategy_Value_Change", menuName = "Game/ChangeDataStrategy/ChangeValue")]
	public sealed class ChangeValueDataStrategy : Command
	{
		[SerializeField] ValueType myType;
		[SerializeField] float myValue;
		[SerializeField] bool myAbsolute = true;

		public override void Execute() {
			if(myAbsolute) {
				GameState.s_instance.myValues[(int)myType].value = myValue;
			} else {
				GameState.s_instance.myValues[(int)myType].value += myValue;
			}
		}
	}
}
