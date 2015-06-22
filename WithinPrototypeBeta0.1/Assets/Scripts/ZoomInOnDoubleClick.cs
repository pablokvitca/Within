using UnityEngine;
using System.Collections;

public class ZoomInOnDoubleClick : MonoBehaviour {

	public GameObject cameraHolder;
	public GameObject cameraPrev;
	public float transitionDuration;
	float doubleClickStart = -1;
	bool moving = false;
	bool doubleClickHelper = true;
	Vector3 startPoint;
	//float startTime;
	//float moveLength;
	Quaternion startTurn;
	Quaternion turnLength;

	//Play animations:
	public Animator animator;
	public string boolName;

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
		//Single clicking
		if (doubleClickStart != -1 && Time.time - doubleClickStart > 0.5f && doubleClickHelper) {
			//Single click code HERE!

			//COEN - START!!!
			if (this.tag == "Animated") {
				Debug.Log("unity puto");
				RunAnimation(boolName, animator);
			}
			//COEN - END!!!!!
			doubleClickStart = -1;
			Debug.Log("Single click!");
		}
		if (moving) {
			MoveAndTurnCamera (Camera.main, cameraHolder);
		}
	}

	void OnMouseUp() {
		Debug.Log("yey (" + this.ToString() + "was LEFT clicked)");
		if ((Time.time - doubleClickStart) < 0.3f)
		{
			this.OnDoubleClick();
			doubleClickStart = -1;
			doubleClickHelper = true;
		}
		else
		{
			doubleClickStart = Time.time;
		}
	}
	
	void OnDoubleClick()
	{
		doubleClickHelper = false;
		if (!(Camera.main.transform.position == cameraHolder.transform.position)) {
			Debug.Log (this.ToString () + "was LEFT Double Clicked!");
			moving = true;
		} else {
			Debug.Log ("Zooming out");
			MoveAndTurnCamera(Camera.main, cameraPrev);
			Debug.Log ("Zooming out finished");
		}

		//Smooth Movement - Doesn't Work
		//Translate
		//startPoint = Camera.main.transform.position;
		//moveLength = Vector3.Distance(startPoint, cameraHolder.transform.position);
		//startTime = Time.time;
		//Rotate
		//startTurn = Camera.main.transform.rotation;
		//turnLength = Quaternion.RotateTowards(startTurn, cameraHolder.transform.rotation, 15.0f);
	}

	void MoveAndTurnCamera(Camera cam, GameObject holder) {
		//Snaps
		cam.transform.position = holder.transform.position;
		cam.transform.rotation = holder.transform.rotation;
		moving = false;

		//Smooth Movement - Doesn't Work
		//float distCovered = (Time.time - startTime) * transitionDuration;
		//float step = distCovered / moveLength;
		//cam.transform.Translate(Vector3.Lerp(startPoint, holder.transform.position, step) * Time.deltaTime);

		//if (cam.transform.position == holder.transform.position && cam.transform.rotation == holder.transform.rotation)
		//	moving = false;
	}

	private void MoveTowardsTarget(Vector3 target, Vector3 current, float speed) {
		//first, check to see if we're close enough to the target
		if(Vector3.Distance(current, target) > .1f) { 
			Vector3 directionOfTravel = target - current;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize();
			//scale the movement on each axis by the directionOfTravel vector components
			
			this.transform.Translate(
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);
		}
	}

	void RunAnimation(string animName, Animator anim) { //Coens
		anim.SetBool(animName, true);
	}
}



























