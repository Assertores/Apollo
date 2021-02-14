using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Apollo
{
	public enum ButtonTypes
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
	public enum AlarmType
	{
		None,
		Beep,
		DoubleBeep,
		Sin,
		Continuous,
	}
	public enum ValueTypes
	{
		Altitude = 0,
		Fule,

		Size
	}

	public class GameState : Singleton<GameState>
	{
		public Observable<ButtonState>[] buttons = new Observable<ButtonState>[(int)ButtonTypes.Size];
		public Observable<AlarmType> alarm = new Observable<AlarmType>();
		public Observable<float>[] values = new Observable<float>[(int)ValueTypes.Size];

		protected override void OnMyAwake() {
			for(int i = 0; i < buttons.Length; i++) {
				buttons[i] = new Observable<ButtonState>();
			}
			for(int i = 0; i < values.Length; i++) {
				values[i] = new Observable<float>();
			}
		}
	}
}
