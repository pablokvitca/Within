using UnityEngine;
using System.Collections;

public class ClickedRight : MonoBehaviour {
	public GameObject candelabro;
	float smooth = 2.0f;


	bool clicking = false;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		if (clicking)
			candelabro.transform.eulerAngles += new Vector3(0,1.0f,0);
	}
	
	void OnMouseDown() {
		clicking = true;
	}
	
	void OnMouseUp() {
		clicking = false;
	}
	
}