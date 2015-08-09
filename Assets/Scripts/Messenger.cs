using UnityEngine;
using System.Collections;

public class Messenger : MonoBehaviour {

	private static float speed = 0.01f;

	// Update is called once per frame
	void Update () {
		Color c = Camera.main.transform.FindChild("Messenger").GetComponent<TextMesh>().color;
		c.a -= speed;
		Camera.main.transform.FindChild("Messenger").GetComponent<TextMesh>().color = c;
	}

	public static void Message(string message, float _speed, Color color, bool overwrite, bool playsound) {
		if (overwrite) {
			Camera.main.transform.FindChild("Messenger").GetComponent<TextMesh>().text = message;
			Camera.main.transform.FindChild("Messenger").GetComponent<TextMesh>().color = color;
			if (playsound) Camera.main.transform.FindChild("Messenger").GetComponent<AudioSource>().Play();
			speed = _speed;
		}
	}
}
