﻿using UnityEngine;
using System.Collections;

public class RotacionObjetos : MonoBehaviour {
	//Ojbeto tiene que rotar al hacer click sobre el mismo y hacer un "drag" para indicar como tiene que rotar 
	//Al soltar el click para la rotacion y deja al objeto en la posicion que rotaste

	//http://answers.unity3d.com/questions/34317/rotate-object-with-mouse-cursor-that-slows-down-on.html
	//https://unity3d.com/learn/tutorials/projects/roll-a-ball/moving-the-player
	// Use this for initialization

	//#DiosBendigaA la pagina de unity
	private float rotationSpeed = 10.0F;
	private float lerpSpeed = 1.0F;
	
	private Vector3 theSpeed;
	private Vector3 avgSpeed;
	private bool isDragging = false;
	private Vector3 targetSpeedX;


	void OnMouseDown() {
		isDragging = true;	
	}
		
	// Update is called once per frame
	void Update () {
		if (isDragging && Input.GetMouseButton(0)) {
			theSpeed = new Vector3(-Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0F);
			avgSpeed = Vector3.Lerp(avgSpeed, theSpeed, Time.deltaTime * 5);
		} else {
			if (isDragging) {
				theSpeed = avgSpeed;
				isDragging = false;
			}
			float i = Time.deltaTime * lerpSpeed;
			theSpeed = Vector3.Lerp(theSpeed, Vector3.zero, i);
		}
		transform.Rotate(Camera.main.transform.up * theSpeed.x * rotationSpeed, Space.World);
		transform.Rotate(Camera.main.transform.right * theSpeed.y * rotationSpeed, Space.World);
	}
}