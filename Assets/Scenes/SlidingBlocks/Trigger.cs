using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	void OnTriggerEnter(Collider entra)
	{
		//Gano Sliding Blocks
		/*
		if (entra.tag == "TablaPeriodica") {
			Debug.Log ("Ganaste, sos re crack");
			Application.LoadLevel("lvl1");
		}
		*/

		if (entra.tag == "TablaPeriodica") {
			Debug.Log ("Ganaste, sos re crack!");
			try {
				Destroy(GameObject.Find("SBManager"));
				Debug.Log("Sucess in destroying SBManager :)");
				Global.StaticGameObjectFinder("cajitaRojaSB").SetActive(true);
				GameObject.Find("cajitaRojaSB").GetComponent<ClickControl>().ExternalCodeClick("up");
			} catch {
				Debug.Log("SH*T! I F*CK*NG HATE UNITY");
			}
		}
	}

}