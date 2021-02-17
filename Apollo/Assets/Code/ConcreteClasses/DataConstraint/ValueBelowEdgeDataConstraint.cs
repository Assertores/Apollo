using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_BelowEdge_Value", menuName = "Game/DataConstraint/ValueBelowEdge")]
	public class ValueBelowEdgeDataConstraint : DataConstraint
	{
		[SerializeField] ValueType myType;
		[SerializeField] float myEdge;

		public override bool IsInConstraint() {
			return GameState.s_instance.myValues[(int)myType].value <= myEdge;
		}
	}
}
