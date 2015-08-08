using UnityEngine;
using System.Collections;

public class Rotato : MonoBehaviour {
	public float Speed = 10.0f;
	public float aSpeed = -10.0f;
	bool Leftclicked = false;
	//private ClickedRight clicked;
	//private ClickedLeft Lclicked;
	//Use this for initialization
	void Start () {
	
	}

	void Awake(){

		//clicked = GetComponent<ClickedRight>();
		//Lclicked = GetComponent<ClickedLeft>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			Leftclicked = true;
		} else {
			Leftclicked = false;
		}
	}
	/*void LateUpdate () {
		if (clicked.RightB && Leftclicked == true) {
			transform.Rotate(Vector3.up, Speed * Time.deltaTime);
		}
		if (Lclicked.LeftB && Leftclicked == true) {
			transform.Rotate(Vector3.up, aSpeed * Time.deltaTime);
		}
	}*/

}
