using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "SetButtonStateChangeDataStrategy", menuName = "Game/ChangeDataStrategy/SetButtonState")]
	public class SetButtonStateChangeDataStrategy : ChangeDataStrategy
	{
		[SerializeField] ButtonTypes myType;
		[SerializeField] ButtonState myNewState;

		public override void DoChange() {
			GameState.s_instance.buttons[(int)myType].value = myNewState;
		}
	}
}
