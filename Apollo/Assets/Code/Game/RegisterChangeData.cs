using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class RegisterChangeData : MonoBehaviour
	{
		[SerializeField] ChangeData[] myChangeDatas;
		
		void Start() {
			foreach(var it in myChangeDatas) {
				AstronautInputBus.s_instance.AddSubscription(it);
			}
		}

		void OnDestroy() {
			if(AstronautInputBus.Exists()) {
				foreach(var it in myChangeDatas) {
					AstronautInputBus.s_instance.AddSubscription(it);
				}
			}
		}
	}
}
