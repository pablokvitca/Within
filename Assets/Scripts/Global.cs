﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour {
	public string[] Inventario = new string[5];
	public GameObject[] holdersGO = new GameObject[5];
	public string Selected;
	public string CombinadoBot;
	public bool Combinar;
	public int contarobj;
	public string Combinado;
	public bool Orbit;
	public string nowOrbitingName;

	public Vector3 posicioncubo = new Vector3 (-4.44f, 0.0f, -4.44f);

	public string[,] unitingMatrix = new string[3,3];

	public bool[] stateHolders;
	// Use this for initialization
	void Start () {
		FillUnitingMatrix ();
	}

	void FillUnitingMatrix() {
		unitingMatrix[0,0] = "Cajadefosforos";
		unitingMatrix[1,0] = "Fosforo";
		unitingMatrix[2,0] = "Fosforo prendido";
		unitingMatrix[0,1] = "Vela";
		unitingMatrix[1,1] = "Fosforo prendido";
		unitingMatrix[2,1] = "Vela prendida";
		unitingMatrix[0,2] = "Vela prendida";
		unitingMatrix[1,2] = "LlaveHole";
		unitingMatrix[2,2] = "Llave";
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void objetoarr (string nombre){
		int i = 0;
		while (Inventario[i]!="")
			i++;
		Inventario [i] = nombre;
		holdersGO [i] = GameObject.Find (nombre);
	}

	public void desobjeto (string nombre){
		int i = 0;
		while (Inventario[i]!=nombre)
			i++;
		Inventario [i] = "";
		holdersGO [i] = null;
	}

	public string Unite(string A, string B) {
		string res="";
		FillUnitingMatrix ();
		for (int i = 0; i < unitingMatrix.GetLength(0); i++) {
			if ((unitingMatrix[0, i] == A && unitingMatrix[1,i] == B) || (unitingMatrix[0, i] == B && unitingMatrix[1,i] == A))
				res= unitingMatrix[2,i];
		}
		return res;
	}

	public void Resolve (string nomm) {
		if (Orbit) {
			GameObject objeto = DevolverGO (nomm);
			Debug.Log(nomm + "0043");
			Debug.Log(objeto.name + "2111");
			if(nowOrbitingName != "")
				GameObjectFinder(nowOrbitingName).SetActive(false);
			/*if (objeto.name != "Vela") { //Cambiar a exists in list de NoOrbitables
				if (objeto.name != "Vela prendida") { //Unity compila mal, me obliga a hacer varios 'if' uno detro del otro
					if (objeto.name != "LlaveHole") { //En ves de usar, correctamente, '&&' u '||' dentro de un unico if
						nowOrbitingName = "";
						nowOrbitingName = objeto.name;
						objeto.gameObject.SetActive (true);
						GameObject cam = GameObject.Find ("CamaraOrbit");
						Camera camara = cam.GetComponent<Camera> ();
						camara.GetComponent<Camera> ().depth = 5;
						GameObject o = GameObject.Find ("Orbiting");
						Debug.Log(objeto.transform.position.ToString());
						Debug.Log(o.transform.position.ToString());
						objeto.transform.position = o.transform.position;
						//objeto.GetComponent<Renderer>().enabled=true;
						Debug.Log (objeto.gameObject.transform.position.ToString() + "2058");
					} else {
						Debug.Log ("Este objeto no se puede orbitar. Lo sentimos.");
					}
				} else {
					Debug.Log ("Este objeto no se puede orbitar. Lo sentimos.");
				}
			} else {
				Debug.Log ("Este objeto no se puede orbitar. Lo sentimos.");
			}*/
			if (objeto.name == "Vela" || objeto.name == "Vela prendida" || objeto.name == "LlaveHole") {
				Debug.Log ("Este objeto no se puede orbitar. Lo sentimos.");
			} else {
				nowOrbitingName = "";
				nowOrbitingName = objeto.name;
				objeto.gameObject.SetActive (true);
				GameObject cam = GameObject.Find ("CamaraOrbit");
				Camera camara = cam.GetComponent<Camera> ();
				camara.GetComponent<Camera> ().depth = 5;
				GameObject o = GameObject.Find ("Orbiting");
				Debug.Log(objeto.transform.position.ToString());
				Debug.Log(o.transform.position.ToString());
				objeto.transform.position = o.transform.position;
				//objeto.GetComponent<Renderer>().enabled=true;
				Debug.Log (objeto.gameObject.transform.position.ToString() + "2058");
			}
		}
		if (Combinar) {
			if (contarobj==1) {
				GameObject bot = GameObject.Find(nomm);
				NumInt numint = bot.GetComponent<NumInt>();
				int nume = numint.numarray;
				//bot = GameObject.Find(Combinado);
				bot = GameObjectFinder(Combinado);
				numint = bot.GetComponent<NumInt>();
				int nume2 = numint.numarray;
				string nuevoobjeto = Unite(Inventario[nume2], Inventario[nume]);
				if (nuevoobjeto!="") {
					//borro imagen, deshabilito botones
					Inventario[nume]="";
					Inventario[nume2]="";
					//GameObject Inventario2 = GameObject.Find (Combinado);
					GameObject Inventario2 = GameObjectFinder(Combinado);
					UnityEngine.UI.Button btn = Inventario2.GetComponent<UnityEngine.UI.Button> ();
					btn.interactable=false;
					btn.image.sprite=default(Sprite);
					//Inventario2 = GameObject.Find (nomm);
					Inventario2 = GameObjectFinder(nomm);
					btn = Inventario2.GetComponent<UnityEngine.UI.Button> ();
					btn.interactable=false;
					btn.image.sprite=default(Sprite);
					Selected="";
					//pego
					//GameObject objeton = GameObject.Find(nuevoobjeto);
					GameObject objeton = GameObjectFinder(nuevoobjeto);
					//GameObject Inventario1 = GameObject.Find("Inventario");
					GameObject Inventario1 = GameObjectFinder("Inventario");
					Clicked getspr = objeton.GetComponent<Clicked>();
					Inven codigo = Inventario1.GetComponent<Inven> ();
					Sprite sprite = getspr.sprite;
					objetoarr(nuevoobjeto);
					codigo.AddGO (sprite);
					//place vela & animate
					if (nuevoobjeto == "Llave") { // Esto esta feo
						GameObjectFinder("Vela prendida").SetActive(true);
						Debug.Log(GameObjectFinder("Vela prendida").transform.position.ToString() + "0333");
						GameObjectFinder("Vela prendida").GetComponent<Animator>().SetBool("openNow", true);
						//Esconder vela dsp de animacion
					}
					getspr.visible=false;
					contarobj=0;
					Combinado="";
					Combinar=false;
				}
				else {
					Combinar=false;
					Combinado="";
					contarobj=0;
				}
			}
			else {
				contarobj++;
				Combinado=nomm;
			}
		}
	}

	public void SacardelInventario(string objeto) {
		int num = 0;
		for (int i=0; i<5; i++) {
			if (objeto == Inventario[i])
				num=i+1;
		}
		GameObject Carlos;

			Carlos=GameObject.Find("Inventario " + num.ToString());
			
				UnityEngine.UI.Button but = Carlos.GetComponent<UnityEngine.UI.Button>();
				but.interactable=false;
				but.image.sprite = default(Sprite);
			

	}

	public GameObject DevolverGO (string boto){
		GameObject botin=GameObjectFinder(boto);
		NumInt n = botin.GetComponent <NumInt>();
		int e = n.numarray;
		Debug.Log (Inventario [e]);
		//GameObject ob = GameObject.Find (Inventario [e]);
		//GameObject ob = holdersGO [e];
		GameObject ob = GameObjectFinder (Inventario [e]);
		return ob;
	}

	public List<GameObject> GetAllGameObjectsChilds(GameObject parent) {
		List<GameObject> GOList = new List<GameObject> ();
		for (int j = 0; j < parent.transform.childCount; j++) {
			GOList.Add (parent.transform.GetChild(j).gameObject);
			GOList.AddRange(GetAllGameObjectsChilds(parent.transform.GetChild(j).gameObject));
		}
		return GOList;
	}

	public GameObject GameObjectFinder(string name) {
		/*GameObject[] gameobjs = new GameObject[GameObject.Find("ScriptGlobal").transform.childCount];
		for (int j = 0; j < gameobjs.Length; j++) {
			gameobjs[j] = GameObject.Find("ScriptGlobal").transform.GetChild(j).gameObject;
		}*/
		GameObject[] gameobjs = GetAllGameObjectsChilds (GameObject.Find ("ScriptGlobal")).ToArray ();
		stateHolders = new bool[gameobjs.Length];
		int i = 0;
		foreach (GameObject go in gameobjs) {
			stateHolders[i] = go.activeSelf;
			go.SetActive(true);
			i++;
		}
		GameObject found = GameObject.Find (name);
		i = 0;
		foreach (GameObject go in gameobjs) {
			go.SetActive(stateHolders[i]);
			i++;
		}
		return found;
	}
}