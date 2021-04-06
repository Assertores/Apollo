using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Const", menuName = "Game/AstronautInput/Const")]
	public sealed class ConstAstronautInput : AstronautInput
	{
		[Tooltip("the constant value it should return")]
		[SerializeField] bool myFixture;

		public override bool ReactToInput(AstronautInput aInput) {
			return myFixture;
		}

		public override void OnStartWait() {
		}

		public override void OnStopWait() {
		}

		public override void UpdateData() {
		}

		public override void DoReset() {
		}
	}
}