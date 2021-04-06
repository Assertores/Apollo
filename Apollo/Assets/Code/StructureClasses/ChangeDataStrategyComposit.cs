using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataStrategy_Composit", menuName = "Game/ChangeDataStrategy/Composit")]
	public class ChangeDataStrategyComposit : ChangeDataStrategy
	{
		[Tooltip("redestributes call to all subelements to change multiple states at once")]
		[SerializeField] ChangeDataStrategy[] myStrategys;

		public override void DoChange() {
			foreach(var it in myStrategys) {
				it.DoChange();
			}
		}
	}
}
