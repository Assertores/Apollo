using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class AstronautButton : MonoBehaviour
	{
		[Tooltip("the actual Button whitch travels")]
		[SerializeField] Rigidbody myButtonObject;
		[Tooltip("at this depth the the button is considert as pressed")]
		[SerializeField] GameObject myActiveDempth;
		[Tooltip("this command gets executed when the button is pressed")]
		[SerializeField] Command myOnPressed;
		[Tooltip("this command gets executed when the button is released")]
		[SerializeField] Command myOnReleased;

		[Tooltip("the force with witch the button presses against the hand")]
		[SerializeField] float myForce;
		[Tooltip("wether the button should stay pressed and has to be pressed again to release or not")]
		[SerializeField] bool myStayPressed = false;

		float myMaxDistance;
		float myActivateDistance;
		enum State
		{
			Released,
			ReadyToBePressed,
			Pressed,
			ReadyToBeReleased,
		}
		State myState = State.Released;

		private void Start() {
			myMaxDistance = -myButtonObject.transform.localPosition.z;
			myActivateDistance = -myActiveDempth.transform.localPosition.z;
			myButtonObject.constraints = RigidbodyConstraints.FreezeRotation;
		}

		private void Update() {
			myButtonObject.transform.localPosition = Vector3.forward * myButtonObject.transform.localPosition.z;
			var dist = -myButtonObject.transform.localPosition.z;

			switch(myState) {
			case State.Released:
				if(dist < myActivateDistance) {
					myOnPressed?.Execute();
					myState = myStayPressed ? State.ReadyToBePressed : State.Pressed;
				}
				break;
			case State.ReadyToBePressed:
				break;
			case State.Pressed:
				break;
			case State.ReadyToBeReleased:
				if(dist > myActivateDistance) {
					myOnReleased?.Execute();
					myState = State.Released;
				}
				break;
			default:
				throw new System.InvalidCastException(myState.ToString());
			}
		}

		private void FixedUpdate() {
			myButtonObject.velocity = Vector3.zero;
			myButtonObject.AddRelativeForce(-transform.forward * myForce, ForceMode.Force);

			var dist = -myButtonObject.transform.localPosition.z;
			var max = myStayPressed && (myState == State.ReadyToBePressed || myState == State.Pressed) ? myActivateDistance : myMaxDistance;
			if(dist > max) {
				myButtonObject.transform.localPosition = Vector3.forward * -max;
				if(myState == State.ReadyToBePressed) {
					myState = State.Pressed;
				}
				return;
			}
			if(myState == State.Pressed) {
				myState = State.ReadyToBeReleased;
			}
			if(dist < 0) {
				myButtonObject.transform.localPosition = Vector3.zero;
			}
		}
	}
}
