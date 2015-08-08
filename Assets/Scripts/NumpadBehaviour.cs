using UnityEngine;
using System.Collections;

public class NumpadBehaviour : MonoBehaviour {

	private static int pos = 0;
	public int code;
	public GameObject display;

	void OnMouseDown() {
		if (pos < 6) {
			display.GetComponent<DisplayBehaveviour>().ChangeInput(pos, code);
			if (code >= 0 && code <= 9 && pos < 5)
				pos++;
			else if (code == 11)
				if (pos > -1)
					pos--;
				else Debug.Log("Code empty");
			else if (code == 10) Debug.Log("Code entered");
		} else Debug.Log("Display full");
	}
}
