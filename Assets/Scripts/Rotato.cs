using UnityEngine;
using System.Collections;

public class Rotato : MonoBehaviour {
	public float Speed = 10.0f;
	public float aSpeed = -10.0f;
	bool Leftclicked = false;
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			Leftclicked = true;
		} else {
			Leftclicked = false;
		}
	}
}
