using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class candadito : MonoBehaviour {
	
	private static int[] secuence = new int[10];
	private static int[] ingresado = new int[4];

	public static bool active = false;
	public static bool near = false;

	void Start () {
		secuence[0] = Random.Range(0, 9);
		secuence[1] = Random.Range(0, 9);
		secuence[2] = Collapse (secuence[0] + secuence[1]);
		secuence[3] = Collapse (secuence[1] + secuence[2]);
		secuence[4] = Collapse (secuence[2] + secuence[3]);
		secuence[5] = Collapse (secuence[3] + secuence[4]);
		secuence[6] = Collapse (secuence[4] + secuence[5]);
		secuence[7] = Collapse (secuence[5] + secuence[6]);
		secuence[8] = Collapse (secuence[6] + secuence[7]);
		secuence[9] = Collapse (secuence[7] + secuence[8]);
		this.GetComponent<TextMesh>().text = secuence[0].ToString() + secuence[1].ToString() + secuence[2].ToString() + secuence[3].ToString() + secuence[4].ToString() + secuence[5].ToString() + "----";
		ingresado [0] = 10;
		ingresado [1] = 10;
		ingresado [2] = 10;
		ingresado [3] = 10;
	}

	public static void Add(int n) {
		for(int i = 0; i <= 3; i++)
			if (ingresado[i] == 10) {
				ingresado[i] = n;
				break;
			}
	}

	// Update is called once per frame
	void Update () {
		if (candadito.active) {// && candadito.near) {
			this.GetComponent<TextMesh> ().text = secuence[0].ToString() 
												+ secuence[1].ToString() 
												+ secuence[2].ToString() 
												+ secuence[3].ToString() 
												+ secuence[4].ToString() 
												+ secuence[5].ToString() 
												+ ShowNum (ingresado[0]) 
												+ ShowNum (ingresado[1]) 
												+ ShowNum (ingresado[2]) 
												+ ShowNum (ingresado[3]);
			if (Input.GetKeyDown (KeyCode.Alpha0)) Add(0);
			if (Input.GetKeyDown (KeyCode.Alpha1)) Add(1);
			if (Input.GetKeyDown (KeyCode.Alpha2)) Add(2);
			if (Input.GetKeyDown (KeyCode.Alpha3)) Add(3);
			if (Input.GetKeyDown (KeyCode.Alpha4)) Add(4);
			if (Input.GetKeyDown (KeyCode.Alpha5)) Add(5);
			if (Input.GetKeyDown (KeyCode.Alpha6)) Add(6);
			if (Input.GetKeyDown (KeyCode.Alpha7)) Add(7);
			if (Input.GetKeyDown (KeyCode.Alpha8)) Add(8);
			if (Input.GetKeyDown (KeyCode.Alpha9)) Add(9);
			if (Input.GetKeyDown (KeyCode.Delete)) Del( );
			if (Check()) {
				Door();
				active = false;
			}
		}
		//if (candadito.active) candadito.near = IsNear(2.5f);
	}

	public static void Door() {
		//GameObject.Find("Puerta").GetComponent<DoorOpen>().Open("rycbar123");
		Application.LoadLevel("FIN");
	}

	public static void Del() {
		for (int i = 3; i >= 0; i--){
			if(ingresado[i] != 10)
				ingresado[i] = 10;
		}
	}

	public static void Clear() {
		for (int i = 0; i < ingresado.Length; i++)
			ingresado[i] = 10;
	}

	public static bool Check() {
		bool correct = true;
		for (int i = 0; i < ingresado.Length; i++)
			if (ingresado[i] != secuence[i+6])
				correct = false;
		return correct;
	}

	private bool IsNear(float near) {
		RaycastHit upHit, downHit, rightHit, leftHit, forwardHit, backHit;
		bool   up   = Physics.Raycast(Camera.main.transform.position,   Camera.main.transform.up     , out    upHit   , near);
		bool  down  = Physics.Raycast(Camera.main.transform.position, - Camera.main.transform.up     , out   downHit  , near);
		bool  right = Physics.Raycast(Camera.main.transform.position,   Camera.main.transform.right  , out  rightHit  , near);
		bool  left  = Physics.Raycast(Camera.main.transform.position, - Camera.main.transform.right  , out   leftHit  , near);
		bool foward = Physics.Raycast(Camera.main.transform.position,   Camera.main.transform.forward, out forwardHit , near);
		bool  back  = Physics.Raycast(Camera.main.transform.position, - Camera.main.transform.forward, out   backHit  , near);
		bool hitted = false;
		if (   up   && !hitted) hitted = (    upHit.transform.name   == "Computadora" );
		if (  down  && !hitted) hitted = (  downHit.transform.name   == "Computadora" );
		if (  right && !hitted) hitted = (  rightHit.transform.name  == "Computadora" );
		if (  left  && !hitted) hitted = (   leftHit.transform.name  == "Computadora" );
		if ( foward && !hitted) hitted = ( forwardHit.transform.name == "Computadora" );
		if (  back  && !hitted) hitted = (   backHit.transform.name  == "Computadora" );
		bool something = (up || down || right || left || foward || back);
		return (something && hitted);
	}

	private int Collapse(int x) {
		if (x.ToString().Length == 1) return x;
		return int.Parse(x.ToString().Substring(0,1)) + int.Parse(x.ToString().Substring(1,1));
	}

	private string ShowNum (int n){
		if (n == 10) return "-";
		else return n.ToString();
	}
}
