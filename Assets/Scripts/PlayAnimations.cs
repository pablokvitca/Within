﻿using UnityEngine;
using System.Collections;

public class PlayAnimations : MonoBehaviour {

	Global gl;

	public Animator anim;
	public string boolName;

	private string pass = "unitysucks";

	float timer = -10.0f;


	// Use this for initialization
	void Start () {
		gl = GameObject.Find ("ScriptGlobal").GetComponent<Global> ();
	}
	

	public void RunAnimation(GameObject toAnimate) { //Coens
		try { 
			if (gl.GameObjectFinder ("Vela prendida").activeSelf == true) {
				gl.GameObjectFinder("LlenadoCeraUnique").SetActive(true);
				gl.GameObjectFinder ("Vela prendida").GetComponent<Animator> ().SetBool ("openNow", true);
				Debug.Log ("Running Animation " + boolName + " , " + toAnimate.name.ToString());
				Debug.Log ("unity sucks " + toAnimate.GetComponent<Animator>().playbackTime.ToString());
				timer = Time.time;
				//Esconder dsp de animacion
			}
		} catch {}

		try {
			if (gl.GameObjectFinder ("Llave").activeSelf == true) {
				gl.GameObjectFinder ("Llave").GetComponent<Animator> ().SetBool ("openNow", true);
			}
		} catch {}

		if (toAnimate.tag == "Animated" || toAnimate.tag == "caja partes") {
			Debug.Log ("Running Animation " + boolName + " , " + toAnimate.name.ToString());
			if (toAnimate.name == "Tapa( la que sirve)") { //esto tambien
				toAnimate.GetComponent<MeshCollider> ().enabled = false;
				toAnimate.transform.parent.gameObject.transform.GetChild (0).GetComponent<MeshCollider> ().enabled = true;
			}
			anim.SetBool (boolName, true);
		}

		try {
			if (anim.gameObject.name == "Lib") {
				//MuebleRotate.rotate = true;
				MuebleRotate.GirarMueble(pass);
				pass = "yepitdoes";
			}
		} catch {}
		Debug.Log ("Running Animation " + boolName + " , " + toAnimate.name.ToString());
	}
}