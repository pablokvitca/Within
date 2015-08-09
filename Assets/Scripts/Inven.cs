using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inven : MonoBehaviour {

	public string LinkImagen;

	public void AddGO (Sprite sprite){
		GameObject Inventario = GameObject.Find ("Inventario 1");
		UnityEngine.UI.Button btn = Inventario.GetComponent<UnityEngine.UI.Button> ();
		if (btn.interactable == false) {
			btn.interactable = true;
			btn.image.sprite = sprite;
		} else {
			Inventario = GameObject.Find ("Inventario 2");
			btn = Inventario.GetComponent<UnityEngine.UI.Button> ();
			if (btn.interactable == false) {
				btn.interactable = true;
				btn.image.sprite = sprite;
			} else {
				Inventario = GameObject.Find ("Inventario 3");
				btn = Inventario.GetComponent<UnityEngine.UI.Button> ();
				if (btn.interactable == false) {
					btn.interactable = true;
					btn.image.sprite = sprite;
				} else {
					Inventario = GameObject.Find ("Inventario 4");
					btn = Inventario.GetComponent<UnityEngine.UI.Button> ();
					if (btn.interactable == false) {
						btn.interactable = true;
						btn.image.sprite = sprite;
					} else {
						Inventario = GameObject.Find ("Inventario 5");
						btn = Inventario.GetComponent<UnityEngine.UI.Button> ();
						if (btn.interactable == false) {
							btn.interactable = true;
							btn.image.sprite = sprite;
						}
					
					}
				}
			}
		}								
	}

	public void Something(UnityEngine.UI.Button btnn){
		//ejecuto cuando aprieto boton normal inventario
		GameObject global = GameObject.Find ("ScriptGlobal");
		Global sglob = global.GetComponent<Global> ();
		NumInt numint = btnn.GetComponent<NumInt> ();
		int Numeroinv = numint.numarray;
		sglob.Selected = sglob.Inventario [Numeroinv];

		 
		sglob.Resolve (btnn.name);
	}

	public void Click()
	{
		GameObject global = GameObject.Find ("ScriptGlobal");
		Global sglob = global.GetComponent<Global> ();
		sglob.Combinar = true;
	}

	public void Orbitar(){
		GameObject global = GameObject.Find ("ScriptGlobal");
		Global sglob = global.GetComponent<Global> ();
		Messenger.Message("Haz click derecho " + "\n" + "para salir", 0.01f, Color.yellow, true, false);
		sglob.Orbit = true;
	}
}
