using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {

	Global glo;
	bool turned = false;

	// Use this for initialization
	void Start () {
		glo = GameObject.Find ("ScriptGlobal").GetComponent<Global>();
	}
	
	// Update is called once per frame
	void Update () {
		if (glo.IsNear (this.transform, glo.GameObjectFinder ("Hueco").transform, 0.25f)) {
			this.GetComponent<Clicked>().enabled = false;
			this.GetComponent<InventorySystem>().enabled = false;
			this.GetComponent<ClickControl>().enabled = false;
		}

		if (!turned && glo.IsNear (this.transform, glo.GameObjectFinder ("KeyHolder").transform, 1.0f) && 
		    (this.transform.rotation.y >= Quaternion.Euler(0f, 45f, 0f).y || this.transform.rotation.y <= Quaternion.Euler(0f, -45f, 0f).y)) {
			turned = true;
			glo.GameObjectFinder ("CAJA AN 1").GetComponent<Animator> ().SetBool ("openDrawer", true);
			Debug.Log("Opened box drawer");
		}
	}
}
