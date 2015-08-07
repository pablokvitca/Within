using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	void OnMouseDown () {
		switch (this.gameObject.name) {
			case "Jugar":
				Application.LoadLevel ("lvl1");
				break;
			case "Instrucciones":
				Application.LoadLevel ("Instrucciones");
				break;
			case "Creditos":
				Application.LoadLevel ("Creditos");
				break;
			case "Salir":
				Application.Quit ();
				break;
			default:
				Debug.Log("nothing");
				break;
		}
	}
}
