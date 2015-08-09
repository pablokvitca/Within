using UnityEngine;
using System.Collections;

public class MuebleRotate : MonoBehaviour {

	public static bool rotate = false;

	// Update is called once per frame
	void Update () {
		if (rotate == true) {
			this.transform.Rotate(new Vector3(0,0,0));
			MuebleRotate.rotate = false;
		}
	}

	public static void GirarMueble(string pass) {
		try {
			if (pass == "unitysucks") {
				Messenger.Message("MUY BIEN!!!", 0.01f, Color.green, true, true);
				GameObject.Find("Mueble").transform.Rotate(new Vector3(0,180,0));
			}
			else
				Debug.Log("odd, they couldn't guess the password: " + pass + " :(");
		} catch {
			Debug.Log (pass);
		}
	}
}
