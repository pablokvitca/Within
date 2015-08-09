using UnityEngine;
using System.Collections;

public class Clicked : MonoBehaviour {
	public Sprite sprite;
	public bool visible;
	public float rotationSpeed = 10.0F;
	public float lerpSpeed = 1.0F;
	public Vector3 theSpeed;
	public Vector3 avgSpeed;
	public bool isDragging = false;
	public Vector3 targetSpeedX;
	GameObject scriglo,scriglo2;
	Camera c;
	public Global sg;
	GameObject cm;
	Inven sg2;
	RotacionObjetos script;


	// Use this for initialization
	void Start () {
		visible = true;
		scriglo = GameObject.Find ("ScriptGlobal");
		sg = scriglo.GetComponent<Global> ();
		scriglo2 = GameObject.Find ("Inventario");
		sg2 = scriglo2.GetComponent<Inven> ();
		cm = GameObject.Find ("CamaraOrbit");
		c = cm.GetComponent<Camera> ();

	}
	// Update is called once per frame
		void Update () {
		if (sg.Orbit) {
			try {
				GameObject go = GameObject.Find (sg.nowOrbitingName);
				go.GetComponent<RotacionObjetos> ().enabled = true;
				if (sg.nowOrbitingName == "cajitaRojaSB")
					GameObject.Find(sg.nowOrbitingName).GetComponent<PlayAnimations>().enabled = true;
				//if (sg.nowOrbitingName == "Vela prendida")
				//	sg.GameObjectFinder("Vela prendida").transform.FindChild("LlenadoCeraUnique").gameObject.SetActive(false);
				if (Input.GetMouseButton (1)) {
					sg.Orbit = false;
					//this.GetComponent<Renderer>().enabled=false;
					sg.GameObjectFinder (sg.nowOrbitingName).SetActive (false);
					sg.nowOrbitingName = "";
					//.gameObject.SetActive(false);
					c.GetComponent<Camera> ().depth = -2;
					go.GetComponent<RotacionObjetos> ().enabled = false;
					//if (sg.nowOrbitingName == "Vela prendida")
					//	sg.GameObjectFinder("Vela prendida").transform.FindChild("LlenadoCeraUnique").gameObject.SetActive(true);
				}
			} catch {
			}
		}
	}
 	void OnMouseDown(){
		/*if (visible) {
			GameObject Inventario = GameObject.Find ("Inventario");
			Inven codigo = Inventario.GetComponent<Inven> ();
			codigo.AddGO (this.sprite);
			//this.gameObject.GetComponent<Renderer> ().enabled = false;
			this.gameObject.SetActive(false);
			GameObject global = GameObject.Find ("ScriptGlobal");
			Global sglob = global.GetComponent<Global> ();
			sglob.objetoarr (this.name);
			visible = false;	
		}
		if (sg.Orbit) {
			isDragging = true;

		}*/
	}
}
