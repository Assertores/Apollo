using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AstronautInput_Const", menuName = "Game/AstronautInput/Const")]
	public class ConstAstronautInput : AstronautInput
	{
		[SerializeField] bool myFixture;

		public override bool Action(AstronautInput aInput) {
			return myFixture;
		}

		public override void OnStartWait() {
		}

		public override void OnStopWait() {
		}

		public override void UpdateData() {
		}
	}
}