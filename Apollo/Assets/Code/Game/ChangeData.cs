using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "ChangeData", menuName = "Game/ChangeData")]
	public class ChangeData : ScriptableObject, IInputSubscription
	{
		[SerializeField] DataConstraint myConstraints;
		[SerializeField] ChangeDataStrategy myStrategy;
		bool myIsReset = true;
		
		public void OnNewInput(AstronautInput aInput) {
			if(!myConstraints.IsInConstraint()) {
				myIsReset = true;
				return;
			}
			if(!myIsReset) {
				return;
			}
			myIsReset = false;
			myStrategy.DoChange();
		}
	}
}
