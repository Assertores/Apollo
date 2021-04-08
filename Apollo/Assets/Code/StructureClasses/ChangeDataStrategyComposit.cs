using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataStrategy_Composit", menuName = "Game/ChangeDataStrategy/Composit")]
	public class ChangeDataStrategyComposit : Command
	{
		[Tooltip("redestributes call to all subelements to change multiple states at once")]
		[SerializeField] Command[] myStrategys;

		public override void Execute() {
			foreach(var it in myStrategys) {
				it.Execute();
			}
		}
	}
}
