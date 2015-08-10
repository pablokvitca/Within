using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clicking : MonoBehaviour {
	public GameObject objetoquevaalpresionarse;
	public Vector3 Posiciondelobjetonuevo;

	public float timerAnimation = 0;


	float timer = -10.0f;
	public const float animDuration = 3.0f; //0.5f; //TODO: <--

	Global gl;

	// Use this for initialization
	void Start () {
		gl = GameObject.Find ("ScriptGlobal").GetComponent<Global> ();
	}

	void AnimationFinished() {
		GameObject.Find ("LlenadoCeraUnique").SetActive(false);
		gl.GameObjectFinder ("Llave").SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (timer != -10.0f && Time.time - timer <= animDuration) {
			Debug.Log ("Animacion termino, duro " + animDuration.ToString () + "segundo/s");
			timer = -10.0f;
			Global.StaticGameObjectFinder("Vela prendida").transform.GetChild(0).gameObject.SetActive(false); //LlenadoCeraUnique debe estar en index 0 !important
			gl.GameObjectFinder ("Llave").SetActive (true); //TODO: <--
			Debug.Log("hey, it worked!");
		}*/
		Animator an = Global.StaticGameObjectFinder ("Vela prendida").GetComponent<Animator> ();
		if (an.recorderStartTime != -1 && timer != -10) {
			if (Time.time - timer >= animDuration) {
				Debug.Log ("Animacion termino, duro " + animDuration.ToString () + "segundo/s");
				timer = -10.0f;
				Global.StaticGameObjectFinder ("Vela prendida").transform.GetChild (0).gameObject.SetActive (false); //LlenadoCeraUnique debe estar en index 0 !important
				gl.GameObjectFinder ("Llave").SetActive (true);
				gl.GameObjectFinder("LlenadoCeraUnique").SetActive(false);
				Debug.Log ("hey, it worked!");
				Global.StaticGameObjectFinder ("Vela prendida").GetComponent<Animator> ().StopRecording();
				Global.StaticGameObjectFinder ("Vela prendida").GetComponent<Clicked>().enabled = false;
			}
		}
		/*timerAnimation = timerAnimation - Time.time;
		if (timerAnimation <= 2.1f && timerAnimation >= 1.9f)
			AnimationFinished ();*/
		/*******************************************************************************************************************
		/** ************************************************** DEBUGGING ***************************************************
		/** if (previousPosition != gl.GameObjectFinder("lasers").transform.position)                                   //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserss Positions");      //**
		/** if(!gl.GameObjectFinder("lasers").activeSelf)                                                               //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - lasers ActiveSelf");      //**
		/** if(!gl.GameObjectFinder("lasers").activeInHierarchy)                                                        //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserss Hierarchy");      //**
		/** if(!gl.GameObjectFinder("Laser Azul").activeSelf)                                                           //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserrr Azul Self");      //**
		/** if(!gl.GameObjectFinder("Laser Azul").activeInHierarchy)                                                    //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserrr Azul Hier");      //**
		/** if(!gl.GameObjectFinder("Laser Rojo").activeSelf)                                                           //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserrr Rojo Self");      //**
		/** if(!gl.GameObjectFinder("Laser Rojo").activeInHierarchy)                                                    //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserrr Rojo Hier");      //**
		/** if(!gl.GameObjectFinder("Laser Verde").activeSelf)                                                          //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserrr Verd Self");      //**
		/** if(!gl.GameObjectFinder("Laser Verde").activeInHierarchy)                                                   //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserrr Verd Hier");      //**
		/** if(!gl.GameObjectFinder("Laser").activeSelf)                                                                //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserrr Cast Self");      //**
		/** if(!gl.GameObjectFinder("Laser").activeInHierarchy)                                                         //**
		/**     Debug.Log("AHA!!! I FOUND YOU BUG! NOW YOU SHALL PERISH IN UNLIMITED AGONY! - laserrr Cast Hier");      //**
		/** ************************************************** DEBUGGING *************************************************** 
		*******************************************************************************************************************/
	}

	void OnMouseDown(){
		GameObject global = GameObject.Find ("ScriptGlobal");
		Global sglob = global.GetComponent<Global> ();
		InventorySystem invs = GameObject.Find("ScriptGlobal").GetComponent<InventorySystem> ();

		switch (this.name) {
		case "Placa":
				if (invs.IsInInventory ("Llave") && sglob.Selected == "Llave") {
					GameObject key = gl.GameObjectFinder ("Llave");
					GameObject newPos = gl.GameObjectFinder ("KeyHolder");
					key.transform.parent = newPos.transform.parent;
					key.transform.position = newPos.transform.position;
					key.transform.rotation = newPos.transform.rotation;
					key.GetComponent<Clicked>().enabled = false;
					key.GetComponent<InventorySystem>().enabled = false;
					sglob.Selected = "Llave";
					objetoquevaalpresionarse = gl.GameObjectFinder("Llave");
					Messenger.Message("MUY BIEN!!!", 0.01f, Color.green, true, true);
				} else {
					Messenger.Message("Necesitas una llave para abrir esto", 0.01f, Color.red, true, false);
					Debug.Log ("You need a key to open this.");
				}
			break;
		case "LlaveHole":
				if (invs.IsInInventory ("Vela prendida") && sglob.Selected == "Vela prendida") {
					//gl.GameObjectFinder ("Llave").SetActive (true); //TODO: <--
					sglob.Selected = "Vela prendida";
					objetoquevaalpresionarse = gl.GameObjectFinder("Vela prendida");
					GameObject vp = gl.GameObjectFinder("Vela prendida");
					vp.SetActive(true);
					vp.GetComponent<Clicked>().enabled = false;
					//sglob.SacardelInventario(vp.name);
					//sglob.desobjeto(vp.name);
					//vp.transform.position = Posiciondelobjetonuevo;
					Debug.Log(vp.transform.position.ToString() + "0333");
					//vp.transform.GetChild(0).gameObject.SetActive(true); //Este es el plano de LlenadoCeraUnique ("LlenadoCeraUnique"). DEJAR SIEMPRE EN INDEX 0 !important
					gl.GameObjectFinder("LlenadoCeraUnique").SetActive(true);	
					vp.GetComponent<Animator>().SetBool("openNow", true);
					Debug.Log("aiofhasfhasuioh " + vp.GetComponent<Animator>().GetBool("openNow").ToString());
					timerAnimation = Time.time;
					//UNITY ANIMATION ENDER
					//Debug.Log ("unity sucks " + vp.GetComponent<Animator>().playbackTime.ToString()); //TODO: <--
					timer = Time.time; //TODO: <--
					vp.GetComponent<Animator>().StartRecording(0);
					//UNITY ANIMATION ENDER
					vp.transform.position = GameObject.Find("VelaPrendidaHolder").transform.position;
					vp.transform.rotation = GameObject.Find("VelaPrendidaHolder").transform.rotation;
					vp.transform.localScale = GameObject.Find("VelaPrendidaHolder").transform.localScale;
					Messenger.Message("MUY BIEN!!!", 0.01f, Color.green, true, true);
				} else {
					Messenger.Message("Necesitas una vela y fuego.", 0.01f, Color.red, true, false);
					Debug.Log ("You need a fire and some wax.");
				}
			break;
		case "Cabeza":
			//Debug.Log(invs.IsInInventory ("lasers juntos").ToString() + "; " + sglob.Selected + ";");
			Debug.Log("Lasers position before activating: " + gl.GameObjectFinder("lasers").transform.position.ToString());
			if (invs.IsInInventory ("lasers juntos") && sglob.Selected == "lasers juntos") {
				gl.GameObjectFinder ("lasers").SetActive (true);
				sglob.Selected = "lasers juntos";
				objetoquevaalpresionarse = gl.GameObjectFinder("lasers juntos");
				GameObject ls = gl.GameObjectFinder("lasers");
				ls.SetActive(true);
				Posiciondelobjetonuevo = ls.transform.localPosition;
				gl.GameObjectFinder("lasers").SetActive(true); //PORQUE NO ANDASSSSSSS??????
				/*while (!ls.activeSelf)
					ls.SetActive(true);*/
				//Debug.Log("Next laser position: " + Posiciondelobjetonuevo.ToString() + "; Supposed: " + ls.transform.localPosition.ToString() + ";");
				//Debug.Log(ls.transform.position.ToString() + "0352");
				Debug.Log("Lasers position after activating: " + gl.GameObjectFinder("lasers").transform.position.ToString());
				Messenger.Message("MUY BIEN!!!", 0.01f, Color.green, true, true);
			} else {
				Debug.Log ("You need the lasers.");
				Messenger.Message("Necesitas 3 lasers.", 0.01f, Color.red, true, false, true);
			}
			break;
		case "Computadora":
			if (invs.IsInInventory ("CD") && sglob.Selected == "CD") {
				GameObject cd = gl.GameObjectFinder ("CD");
				GameObject newPos = gl.GameObjectFinder ("Computadora");
				cd.transform.parent = newPos.transform.parent;
				cd.transform.position = newPos.transform.position;
				cd.transform.rotation = newPos.transform.rotation;
				cd.GetComponent<Clicked>().enabled = false;
				cd.GetComponent<InventorySystem>().enabled = false;
				cd.SetActive(false);
				sglob.Selected = "CD";
				candadito.active = true;
				gl.GameObjectFinder("pantallaComp").transform.GetChild(0).gameObject.SetActive(true);
				gl.GameObjectFinder("pantallaComp").transform.GetChild(1).gameObject.SetActive(true);
				objetoquevaalpresionarse = gl.GameObjectFinder("CD");
			} else {
				Messenger.Message("Hmm, necesito un CD para esto...", 0.01f, Color.red, true, false);
				Debug.Log ("Hmm, there should be a CD for this...");
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
				sc.visible = true;
			} catch {}
		} 
	}
	
}