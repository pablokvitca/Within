using UnityEngine;
using System.Collections;

public class OrbitZoom : MonoBehaviour {

	//to do: poner una cantidad maxima de zoom que se pueda hacer

	private float ZoomAmount = 0;
	private float MaxToClamp = 5;
	private float ROTSpeed = 5;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
			ZoomAmount += Input.GetAxis ("Mouse ScrollWheel");
			ZoomAmount = Mathf.Clamp (ZoomAmount, -MaxToClamp, MaxToClamp);
			var translate = Mathf.Min (Mathf.Abs (Input.GetAxis ("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs (ZoomAmount));
			gameObject.transform.Translate (0, 0, translate * ROTSpeed * Mathf.Sign (Input.GetAxis ("Mouse ScrollWheel")));
	
	}
}
