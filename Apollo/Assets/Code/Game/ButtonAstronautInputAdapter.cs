using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class ButtonAstronautInputAdapter : MonoBehaviour
	{
		[SerializeField] AstronautInput myAstronaitInput;

		public void Execute() {
			AstronautInputBus.s_instance.RunInput(myAstronaitInput);
		}
	}
}
