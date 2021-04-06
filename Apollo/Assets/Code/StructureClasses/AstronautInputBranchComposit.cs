using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Branch_Element", menuName = "Game/AstronautInput/BranchComposit")]
	public class AstronautInputBranchComposit : AstronautInput
	{
		[Tooltip("redestributes the input to all branches. returns true when any branch returns true")]
		[SerializeField] AstronautInput[] myBranches;

		public override bool ReactToInput(AstronautInput aInput) {
			foreach(var it in myBranches) {
				if(it.ReactToInput(aInput)) {
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

		public override void DoReset() {
			foreach(var it in myBranches) {
				it.DoReset();
			}
		}
	}
}
