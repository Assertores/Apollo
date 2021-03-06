﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_AboveEdge_Value", menuName = "Game/DataConstraint/ValueAboveEdge")]
	public sealed class ValueAboveEdgeDataConstraint : DataConstraint
	{
		[SerializeField] ValueType myType;
		[SerializeField] float myEdge;

		public override bool IsInConstraint() {
			return GameState.s_instance.myValues[(int)myType].value >= myEdge;
		}

		public override string ToHtml() {
			return "<div class='text'>" + myEdge.ToString() + " &lt " + myType.ToString() + "</div>";
		}
	}
}
