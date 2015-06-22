using UnityEngine;
using System.Collections;

public class KeyDetection : MonoBehaviour {

	bool over = false;
	bool keyAttached = false;
	bool opened = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject.Find("Key").transform.position = new Vector3(-0.5, 0, 0);
	}

	void OnMouseUp () {
		if (over) {
			keyAttached = true;
			Debug.Log("Key Left over Keyhole");
			//GameObject.Find("Key").transform.parent = GameObject.Find("Box").t
		}
	}

	void OnMouseEnter () {
		Debug.Log("Mouse Entered");
		if (Global.IsBeingDragged == GameObject.Find("Key"))// && gameObject.name == "Keyhole")
			over = true;
	}

	void OnMouseExit () {
		if (Global.IsBeingDragged == GameObject.Find("Key"))
			over = false;
	}

}
