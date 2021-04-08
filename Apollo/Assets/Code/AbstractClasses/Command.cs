using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class Command : ScriptableObject
	{
		public abstract void Execute();
	}
}
