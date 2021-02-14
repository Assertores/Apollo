using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public abstract class ChangeDataStrategy : ScriptableObject
	{
		public abstract void DoChange();
	}
}
