using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraintSequenceComposit", menuName = "Game/DataConstraintSequenceComposit")]
	public class DataConstraintSequenceComposit : DataConstraint
	{
		[SerializeField] DataConstraint[] mySequence;

		public override bool IsInConstraint() {
			foreach(var it in mySequence) {
				if(!it.IsInConstraint()) {
					return false;
				}
			}
			return true;
		}
	}
}
