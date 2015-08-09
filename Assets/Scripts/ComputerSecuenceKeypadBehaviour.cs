using UnityEngine;
using System.Collections;

public class ComputerSecuenceKeypadBehaviour : MonoBehaviour {

	public int n;

	void OnMouseUp() {
		if (candadito.active && n < 10) candadito.Add(n) ;
		else if (candadito.active && n == 10) candadito.Del();
		else if (candadito.active && n == 11) 
		if (candadito.Check())  {
			Messenger.Message("MUY BIEN!!!", 0.1f, Color.green, true, true);
			candadito.Door();
			candadito.active = false;
		}
	}
}
