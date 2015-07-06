using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider entra)
	{
		if (entra.tag == "TablaPeriodica") {
			Debug.Log ("Ganaste, sos re crack");
			Application.LoadLevel("lvl1");
		}
	}
}
