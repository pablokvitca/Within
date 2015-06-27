using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clicking : MonoBehaviour {
	public GameObject objetoquevaalpresionarse;
	public Vector3 Posiciondelobjetonuevo;

	Global gl;

	// Use this for initialization
	void Start () {
		gl = GameObject.Find ("ScriptGlobal").GetComponent<Global> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		GameObject global = GameObject.Find ("ScriptGlobal");
		Global sglob = global.GetComponent<Global> ();
		InventorySystem invs = GameObject.Find("ScriptGlobal").GetComponent<InventorySystem> ();

		switch (this.name) {
			case "Placa":
				if (invs.IsInInventory ("Llave")) {
					GameObject key = gl.GameObjectFinder ("Llave");
					GameObject newPos = gl.GameObjectFinder ("KeyHolder");
					key.transform.parent = newPos.transform.parent;
					key.transform.position = newPos.transform.position;
					key.transform.rotation = newPos.transform.rotation;
					key.GetComponent<Clicked>().enabled = false;
					key.GetComponent<InventorySystem>().enabled = false;
					sglob.Selected = "Llave";
					objetoquevaalpresionarse = gl.GameObjectFinder("Llave");
				} else {
					Debug.Log ("You need a key");
				}
			break;
			case "LlaveHole":
				if (invs.IsInInventory ("Vela prendida")) {
					gl.GameObjectFinder ("Llave").SetActive (true);
					sglob.Selected = "Vela prendida";
					objetoquevaalpresionarse = gl.GameObjectFinder("Vela prendida");
					GameObject vp = gl.GameObjectFinder("Vela prendida");
					vp.SetActive(true);
					//sglob.SacardelInventario(vp.name);
					//sglob.desobjeto(vp.name);
					//vp.transform.position = Posiciondelobjetonuevo;
					Debug.Log(vp.transform.position.ToString() + "0333");
					vp.GetComponent<Animator>().SetBool("openNow", true);
					//Esconder vela dsp de animacion
				} else {
					Debug.Log ("You need a fire & wax");
				}
			break;
		}
			
		if (sglob.Selected == objetoquevaalpresionarse.name) {
			try {
				sglob.SacardelInventario(objetoquevaalpresionarse.name);
				sglob.desobjeto(objetoquevaalpresionarse.name);
				//objetoquevaalpresionarse.GetComponent<Renderer>().enabled=true;
				objetoquevaalpresionarse.SetActive(true);
				objetoquevaalpresionarse.transform.localPosition = Posiciondelobjetonuevo;
				//objetoquevaalpresionarse.transform.localRotation = Quaternion.Euler(0, 0, 0);
				sglob.Selected=""; 
				Clicked sc = objetoquevaalpresionarse.GetComponent<Clicked>();
				sc.visible=true;
			} catch {}
		} 
	}
	
}