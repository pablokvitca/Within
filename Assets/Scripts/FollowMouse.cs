using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
	
	//http://docs.unity3d.com/Manual/CreateDestroyObjects.html
	//http://answers.unity3d.com/questions/34795/how-to-perform-a-mouse-click-on-game-object.html
	//http://answers.unity3d.com/questions/34795/how-to-perform-a-mouse-click-on-game-object.html

	Quaternion targetRotation;
	float speed;
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = this.GetComponent<Camera>();
		speed = 0.75f;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		if (y < Screen.height / 6 || x > Screen.width / 8 * 7 || y > Screen.height / 6 * 5 || (x < Screen.width / 8 && x > Screen.width / 100 * 8)) {
			if (y  > Screen.height / 100 * 10) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit RayHit;
				if (Physics.Raycast(ray, out RayHit)) {
					Debug.DrawLine (ray.origin, RayHit.point);
					targetRotation = Quaternion.LookRotation(RayHit.point - cam.transform.position);
					cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, targetRotation, Time.deltaTime * speed);
				}
			}
		}
	}

	/*//Rotate the camera to those angles 
	var rotation = Quaternion.Euler(y, x, 0);
	transform.rotation = rotation;
	
	//Move the camera to look at the target
	var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
	transform.position = position;

	Quaternion targetRotation;  //Script variable
	double speed;
	Camera cam;

	// Use this for initialization
	void Start () {
		targetRotation = new Quaternion ();
		speed = 2.0;
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit RayHit;
		if (Physics.Raycast (ray, out RayHit, 1200.0f)) {
			Debug.DrawLine (ray.origin, RayHit.point);
			targetRotation = Quaternion.LookRotation(RayHit.point - cam.transform.position);
			//cam.transform.LookAt(targetRotation);
		}
	}

	void LateUpdate() {
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
	}*/
}
