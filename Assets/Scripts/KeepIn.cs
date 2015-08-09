using UnityEngine;
using System.Collections;

public class KeepIn : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		Camera.main.transform.position = new Vector3(0, 15, 0);
		Messenger.Message("No puedes estar ahi.", 0.1f, Color.red, true, false);
	}

	void OnCollisionEnter() {
		Camera.main.transform.position = new Vector3(0, 15, 0);
	}
}
