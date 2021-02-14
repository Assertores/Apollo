﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class AstronautInput : ScriptableObject
	{
		public abstract void OnStartWait();
		public abstract void OnStopWait();
		public abstract bool Action(AstronautInput aInput);
	}
}
