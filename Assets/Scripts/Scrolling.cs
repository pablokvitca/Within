using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	public GameObject flr;
	public GameObject[] elementos;
	public float creditsDelay = 5.0f;
	public float creditsTime = 5.0f;
	public float creditsSpeed = 0.2f;

	// Update is called once per frame
	void Update () {
	
		creditsDelay -= Time.deltaTime;

		if (creditsDelay < 0) 
		{
			creditsTime -= Time.deltaTime;
		}
		if (creditsTime < 0) {

			foreach (GameObject element in elementos)
			{
				if (flr.transform.position.y < 0.5f){

					element.transform.Translate (Vector3.up * Time.deltaTime * creditsSpeed);

				}
			}
		}

		if(Input.GetMouseButtonDown(1)) {
			ChangeScene.changeScene("Menu");
		}

	}
}
