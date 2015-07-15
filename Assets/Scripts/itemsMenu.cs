using UnityEngine;
using System.Collections;

public class itemsMenu : MonoBehaviour {

	//For Animation
	public float max = 2.0f;
	public float speed = 2.0f;
	private Vector3 starting;
	private bool goingUp = true;

	// Use this for initialization
	void Start () {
		starting = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//AnimateItem
		AnimateItem ();
	}

	void AnimateItem() {
		if (goingUp)
			this.transform.position += new Vector3(0, speed, 0);
		else
			this.transform.position -= new Vector3(0, speed, 0);
		if (this.transform.position.y - starting.y >= max)
			goingUp = false;
		if (this.transform.position.y - starting.y < 0)
			goingUp = true;
	}
}