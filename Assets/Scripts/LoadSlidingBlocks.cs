using UnityEngine;
using System.Collections;

public class LoadSlidingBlocks : MonoBehaviour {

	public bool active = false;

	void OnMouseUp() {
		/*if (active) {
			Global.progress = GameObject.Find("ScriptGlobal");
			Debug.Log("Global.progress now contains: " + Global.progress.ToString() + "; with " + Global.progress.transform.childCount.ToString() + " child/children.");
			DontDestroyOnLoad(Global.progress);
			Application.LoadLevel ("SB");
			Debug.Log("Sliding Blocks Loaded");
			active = false;
			this.GetComponent<LoadSlidingBlocks>().enabled = false;
			Debug.Log("THIS SCRIPT WAS DISABLED! HURRAY!");
		}*/
		if (active) {
			Application.LoadLevelAdditive("SB");
			active = false;
			this.GetComponent<LoadSlidingBlocks>().enabled = false;
			Debug.Log("THIS SCRIPT WAS DISABLED! HURRAY!");
		}
	}
}
