using UnityEngine;
using System.Collections;

public class PlayAnimations : MonoBehaviour {

	Global gl;

	public Animator anim;
	public string boolName;

	// Use this for initialization
	void Start () {
		gl = GameObject.Find ("ScriptGlobal").GetComponent<Global> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RunAnimation(GameObject toAnimate) { //Coens
		try { 
			if (gl.GameObjectFinder ("Vela prendida").activeSelf == true) {
				gl.GameObjectFinder ("Vela prendida").GetComponent<Animator> ().SetBool ("openNow", true);
				//Esconder dsp de animacion
			}
		} catch {
		}
		try { 
			if (gl.GameObjectFinder ("Llave").activeSelf == true) {
				gl.GameObjectFinder ("Llave").GetComponent<Animator> ().SetBool ("openNow", true);
			}
		} catch {
		}
		if (toAnimate.tag == "Animated" || toAnimate.tag == "caja partes") {
			Debug.Log ("Running Animation " + boolName + " , " + toAnimate.name.ToString());
			if (toAnimate.name == "Tapa( la que sirve)") { //esto tambien
				toAnimate.GetComponent<MeshCollider> ().enabled = false;
				toAnimate.transform.transform.transform.transform.transform.transform.transform.transform.parent.gameObject.transform.transform.transform.GetChild (0).GetComponent<MeshCollider> ().enabled = true;
			}
			anim.SetBool (boolName, true);
		}
	}
}
