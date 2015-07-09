using UnityEngine;
using System.Collections;

public class CreepyEyeFollow : MonoBehaviour {

	private Vector3 positionPrev = Vector3.zero;
	private float timer = 0.5f;

	// Use this for initialization
	void Start () {
		positionPrev = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (positionPrev != Camera.main.transform.position)
			timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = 0.5f;
			this.transform.LookAt (Camera.main.transform);
		}*/
		this.transform.LookAt (Camera.main.transform);
	}
}
