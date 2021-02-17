using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInputBranchComposit", menuName = "Game/AstronautInput/BranchComposit")]
	public class AstronautInputBranchComposit : AstronautInput
	{
		[SerializeField] AstronautInput[] myBranches;

		public override bool Action(AstronautInput aInput) {
			foreach(var it in myBranches) {
				if(it.Action(aInput)) {
					return true;
				}
			}
			return false;
		}

		public override void OnStartWait() {
			foreach(var it in myBranches) {
				it.OnStartWait();
			}
		}

		public override void OnStopWait() {
			foreach(var it in myBranches) {
				it.OnStopWait();
			}
		}

		public override void UpdateData() {
		}
	}
}
