using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	public GameObject flr;
	public GUIText[] elementos;
	public float creditsDelay = 5.0f;
	public float creditsTime = 5.0f;
	public float creditsSpeed = 0.2f;

	void Start () {

		//flr = GameObject.Find ("Filler");

	}
	
	// Update is called once per frame
	void Update () {
	
		creditsDelay -= Time.deltaTime;

		if (creditsDelay < 0) 
		{
			creditsTime -= Time.deltaTime;
		}
		if (creditsTime < 0) {

			foreach (GUIText text in elementos)
			{
				if (flr.transform.position.y < 0.5f){

				text.transform.Translate (Vector3.up * Time.deltaTime * creditsSpeed);

				}
			}
		}

	}
}
