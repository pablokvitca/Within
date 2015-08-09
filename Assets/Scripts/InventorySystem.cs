using UnityEngine;
using System.Collections;

public class InventorySystem : MonoBehaviour {

	Clicked clickedobject;
	Global gl;

	// Use this for initialization
	void Start () {
		clickedobject = this.GetComponent<Clicked> ();
		gl = GameObject.Find ("ScriptGlobal").GetComponent<Global> ();
	}

	public void ManageInventory(GameObject clicked) {
		//Inventoriado de Objetos - START
		clickedobject = clicked.GetComponent<Clicked> ();
		try {
			if (!IsInInventory (clicked.name)) {
				if (clickedobject.visible) {
					GameObject Inventario = GameObject.Find ("Inventario");
					Inven codigo = Inventario.GetComponent<Inven> ();
					codigo.AddGO (clickedobject.sprite);
					//this.gameObject.GetComponent<Renderer> ().enabled = false;
					clicked.gameObject.SetActive (false);
					GameObject global = GameObject.Find ("ScriptGlobal");
					Global sglob = global.GetComponent<Global> ();
					sglob.objetoarr (clicked.name);
					clickedobject.visible = false;	
				}
				if (clickedobject.sg.Orbit) {
					clickedobject.isDragging = true;
					
				}
			}
		} catch {
			Debug.Log ("0035");
		}
		//Inventoriado de Objetos - END
	}

	public bool IsInInventory(string nameTarget) {
		//Global sg = GameObject.Find ("ScriptGlobal").GetComponent<Global> ();
		foreach (string name in gl.Inventario) {
			if (name == nameTarget)
				return true;
		}
		return false;
	}
}
