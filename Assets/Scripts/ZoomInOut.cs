using UnityEngine;
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

	public float smooth = 1.5f;         // The relative speed at which the camera will catch up.

	void Start() {
		glo = GameObject.Find("ScriptGlobal").GetComponent<Global>();
		destHolder = glo.GameObjectFinder("RoomStructure").gameObject.transform.GetChild(0).gameObject.transform;
	}

	public void Zoom(GameObject dclicked)
	{
		if (!(Camera.main.transform.position == cameraHolder.transform.position)) {
			Debug.Log (dclicked.ToString () + "was LEFT Double Clicked!");
			Debug.Log ("Zooming in");
			destHolder = cameraHolder.transform;
			Debug.Log ("Zooming in finished");
			if (ZoomFinished(Camera.main.transform, cameraHolder.transform))
				moving = false;
			else
				moving = true;
		} else {
			Debug.Log ("Zooming out");
			destHolder = cameraPrev.transform;
			Debug.Log ("Zooming out finished");
			if (ZoomFinished(Camera.main.transform, cameraPrev.transform))
				moving = false;
			else
				moving = true;
		}
		/*if (!(Camera.main.transform.position == cameraHolder.transform.position)) {
			Debug.Log (dclicked.ToString () + "was LEFT Double Clicked!");
			Debug.Log ("Zooming in");
			MoveAndTurnCamera (Camera.main, cameraHolder);
			Debug.Log ("Zooming in finished");
			if (ZoomFinished(Camera.main.transform, cameraHolder.transform))
				moving = false;
			else
				moving = true;
		} else {
			Debug.Log ("Zooming out");
			MoveAndTurnCamera(Camera.main, cameraPrev);
			Debug.Log ("Zooming out finished");
			if (ZoomFinished(Camera.main.transform, cameraPrev.transform))
				moving = false;
			else
				moving = true;
		}*/
	}

	void Update() {
		if (moving) {
			// Lerp the camera's position between it's current position and it's new position.
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, destHolder.position, smooth * Time.deltaTime);
			SmoothLookAt();

			//Snaps
			//cam.transform.position = holder.transform.position;
			//cam.transform.rotation = holder.transform.rotation;
		}
	}
	
	void SmoothLookAt ()
	{	
		// Create a rotation based on the relative position of the player being the forward vector.
		Quaternion lookAtRotation = Quaternion.LookRotation(Camera.main.transform.position, transform.position);
		
		// Lerp the camera's rotation between it's current rotation and the rotation that looks at the player.
		Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, lookAtRotation, smooth * Time.deltaTime);
	}

	bool ZoomFinished (Transform current, Transform dest) {
		if (current.position == dest.position)
			return true;
		else
			return false;
	}
}