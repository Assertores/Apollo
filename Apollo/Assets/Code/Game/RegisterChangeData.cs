using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Apollo
{
	public class RegisterChangeData : Singleton<RegisterChangeData>
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
					AstronautInputBus.s_instance.RemoveSubscription(it);
				}
			}
		}
	}
}
