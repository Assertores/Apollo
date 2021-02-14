using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint", menuName = "Game/DataConstraint", order = 1)]
	public abstract class DataConstraint : ScriptableObject
	{
		public abstract bool IsInConstraint();
	}
}
