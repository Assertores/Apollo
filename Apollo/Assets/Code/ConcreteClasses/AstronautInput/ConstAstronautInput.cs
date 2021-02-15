using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "ConstAstronautInput", menuName = "Game/AstronautInput/Const")]
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
	}
}