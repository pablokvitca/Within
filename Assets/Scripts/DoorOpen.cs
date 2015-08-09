using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	bool opening = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (opening) {
			//this.transform.Rotate(new Vector3(0, this.transform.rotation.y ,0));
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 0.75f);
		}
	}

	public void Open(string pass) {
		if (pass == "rycbar123") {
			Debug.Log("Opening Door");
			Debug.Log("YOU WON!!!!!");
			opening = true;
		}
	}
}
