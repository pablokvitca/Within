using UnityEngine;
using System.Collections;

public class GeneralThings : MonoBehaviour {

	Global gl;

	// Use this for initialization
	void Start () {
		gl = GameObject.Find ("ScriptGlobal").GetComponent<Global> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp () {
		gl.ClearTurnFlags ();
		Debug.Log ("All Turn Flags Cleared");
	}
}
