using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class DataConstraint : ScriptableObject
	{
		public abstract bool IsInConstraint();
	}
}
