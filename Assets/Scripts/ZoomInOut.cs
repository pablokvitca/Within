﻿using UnityEngine;
using System.Collections;

public class ZoomInOut : MonoBehaviour {
	
	public GameObject cameraHolder;
	public GameObject cameraPrev;
	public float transitionDuration;

	public bool moving = false;

	Vector3 startPoint;
	Quaternion startTurn;
	Quaternion turnLength;

	Global glo;

	private Transform destHolder;

	public float smooth = 1.5f; // The relative speed at which the camera will catch up.
	public float near = 0.25f;

	void Start() {
		glo = GameObject.Find("ScriptGlobal").GetComponent<Global>();
		Global.camMoving = moving;
		destHolder = cameraHolder.transform;
		Cursor.SetCursor(glo.cursorTexture, glo.hotSpot, glo.cursorMode);
	}

	//TODO: Ver que paso con la animacion de la vela !important 1
	//TODO: Agrandar habitacion important 0
	//TODO: Animar Flechitas !important 0.75 (si no funciona usar Transform.RotateAround)
	//TODO: Poner textura correcta manija puerta !important 0.25
	//TODO: Poner llave cuando termina la animacion, y sacar el planito !important 0.75
	//TODO: Cambiar caja por sprite posta !important 0.5
	//TODO: Poner caja roja en inv al volver

	void OnMouseOver() {
		Cursor.SetCursor(glo.cursorTextureLupa, glo.hotSpot, glo.cursorMode);
	}

	void OnMouseEnter() {
		Cursor.SetCursor(glo.cursorTextureLupa, glo.hotSpot, glo.cursorMode);
	}

	void OnMouseExit() {
		Cursor.SetCursor(glo.cursorTexture, glo.hotSpot, glo.cursorMode);
	}

	public void Zoom(GameObject dclicked) {
		if (moving) {
			if (!glo.IsNear (Camera.main.transform, cameraHolder.transform, near)) {
				Debug.Log (dclicked.ToString () + "was LEFT Double Clicked!");
				Debug.Log ("Zooming in");
				destHolder = cameraHolder.transform;
				Debug.Log ("Zooming in finished");
				if (ZoomFinished (Camera.main.transform, destHolder))
					moving = false;
				else
					moving = true;
			} else {
				Debug.Log ("Zooming out");
				destHolder = cameraPrev.transform;
				Debug.Log ("Zooming out finished");
				if (ZoomFinished (Camera.main.transform, destHolder))
					moving = false;
				else
					moving = true;
			}
		} else {
			Debug.Log("Camera is already moving. Please wait for it to finish.");
		}
	}

	void Update() {
		if (moving) {
			// Lerp the camera's position between it's current position and it's new position.
			SmoothTranslate(Camera.main, Camera.main.transform, destHolder, smooth);
			SmoothLookAt(Camera.main, Camera.main.transform, destHolder, smooth);
			if (ZoomFinished(Camera.main.transform, destHolder))
				moving = false;
			else
				moving = true;
			Global.camMoving = moving;

			//Snaps
			//Camera.main.transform.position = destHolder.position;
			//Camera.main.transform.rotation = destHolder.rotation;
		}
	}
	
	void SmoothTranslate (Camera cam, Transform current, Transform dest, float timeFactor) {	
		cam.transform.position = Vector3.Lerp(current.position, dest.position, timeFactor * Time.deltaTime);
	}

	void SmoothLookAt (Camera cam, Transform current, Transform dest, float timeFactor) {	
		cam.transform.rotation = Quaternion.Lerp(current.rotation, dest.rotation, timeFactor * Time.deltaTime);
	}

	bool ZoomFinished (Transform current, Transform dest) {
		return glo.IsNear (current, dest, near);
	}
}