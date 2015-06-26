using UnityEngine;
using System.Collections;

public class Helps : MonoBehaviour {

	public GameObject planito;
	public Material[] materials;
	public Transform transformacion;
	public int matPos;
	bool click = false;

	//For Animation
	public float max = 2.0f;
	public float speed = 0.001f;
	private Vector3 starting;
	private bool goingUp = true;

	// Use this for initialization
	void Start () {
		starting = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//planito.transform.position = transform.position;
		//planito.transform.rotation = transform.rotation;
		//planito.transform.localScale = transform.localScale;
		if (click) {
			planito.SetActive(true);
			//planito.transform.GetChild(0).GetComponent<GUIText>().text = parsear(this.GetComponent<GUIText>().text);
			//planito.GetComponent<Renderer>().material = materials[matPos];
		} 
		else 
		{
			planito.SetActive(false);
		}
		if (Input.GetKey (KeyCode.S)) {
			click = false;
		}

		//AnimateHelp
		AnimateHelp ();
	}

	void AnimateHelp() {
		if (goingUp)
			this.transform.position += new Vector3(0, speed, 0);
		else
			this.transform.position -= new Vector3(0, speed, 0);
		if (this.transform.position.y - starting.y >= max)
			goingUp = false;
		if (this.transform.position.y - starting.y < 0)
			goingUp = true;
	}

	void OnMouseUp() {
		if (click)
			click = false;
		else {
			click = true;
			planito.GetComponent<Renderer> ().material = materials [matPos];

		}
	}

	string parsear(string A) {
		int contador = 0;
		string [] Palabras = new string[A.Length];
		Palabras = A.Split (new char[] { ' ' });
   		string texto = "";
    	for (int i = 0; i < Palabras.Length; i++) {
        	if (contador == 6) {
            	Palabras[i] = Palabras[i] + "/n";
            	contador = 0;
        	}
        	contador ++;
    	}
		string res = "";
		for (int i = 0; i < Palabras.Length; i++) {
			res += Palabras[i];
		}
		return res;
	}
}
