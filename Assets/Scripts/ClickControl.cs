using UnityEngine;
using System.Collections;

public class ClickControl : MonoBehaviour {

	float doubleClickStart = -1;
	bool doubleClickHelper = true;

	public GameObject go;

	Clicked clickedobject;
	Global gl;
	PlayAnimations pa;
	InventorySystem ins;
	ZoomInOut zio;

	// Use this for initialization
	void Start () {
		clickedobject = this.GetComponent<Clicked> ();
		gl = GameObject.Find ("ScriptGlobal").GetComponent<Global> ();
		pa = this.GetComponent<PlayAnimations> ();
		ins = this.GetComponent<InventorySystem> ();
		zio = this.GetComponent<ZoomInOut> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Salir al menu
		if (Input.GetKey (KeyCode.Escape))
			Application.LoadLevel ("Menu");

		//Single clicking
		if (doubleClickStart != -1 && Time.time - doubleClickStart > 0.5f && doubleClickHelper) {
			//Single click code HERE!
			if (go.tag == "Animated" || go.tag == "caja partes") {
				try {
					pa.RunAnimation(go);
				} catch {
					Debug.Log("This object (" + this.ToString() + ") is not animated into.");
				}
			} else {
				try {
					ins.ManageInventory(go);
				} catch {
					Debug.Log("This object (" + this.ToString() + ") cannot be inventored into.");
				}
			}
			doubleClickStart = -1;
			Debug.Log ("Single click!");
		}
	}

	void OnMouseUp() {
		Debug.Log("yey (" + go.ToString() + "was LEFT clicked)");
		if ((Time.time - doubleClickStart) < 0.3f)
		{
			this.OnDoubleClick();
			doubleClickStart = -1;
			doubleClickHelper = true;
		}
		else
		{
			doubleClickStart = Time.time;
		}
	}
	
	void OnDoubleClick()
	{
		doubleClickHelper = false;
		if (Global.camMoving) {
			Debug.Log ("Camera is already moving. Please wait for it to finish.");
		} else {
			try {
				this.GetComponent<ZoomInOut> ().moving = true;
				Global.camMoving = true;
				zio.Zoom (go);
			} catch {
				Debug.Log("This object (" + this.ToString() + ") cannot be zoomed into.");
			}
		}
	}
}
