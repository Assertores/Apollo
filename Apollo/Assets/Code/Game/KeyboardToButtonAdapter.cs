﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class KeyboardToButtonAdapter : MonoBehaviour
	{
		[SerializeField] AstronautInput my1Down;
		[SerializeField] AstronautInput my1Up;
		[SerializeField] AstronautInput my2Down;
		[SerializeField] AstronautInput my2Up;
		[SerializeField] AstronautInput my3Down;
		[SerializeField] AstronautInput my3Up;
		[SerializeField] AstronautInput my4Down;
		[SerializeField] AstronautInput my4Up;
		[SerializeField] AstronautInput my5Down;
		[SerializeField] AstronautInput my5Up;
		[SerializeField] AstronautInput my6Down;
		[SerializeField] AstronautInput my6Up;


		void Start() {

		}

		// Update is called once per frame
		void Update() {
			if(Input.GetKeyDown(KeyCode.Alpha1)) {
				AstronautInputBus.s_instance.RunInput(my1Down);
			}
			if(Input.GetKeyUp(KeyCode.Alpha1)) {
				AstronautInputBus.s_instance.RunInput(my1Up);
			}
			if(Input.GetKeyDown(KeyCode.Alpha2)) {
				AstronautInputBus.s_instance.RunInput(my2Down);
			}
			if(Input.GetKeyUp(KeyCode.Alpha2)) {
				AstronautInputBus.s_instance.RunInput(my2Up);
			}
			if(Input.GetKeyDown(KeyCode.Alpha3)) {
				AstronautInputBus.s_instance.RunInput(my3Down);
			}
			if(Input.GetKeyUp(KeyCode.Alpha3)) {
				AstronautInputBus.s_instance.RunInput(my3Up);
			}
			if(Input.GetKeyDown(KeyCode.Alpha4)) {
				AstronautInputBus.s_instance.RunInput(my4Down);
			}
			if(Input.GetKeyUp(KeyCode.Alpha4)) {
				AstronautInputBus.s_instance.RunInput(my4Up);
			}
			if(Input.GetKeyDown(KeyCode.Alpha5)) {
				AstronautInputBus.s_instance.RunInput(my5Down);
			}
			if(Input.GetKeyUp(KeyCode.Alpha5)) {
				AstronautInputBus.s_instance.RunInput(my5Up);
			}
			if(Input.GetKeyDown(KeyCode.Alpha6)) {
				AstronautInputBus.s_instance.RunInput(my6Down);
			}
			if(Input.GetKeyUp(KeyCode.Alpha6)) {
				AstronautInputBus.s_instance.RunInput(my6Up);
			}
		}
	}
}
