using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Apollo
{
	public enum ButtonType
	{
		B1,
		B2,
		B3,
		B4,
		B5,
		B6,
		
		Size
	}
	public enum ButtonState
	{
		Released,
		Pressed,
	}
	public enum IndecatorType
	{
		I1,
		I2,
		I3,
		I4,
		I5,
		I6,

		Size
	}
	public enum IndecatorState
	{
		Off,
		Blinking,
		DoubleBlinking,
		BlinkingFast,
		On,
	}
	public enum AlarmState
	{
		None,
		Beep,
		DoubleBeep,
		Sin,
		Continuous,
	}
	public enum ValueType
	{
		V1,
		V2,
		V3,
		V4,
		V5,
		V6,

		Size
	}
	public enum RotatorTypes
	{
		R1,
		R2,
		R3,
		R4,
		R5,
		R6,

		Size
	}

	public class GameState : Singleton<GameState>
	{
		public Observable<ButtonState>[] myButtons = new Observable<ButtonState>[(int)ButtonType.Size];
		public Observable<IndecatorState>[] myIndecators = new Observable<IndecatorState>[(int)IndecatorType.Size];
		public Observable<AlarmState> myAlarm = new Observable<AlarmState>();
		public Observable<float>[] myValues = new Observable<float>[(int)ValueType.Size];
		public Observable<int>[] myRotators = new Observable<int>[(int)RotatorTypes.Size];

		protected override void OnMyAwake() {
			for(int i = 0; i < myButtons.Length; i++) {
				myButtons[i] = new Observable<ButtonState>();
			}
			for(int i = 0; i < myIndecators.Length; i++) {
				myIndecators[i] = new Observable<IndecatorState>();
			}
			for(int i = 0; i < myValues.Length; i++) {
				myValues[i] = new Observable<float>();
			}
			for(int i = 0; i < myRotators.Length; i++) {
				myRotators[i] = new Observable<int>();
			}
		}
	}
}
