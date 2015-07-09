using UnityEngine;
using System.Collections;

public class Lasers : MonoBehaviour {

	public GameObject[] ReceptorPossiblePositions;
	public static Color[] colores = new Color[8];
	int laserColorInt = 0;

	public int maxCantHits = 6;
	public static int cantHits = 0;

	// Use this for initialization
	void Start () {
		colores[0] = Color.white;   //blanco
		colores[1] = Color.red;     //rojo
		colores[2] = Color.green;   //verde
		colores[3] = Color.blue;    //azul
		colores[4] = Color.cyan;    //cian
		colores[5] = Color.magenta; //magenta
		colores[6] = Color.yellow;  //amarillo
		colores[7] = Color.black;   //negro
		ChangeColor (GameObject.Find ("Receptor"));
		ChangePosition(GameObject.Find("Receptor"));

	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		//Debug.DrawLine (this.transform.position, Vector3.forward, Color.cyan);
		Vector3 direccion = transform.TransformDirection(Vector3.forward);

		this.GetComponent<LineRenderer>().SetColors(colores[btnLaserBehaviour.intResColor], colores[btnLaserBehaviour.intResColor]);
		this.GetComponent<LineRenderer> ().material.color = colores [btnLaserBehaviour.intResColor];

		if (cantHits <= maxCantHits) {
			if (Physics.Raycast (this.transform.position, direccion, out hit, Mathf.Infinity)) {
				if (hit.collider.gameObject.name == "Receptor") {
					GameObject go = GameObject.Find (hit.collider.gameObject.name);
					Debug.Log ("receptor: " + go.GetComponent<MeshRenderer> ().material.color.ToString () + "; laser: " + this.GetComponent<LineRenderer> ().material.color.ToString () + ";");
					if (go.GetComponent<MeshRenderer> ().material.color.ToString () == this.GetComponent<LineRenderer> ().material.color.ToString ()) {
						ChangePosition (go);
						ChangeColor (go);
						cantHits++;
						Debug.Log ("Targets agarrados: " + cantHits.ToString());
					}
				}
			}
		} else {
			this.GetComponent<LineRenderer>().enabled = false;
			//TODO: ONLY RUN THIS SCRIPT IF LASER IS ACTIVE
			//GameObject.Find("Receptor").SetActive(false);
			Global.StaticGameObjectFinder("Receptor").SetActive(false);
			OpenSlidingBlocks(); //Opens SlidingBlocks Cube
		}
	}

	void OpenSlidingBlocks() {
		//GameObject.Find ("SlidingBlocks").transform.localPosition = new Vector3 (3.7f, 1.15f, 5.0f);
		GameObject.Find ("SlidingBlocks").GetComponent<Animator> ().SetBool ("openNow", true);
		GameObject.Find ("SlidingBlocks").GetComponent<LoadSlidingBlocks>().active = true;
	}

	void ChangePosition(GameObject go) {
		//go.transform.position = ReceptorPossiblePositions[Random.Range(0, ReceptorPossiblePositions.Length - 1)].transform.position;
		NewPosition (go, this.gameObject);
	}

	Vector3 NewPosition(GameObject go, GameObject laser) {
		//Get min & max positions for the receptor to be inside the room
		//TODO: make it a little smaller.
		Debug.Log ("Left: "     +  GameObject.Find ( "LeftWall"  ).gameObject.transform.position.x +
		           "; Right: "  +  GameObject.Find ( "RightWall" ).gameObject.transform.position.x +
		           "; Top: "    +  GameObject.Find ( "Ceilling"  ).gameObject.transform.position.y +
		           "; Floor: "  +  GameObject.Find (   "Floor"   ).gameObject.transform.position.y +
		           "; Front: "  +  GameObject.Find ( "FrontWall" ).gameObject.transform.position.z +
		           "; Back: "   +  GameObject.Find ( "BackWall"  ).gameObject.transform.position.z + 
		           ";");
		Vector3 min = new Vector3 (GameObject.Find ( "LeftWall"  ).gameObject.transform.position.x, 
		                           GameObject.Find ( "Ceilling"  ).gameObject.transform.position.y, 
		                           GameObject.Find ( "FrontWall" ).gameObject.transform.position.z);
		Vector3 max = new Vector3 (GameObject.Find ( "RightWall" ).gameObject.transform.position.x, 
		                           GameObject.Find (   "Floor"   ).gameObject.transform.position.y, 
		                           GameObject.Find ( "BackWall"  ).gameObject.transform.position.z);
		//Creates RaycastHit object
		RaycastHit hit;
		//Places receptor in new random position inside min/max range
		go.transform.position = new Vector3 (Random.Range (min.x, max.x), Random.Range (min.y, max.y), Random.Range (min.z, max.z));
		//Creates new empry gameobject looking at receptor
		GameObject newGO = new GameObject ("newGO");
		newGO.AddComponent<Transform> ();
		newGO.transform.LookAt (go.transform.position);
		//Takes that gameobject's rotation in eulerAngles
		Vector3 dir = newGO.transform.rotation.eulerAngles;
		//Repeats the process till it finds a possible position. Up to 50 times, then dies to one of the manually pre-defined positions
		int dieCount = 50;
		while (!Physics.Raycast(laser.transform.position, dir, out hit, Mathf.Infinity)) {
			if (dieCount <= 0) {
				go.transform.position = new Vector3 (Random.Range (min.x, max.x), Random.Range (min.y, max.y), Random.Range (min.z, max.z));
				newGO.transform.LookAt (go.transform.position);
				dir = newGO.transform.position;
			} else {
				Debug.Log("Max try count reached. Died to pre-defined position.");
				go.transform.position = ReceptorPossiblePositions[Random.Range(0, ReceptorPossiblePositions.Length - 1)].transform.position;
				DestroyObject (newGO);
				return dir;
			}
			dieCount--;
		}
		//Destroys the new empty gamoobject
		DestroyObject (newGO);
		//Returns the direction (this return is not currently being used)
		return dir;
	}

	void ChangeColor(GameObject go) {
		go.GetComponent<MeshRenderer>().material.color = colores[Random.Range(0, colores.Length - 1)];
	}

	void ChangeColor(GameObject go, int color) {
		go.GetComponent<MeshRenderer>().material.color = colores[color];
	}
}
