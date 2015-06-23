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
			if (isDragging && Input.GetMouseButton (0)) {
				theSpeed = new Vector3 (-Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"), 0.0F);
				avgSpeed = Vector3.Lerp (avgSpeed, theSpeed, Time.deltaTime * 5);
			} else {
				if (isDragging) {
					theSpeed = avgSpeed;
					isDragging = false;
				}
				float i = Time.deltaTime * lerpSpeed;
				theSpeed = Vector3.Lerp (theSpeed, Vector3.zero, i);
			}
			transform.Rotate (Camera.main.transform.up * theSpeed.x * rotationSpeed, Space.World);
			transform.Rotate (Camera.main.transform.right * theSpeed.y * rotationSpeed, Space.World);
			if (Input.GetMouseButton(1)) {
				sg.Orbit=false;
				//this.GetComponent<Renderer>().enabled=false;
				sg.GameObjectFinder(sg.nowOrbitingName).SetActive(false);
				sg.nowOrbitingName = "";
				//.gameObject.SetActive(false);
				c.GetComponent<Camera>().depth=-2;
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
		/* motivos por los que unity es una mierda:
		 * no funciona.
		 * nunca
		 * incentiva a la gente a no querer programar
		 * y al suicidio
		 * te obligan a usarlo para hacer juegos que no queres hacer
		 * etc
		 * :)
		 */
	}
}
