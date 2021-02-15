using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Apollo
{
	public class DummyGame : MonoBehaviour
	{
		[SerializeField] Image myImage;
		[SerializeField] GameEvent myEvent;

		void Start() {
			myImage.gameObject.SetActive(false);
			GameState.s_instance.values[(int)ValueTypes.Altitude].value = Random.Range(0.0f, 100.0f);
			StartCoroutine(Trigger(Random.Range(10.0f, 40.0f)));
		}

		IEnumerator Trigger(float aDelay) {
			yield return new WaitForSeconds(aDelay);
			myEvent = Instantiate(myEvent);
			myEvent.OnInstanciation();
			myImage.gameObject.SetActive(true);
		}
	}
}
