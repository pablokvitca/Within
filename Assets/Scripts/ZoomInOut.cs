using UnityEngine;
using System.Collections;

public class ZoomInOut : MonoBehaviour {

	public GameObject cameraHolder;
	public GameObject cameraPrev;
	public float transitionDuration;
	bool moving = false;

	Vector3 startPoint;
	Quaternion startTurn;
	Quaternion turnLength;

	// Use this for initialization
	void Start() {
	}

	// Update is called once per frame
	void Update() {
		if (moving) {
			MoveAndTurnCamera (Camera.main, cameraHolder);
		}
	}

	public void Zoom(GameObject dclicked)
	{
		if (!(Camera.main.transform.position == cameraHolder.transform.position)) {
			Debug.Log (dclicked.ToString () + "was LEFT Double Clicked!");
			moving = true;
		} else {
			Debug.Log ("Zooming out");
			MoveAndTurnCamera(Camera.main, cameraPrev);
			Debug.Log ("Zooming out finished");
		}
	}

	void MoveAndTurnCamera(Camera cam, GameObject holder) {
		//Snaps
		cam.transform.position = holder.transform.position;
		cam.transform.rotation = holder.transform.rotation;
		moving = false;
	}
}



























