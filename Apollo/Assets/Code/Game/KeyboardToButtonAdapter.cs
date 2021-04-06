using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class KeyboardToButtonAdapter : MonoBehaviour
	{
		[Tooltip("the astronaut input invoked if the button 1 is pressed down on the keyboard")]
		[SerializeField] AstronautInput my1Down;
		[Tooltip("the astronaut input invoked if the button 1 is released on the keyboard")]
		[SerializeField] AstronautInput my1Up;
		[Tooltip("the astronaut input invoked if the button 2 is pressed down on the keyboard")]
		[SerializeField] AstronautInput my2Down;
		[Tooltip("the astronaut input invoked if the button 2 is released on the keyboard")]
		[SerializeField] AstronautInput my2Up;
		[Tooltip("the astronaut input invoked if the button 3 is pressed down on the keyboard")]
		[SerializeField] AstronautInput my3Down;
		[Tooltip("the astronaut input invoked if the button 3 is released on the keyboard")]
		[SerializeField] AstronautInput my3Up;
		[Tooltip("the astronaut input invoked if the button 4 is pressed down on the keyboard")]
		[SerializeField] AstronautInput my4Down;
		[Tooltip("the astronaut input invoked if the button 4 is released on the keyboard")]
		[SerializeField] AstronautInput my4Up;
		[Tooltip("the astronaut input invoked if the button 5 is pressed down on the keyboard")]
		[SerializeField] AstronautInput my5Down;
		[Tooltip("the astronaut input invoked if the button 5 is released on the keyboard")]
		[SerializeField] AstronautInput my5Up;
		[Tooltip("the astronaut input invoked if the button 6 is pressed down on the keyboard")]
		[SerializeField] AstronautInput my6Down;
		[Tooltip("the astronaut input invoked if the button 6 is released on the keyboard")]
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
