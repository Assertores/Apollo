using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Sequence_Element", menuName = "Game/AstronautInput/SequenceComposit")]
	public class AstronautInputSequenceComposit : AstronautInput
	{
		[Tooltip("this inputs have to be invoced in sequence. moves on if current returns true. returns true if last element returns true")]
		[SerializeField] AstronautInput[] mySequence;
		int myCurrentIndex = 0;

		public override bool ReactToInput(AstronautInput aInput) {
			if(!mySequence[myCurrentIndex].ReactToInput(aInput)) {
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
			mySequence[myCurrentIndex].OnStopWait();
			myCurrentIndex = 0;
		}

		public override void UpdateData() {
		}

		public override void DoReset() {
			foreach(var it in mySequence) {
				it.DoReset();
			}

			myCurrentIndex = 0;
		}
	}
}
