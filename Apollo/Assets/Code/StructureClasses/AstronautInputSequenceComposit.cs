using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Sequence_Element", menuName = "Game/AstronautInput/SequenceComposit")]
	public class AstronautInputSequenceComposit : AstronautInput
	{
		[SerializeField] AstronautInput[] mySequence;
		int myCurrentIndex = 0;

		public override bool Action(AstronautInput aInput) {
			if(!mySequence[myCurrentIndex].Action(aInput)) {
				return false;
			}
			OnStopWait();
			myCurrentIndex++;
			if(myCurrentIndex >= mySequence.Length) {
				return true;
			}
			OnStartWait();
			return false;
		}

		public override void OnStartWait() {
			mySequence[myCurrentIndex].OnStartWait();
		}

		public override void OnStopWait() {
			myCurrentIndex = 0;
			mySequence[myCurrentIndex].OnStopWait();
		}

		public override void UpdateData() {
		}
	}
}
