using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "ValueAboveEdgeDataConstraint", menuName = "Game/DataConstraint/ValueAboveEdge")]
	public class ValueAboveEdgeDataConstraint : DataConstraint
	{
		[SerializeField] ValueTypes myType;
		[SerializeField] float myEdge;

		public override bool IsInConstraint() {
			return GameState.s_instance.values[(int)myType].value >= myEdge;
		}
	}
}
