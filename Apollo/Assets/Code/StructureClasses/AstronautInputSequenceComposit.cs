using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class AstronautInputSequenceComposit : AstronautInput
	{
		[SerializeField] AstronautInput[] mySequence;
		int myCurrentIndex = 0;

		public override bool Press(Input aInput) {
			if(!mySequence[myCurrentIndex].Press(aInput)) {
				return false;
			}
			myCurrentIndex++;
			if(myCurrentIndex >= mySequence.Length) {
				return true;
			}
			return false;
		}
	}
}
