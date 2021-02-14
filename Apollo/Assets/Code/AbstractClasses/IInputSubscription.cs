using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public interface IInputSubscription
	{
		void OnNewInput(AstronautInput aInput);
	}
}
