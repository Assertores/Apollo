﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "ChangeData", menuName = "Game/ChangeData")]
	public class ChangeData : ScriptableObject, IInputSubscription
	{
		[SerializeField] AstronautInput myInputs;
		[SerializeField] ChangeDataStrategy myStrategy;

		public void OnNewInput(AstronautInput aInput) {
			if(!myInputs.ReactToInput(aInput)) {
				return;
			}
			myStrategy.DoChange();
			myInputs.DoReset();
		}
	}
}
