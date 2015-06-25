using UnityEngine;
using System.Collections;

public class DragTurn : MonoBehaviour {

	public GameObject dragged;
	public GameObject toTurn;
	public bool isRotating;
	public Vector3 mouseReference;
	public float dragSensitivity;
	private Vector3 mouseOffset;
	private Vector3 rotation;

	
	void Start () {
		rotation = Vector3.zero;
	}
	
	void Update() {
		if(isRotating) {
			// offset
			mouseOffset = (Input.mousePosition - mouseReference);
			
			// apply rotation
			rotation.z = -(mouseOffset.x + mouseOffset.y) * dragSensitivity;
			
			// rotate
			toTurn.transform.Rotate(rotation);
			
			// store mouse
			mouseReference = Input.mousePosition;
		}
	}
	
	void OnMouseDown() {
		// rotating flag
		isRotating = true;
		
		// store mouse
		mouseReference = Input.mousePosition;
	}
}
