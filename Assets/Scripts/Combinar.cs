using UnityEngine;
using System.Collections;

public class Combinar : MonoBehaviour {
	
	void Click()
	{
		GameObject global = GameObject.Find ("ScriptGlobal");
		Global sglob = global.GetComponent<Global> ();
		sglob.Combinar = true;
	}
}
