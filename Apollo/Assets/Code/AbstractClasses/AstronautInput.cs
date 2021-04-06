using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class AstronautInput : ScriptableObject
	{
		public abstract void OnStartWait(); // is called as soon as this Input is the next one the Astronaut has to input
		public abstract void OnStopWait(); // is called whenever we stop waiting for this input e.g. the system was reset or this input was invoced
		public abstract void UpdateData(); // update the system data interface (and therefore invoce all observers)
		public abstract void DoReset(); // resets everything
		public abstract bool ReactToInput(AstronautInput aInput); // gets the invoced input and desigeds wether or not it hast to do something.
	}
}
