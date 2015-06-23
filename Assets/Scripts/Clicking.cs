using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clicking : MonoBehaviour {
	public GameObject objetoquevaalpresionarse;
	public Vector3 Posiciondelobjetonuevo;

	bool playAnimsLlave = false;

	Global gl;

	// Use this for initialization
	void Start () {
		gl = GameObject.Find ("ScriptGlobal").GetComponent<Global> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playAnimsLlave) {
			gl.GameObjectFinder ("Llave").SetActive (true);
			gl.GameObjectFinder ("Llave").GetComponent<Animator> ().SetBool ("openNow", true);
			gl.GameObjectFinder ("CAJA AN 1").GetComponent<Animator> ().SetBool ("openDrawer", true);
			playAnimsLlave = false;
		}
	}

	void OnMouseDown(){
		GameObject global = GameObject.Find ("ScriptGlobal");
		Global sglob = global.GetComponent<Global> ();
		if (sglob.Selected == objetoquevaalpresionarse.name) {
			sglob.SacardelInventario(objetoquevaalpresionarse.name);
			sglob.desobjeto(objetoquevaalpresionarse.name);
			//objetoquevaalpresionarse.GetComponent<Renderer>().enabled=true;
			objetoquevaalpresionarse.SetActive(true);
			objetoquevaalpresionarse.transform.position =Posiciondelobjetonuevo;
			objetoquevaalpresionarse.transform.rotation= Quaternion.Euler(0, 0, 0);
			sglob.Selected=""; 
			Clicked sc = objetoquevaalpresionarse.GetComponent<Clicked>();
			sc.visible=true;
		} 
		if (this.name == "Placa")
			playAnimsLlave = true;
	}
	
}