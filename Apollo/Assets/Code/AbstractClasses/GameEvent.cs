using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "GameEvent", menuName = "Game/GameEvent", order = 1)]
	public abstract class GameEvent : ScriptableObject
	{
		[SerializeField] AstronautInput mySuccess;
		[SerializeField] AstronautInput myFailiar;

		public abstract void OnInstanciation();
	}
}
