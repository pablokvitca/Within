using UnityEngine;
using System.Collections;

public class LoadSlidingBlocks : MonoBehaviour {

	public static bool active = false;

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
		if (LoadSlidingBlocks.active) {
			Messenger.Message("Saca el cubo rojo", 0.01f, Color.yellow, true, true);
			Application.LoadLevelAdditive("SB");
			LoadSlidingBlocks.active = false;
			this.GetComponent<LoadSlidingBlocks>().enabled = false;
			this.GetComponent<BoxCollider>().enabled = false;
			Debug.Log("THIS SCRIPT WAS DISABLED! HURRAY!");
		}
	}
}
