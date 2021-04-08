using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apollo
{
	public class AstronautToggleSwitch : MonoBehaviour
	{
		[Tooltip("the actual Button whitch travels")]
		[SerializeField] Rigidbody mySwitchObject;
		[Tooltip("this command gets executed when the button is pressed")]
		[SerializeField] Command myOnActivated;
		[Tooltip("this command gets executed when the button is released")]
		[SerializeField] Command myOnDeactivated;

		[Tooltip("the force with witch the button presses against the hand")]
		[SerializeField] float myForce;

		float myMaxAngle;
		bool myIsActivated = false;

		void Start() {
			myMaxAngle = mySwitchObject.transform.localEulerAngles.x;
			mySwitchObject.constraints = RigidbodyConstraints.FreezePosition;
		}
		
		void Update() {
			mySwitchObject.transform.localPosition = Vector3.zero;
			var currentAngle = ((mySwitchObject.transform.localEulerAngles.x + 180) % 360) - 180;
			mySwitchObject.transform.localEulerAngles = Vector3.right * currentAngle;

			if(currentAngle > 0 && myIsActivated) {
				myOnDeactivated?.Execute();
				myIsActivated = false;
			}
			if(currentAngle < 0 && !myIsActivated) {
				myOnActivated?.Execute();
				myIsActivated = true;
			}
		}

		private void FixedUpdate() {
			var currentAngle = ((mySwitchObject.transform.localEulerAngles.x + 180) % 360) - 180;
			mySwitchObject.angularVelocity = Vector3.zero;
			mySwitchObject.AddRelativeTorque(Vector3.right * (currentAngle > 0 ? myForce : -myForce), ForceMode.Force);
			
			if(currentAngle > myMaxAngle) {
				mySwitchObject.transform.localEulerAngles = Vector3.right * myMaxAngle;
			}
			if(currentAngle < -myMaxAngle) {
				mySwitchObject.transform.localEulerAngles = Vector3.right * -myMaxAngle;
			}
		}
	}
}
