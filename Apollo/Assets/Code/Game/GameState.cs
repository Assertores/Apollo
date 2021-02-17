using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Apollo
{
	public enum ButtonType
	{
		SAS = 0,
		Radar,
		COM,
		Electric,
		
		Size
	}
	public enum ButtonState
	{
		Released,
		Pressed,
	}
	public enum IndecatorType
	{
		DynamicPressure = 0,
		Oxygene,
		Heat,

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
		Altitude = 0,
		Fuel,

		Size
	}
	public enum RotatorTypes
	{
		Stage = 0,
		ElectricMode,

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
