using UnityEngine;
using System.Collections;

public class MuebleRotate : MonoBehaviour {

	public static bool rotate = false;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (rotate == true) {
			this.transform.Rotate(new Vector3(0,0,0));
			MuebleRotate.rotate = false;
		}
	}

	public static void GirarMueble(string pass) {
		try {
			if (pass == "unitysucks")
				GameObject.Find("Mueble").transform.Rotate(new Vector3(0,180,0));
			else
				Debug.Log("odd, they couldn't guess the password: " + pass + " :(");
		} catch {
			Debug.Log (pass);
		}
	}
}
