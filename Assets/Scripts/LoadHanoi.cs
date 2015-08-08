using UnityEngine;
using System.Collections;

public class LoadHanoi : MonoBehaviour {

	void OnMouseUp() {
		Application.LoadLevelAdditive("HANOI");
		this.GetComponent<LoadSlidingBlocks>().enabled = false;
		Debug.Log("THIS SCRIPT WAS DISABLED! HURRAY!");
	}
}
