using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Apollo
{
	public class DummyGame : MonoBehaviour
	{
		[SerializeField] GameEvent myEvent;

		void Start() {
			myEvent = Instantiate(myEvent);
			myEvent.OnInstanciation();
		}
	}
}
