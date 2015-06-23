using UnityEngine;
using System.Collections;

public class Combinar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Click()
	{
		GameObject global = GameObject.Find ("ScriptGlobal");
		Global sglob = global.GetComponent<Global> ();
		sglob.Combinar = true;
	}
}
