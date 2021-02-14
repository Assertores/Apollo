using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo {
	public class DataConstraintBranchComposit : DataConstraint
	{
		[SerializeField] DataConstraint[] myBranches;

		public override bool IsInConstraint() {
			foreach(var it in myBranches) {
				if(it.IsInConstraint()) {
					return true;
				}
			}
			return false;
		}
	}
}
