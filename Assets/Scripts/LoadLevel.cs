using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	private int cifrex;

	void Start () {
	/*switch (this.gameObject.name) {
		case "jugar":
			cifrex = 1;
			break;
		case "instrucciones":
			cifrex = 2;
			break;
		case "creditos":
			cifrex = 3;
			break;
		case "salir":
			cifrex = 21;
			break;

		}*/ //NACHO
	}

	void OnMouseDown () {
		/*if (cifrex == 21) {

			Application.Quit();
		} */ //NACHO
		switch (this.gameObject.name) {
			case "Jugar":
				Application.LoadLevel ("lvl1");
				break;
			case "Instrucciones":
				Application.LoadLevel("Instrucciones");
				break;
			case "Creditos":
				Application.LoadLevel("Creditos");
				break;
			case "Salir":
				Application.Quit();
				break;
			default:
				Debug.Log("nothing");
				break;
		}
		/*Application.LoadLevelAdditive (cifrex);*/ // NACHO
	}
}
