using UnityEngine;
using System.Collections;

public class ClickedRight : MonoBehaviour {
	public GameObject candelabro;
	float smooth = 2.0f;


	bool clicking = false;

	Vector3 targetRot = Vector3.zero;
	// Use this for initialization
	void Start () {
		targetRot = candelabro.transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if (clicking)
			candelabro.transform.eulerAngles += new Vector3(0,1.0f,0);
	}
	
	void OnMouseDown() {
		clicking = true;
		targetRot += new Vector3(0.0f, 90.0f, 0.0f);
	}

	
	void OnMouseUp() {
		clicking = false;
	}
	
}