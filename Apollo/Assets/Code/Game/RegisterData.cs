using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Apollo
{
	public class RegisterData : Singleton<RegisterData>
	{
		[Tooltip("this are all the ways how the astronaut can change the state of the system")]
		[SerializeField] ChangeData[] myChangeDatas;
		[Tooltip("this is to collect all the input conditions to show on one of the the terminals")]
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
