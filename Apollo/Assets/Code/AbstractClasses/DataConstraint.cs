using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class DataConstraint : ScriptableObject, IToHtml
	{
		public abstract bool IsInConstraint(); // checks wether or not this constraint object is valid against the systems data
		public static bool IsInConstraint(DataConstraint aConstraint) { // this version accepts a null object as being compliant
			if(aConstraint == null) {
				return true;
			}
			return aConstraint.IsInConstraint();
		}

		public abstract string ToHtml();
	}
}
