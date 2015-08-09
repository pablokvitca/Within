using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public static void changeScene(string sceneName) {
		if (Application.loadedLevelName != sceneName)
			Application.LoadLevel(sceneName);
	}

	public static void ReloadScene(string sceneName) {
		Application.LoadLevel(Application.loadedLevelName);
	}

	public static void AddScene(string sceneName) {
		Application.LoadLevelAdditive(sceneName);
	}
}