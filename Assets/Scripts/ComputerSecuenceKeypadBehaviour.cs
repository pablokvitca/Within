using UnityEngine;
using System.Collections;

public class ComputerSecuenceKeypadBehaviour : MonoBehaviour {

	public int n;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		if (candadito.active && n < 10) candadito.Add(n) ;
		else if (candadito.active && n == 10) candadito.Del();
		else if (candadito.active && n == 11) 
		if (candadito.Check())  {
			candadito.Door();
			candadito.active = false;
		}
	}
}
