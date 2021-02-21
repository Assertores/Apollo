using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Apollo
{
	public class RegisterData : Singleton<RegisterData>
	{
		[SerializeField] ChangeData[] myChangeDatas;
		[SerializeField] AstronautInputTemplateMethod[] myAstronautInputs;

		public AstronautInputTemplateMethod[] GetAstronautInputs {
			get { return myAstronautInputs; } private set { }
		}

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
