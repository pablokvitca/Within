using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Messenger : MonoBehaviour {

	private static float speed = 0.01f;

	private static List<string> oncedList = new List<string>();

	// Update is called once per frame
	void Update () {
		Color c = Camera.main.transform.Find("Messenger").GetComponent<TextMesh>().color;
		c.a -= speed;
		Camera.main.transform.Find("Messenger").GetComponent<TextMesh>().color = c;
	}

	public static void Message(string message, float _speed, Color color, bool overwrite, bool playsound) {
		if (overwrite) {
			Camera.main.transform.Find("Messenger").GetComponent<TextMesh>().text = message;
			Camera.main.transform.Find("Messenger").GetComponent<TextMesh>().color = Color.black;//color;
			if (playsound) Camera.main.transform.Find("Messenger").GetComponent<AudioSource>().Play();
			speed = _speed;
		}
	}

	public static void Message(string message, float _speed, Color color, bool overwrite, bool playsound, bool once) {
		if (overwrite && !Onced(message)) {
			oncedList.Add(message);
			Camera.main.transform.Find("Messenger").GetComponent<TextMesh>().text = message;
			Camera.main.transform.Find("Messenger").GetComponent<TextMesh>().color = Color.black;//color;
			if (playsound) Camera.main.transform.Find("Messenger").GetComponent<AudioSource>().Play();
			speed = _speed;
		}
	}

	private static bool Onced(string s) {
		foreach (string e in oncedList) {
			if (e == s) return true;
		}
		return false;
	}
}
