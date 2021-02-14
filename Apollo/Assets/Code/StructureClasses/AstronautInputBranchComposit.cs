using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class AstronautInputBranchComposit : AstronautInput
	{
		[SerializeField] AstronautInput[] myBranches;

		public override bool Press(Input aInput) {
			foreach(var it in myBranches) {
				if(it.Press(aInput)) {
					return true;
				}
			}
			return false;
		}
	}
}
