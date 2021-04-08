using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "AIAdapts_Element", menuName = "Game/AstronautInput/Adapter")]
	public class AstronautInputAdapter : Command
	{
		[Tooltip("the Astronaut Input that gets Run when this command runs")]
		[SerializeField] AstronautInput myInput;

		public override void Execute() {
			AstronautInputBus.s_instance.RunInput(myInput);
		}
	}
}
