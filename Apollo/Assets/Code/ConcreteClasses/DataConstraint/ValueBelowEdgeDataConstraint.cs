﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "ValueBelowEdgeDataConstraint", menuName = "Game/DataConstraint/ValueBelowEdge")]
	public class ValueBelowEdgeDataConstraint : DataConstraint
	{
		[SerializeField] ValueTypes myType;
		[SerializeField] float myEdge;

		public override bool IsInConstraint() {
			return GameState.s_instance.values[(int)myType].value <= myEdge;
		}
	}
}
