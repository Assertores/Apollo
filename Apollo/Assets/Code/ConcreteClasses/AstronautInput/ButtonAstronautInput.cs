using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "ButtonAstronautInput", menuName = "Game/AstronautInput/Button")]
	public class ButtonAstronautInput : AstronautInputTemplateMethod
	{
		[SerializeField] ButtonTypes myType;
		[SerializeField] ButtonState myState;

		public override void OnStartWait() {
		}

		public override void OnStopWait() {
		}

		protected override bool AcceptInput(AstronautInput aInput) {
			return aInput == this;
		}
	}
}
