using UnityEngine;
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

	public string[,] unitingMatrix = new string[3,4];

	public bool[] stateHolders;

	public static bool camMoving = false;

	public static GameObject progress;



	public Texture2D cursorTextureLupa;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	void Awake() {
		//DontDestroyOnLoad (GameObjectFinder ("ScriptGlobal"));
		/*if (progress != null) {
			Destroy(GameObject.Find("ScriptGlobal"));
			progress.name = "ScriptGlobal";
			Debug.Log("Progress loaded.");
		}*/

	}

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
		unitingMatrix[0,3] = "Libro";
		unitingMatrix[1,3] = "llave libro";
		unitingMatrix[2,3] = "LibroLlave";
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
		try {
			int i = 0;
			while (Inventario[i] != nombre)
				i++;
			Inventario [i] = "";
			holdersGO [i] = null;
		} catch {}
	}

	public string Unite(string A, string B) {
		string res="";
		FillUnitingMatrix ();
		for (int i = 0; i < unitingMatrix.GetLength(1); i++) {
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
				if (nuevoobjeto != "") {
					//borro imagen, deshabilito botones
					Inventario[nume] = "";
					Inventario[nume2] = "";
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
		try {
			int num = 0;
			for (int i = 0; i < 5; i++)
				if (objeto == Inventario[i])
					num = i + 1;
			GameObject Carlos = GameObject.Find("Inventario " + num.ToString());
			UnityEngine.UI.Button but = Carlos.GetComponent<UnityEngine.UI.Button>();
			but.interactable = false;
			but.image.sprite = default(Sprite);
		} catch {}

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

	public static GameObject StaticGameObjectFinder(string name) {
		GameObject go = new GameObject ("unique");
		go.AddComponent<Global> ();
		GameObject goR = go.GetComponent<Global> ().GameObjectFinder (name);
		Destroy (go);
		try {
			Destroy(GameObject.Find("unique"));
		} catch {}
		return goR;
	}

	public bool IsNear (Transform obj, Transform destiny, float nearFactor) {
		return ((obj.position.x - destiny.position.x <= nearFactor
			&& obj.position.y - destiny.position.y <= nearFactor
			&& obj.position.z - destiny.position.z <= nearFactor)
			&& (obj.position.x - destiny.position.x >= -nearFactor
			&& obj.position.y - destiny.position.y >= -nearFactor
			&& obj.position.z - destiny.position.z >= -nearFactor));
	}

	public void ClearTurnFlags () {
		GameObject[] gameobjs = GetAllGameObjectsChilds (GameObject.Find ("ScriptGlobal")).ToArray ();
		foreach (GameObject go in gameobjs) {
			try {
				DragTurn DT = go.GetComponent<DragTurn>();
				if (DT.isRotating || DT.mayRotate || DT.timer != -1)
					Debug.Log("A Turn Flag was Cleared.");
				DT.isRotating = false;
				DT.mayRotate = false;
				DT.timer = -1;
			} catch {}
		}
	}
}
