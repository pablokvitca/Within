using UnityEngine;
using System.Collections;

public class DragTurn : MonoBehaviour {

	public char axis = 'z';
	public GameObject dragged;
	public GameObject toTurn;
	public bool isRotating;
	public Vector3 mouseReference;
	public float dragSensitivity = 0.4f;
	public bool mayRotate;
	public float timer;
	private Vector3 mouseOffset;
	private Vector3 rotation;

	
	void Start () {
		rotation = Vector3.zero;
	}
	
	void Update() {
		if (mayRotate && Time.time - timer > dragSensitivity * 2) {
			Debug.Log("Timer died out. (" + Time.time.ToString() + ")&(" + timer.ToString() + ")");
			mayRotate = false;
			timer = -1;
		}
		if (mayRotate && Input.mousePosition != mouseReference) {
			mayRotate = false;
			isRotating = true;
			timer = -1;
		}
		if(isRotating) {
			// offset
			mouseOffset = (Input.mousePosition - mouseReference);
			
			// apply rotation
			switch (axis) {
				case 'x':
					rotation.x = -(mouseOffset.x + mouseOffset.y) * dragSensitivity;
				break;
				case 'y':
					rotation.y = -(mouseOffset.x + mouseOffset.y) * dragSensitivity;
				break;
				case 'z':
					rotation.z = -(mouseOffset.x + mouseOffset.y) * dragSensitivity;
				break;
			}
			// rotate
			toTurn.transform.Rotate(rotation);
			
			// store mouse
			mouseReference = Input.mousePosition;
		}
	}
	
	void OnMouseDown() {
		// rotating flag
		mayRotate = true;

		timer = Time.time;
		
		// store mouse
		mouseReference = Input.mousePosition;
	}


}
