using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput", menuName = "Game/AstronautInput", order = 1)]
	public abstract class AstronautInput : ScriptableObject
	{
		[SerializeField] DataConstraint myConstraint;
		[SerializeField] GameEvent myFailerEvent;

		public abstract bool Press(Input aInput);
	}
}