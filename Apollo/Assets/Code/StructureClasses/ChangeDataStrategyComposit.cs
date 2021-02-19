using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataStrategy_Composit", menuName = "Game/ChangeDataStrategy/Composit")]
	public class ChangeDataStrategyComposit : ChangeDataStrategy
	{
		[SerializeField] ChangeDataStrategy[] myStrategys;

		public override void DoChange() {
			foreach(var it in myStrategys) {
				it.DoChange();
			}
		}
	}
}
