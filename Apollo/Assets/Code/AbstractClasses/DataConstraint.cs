using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class DataConstraint : ScriptableObject
	{
		public abstract bool IsInConstraint();
		public static bool IsInConstraint(DataConstraint aConstraint) {
			if(aConstraint == null) {
				return true;
			}
			return aConstraint.IsInConstraint();
		}
	}
}
