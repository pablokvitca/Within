using UnityEngine;
using System.Collections;

public class MoveHorizontally : MonoBehaviour {
	bool Clicked =false;
	float Hor;
	public float rapidez;

	// Use this for initialization
	void Start () {
	
	}
	void OnMouseDown(){
		Clicked = true;
		Hor = Input.mousePosition.x;
	}
	void OnMouseUp(){
		Clicked = false;
		Hor=0;
	}
	// Update is called once per frame
	void Update () {
		if (Clicked) {
			if (Input.mousePosition.x -Hor>700)
			{

				this.transform.position = new Vector3 (this.transform.position.x - rapidez, this.transform.position.y, this.transform.position.z);
				Hor = this.transform.position.x;
			}
			else
			{
				if (Input.mousePosition.x-Hor <700){
					this.transform.position = new Vector3(this.transform.position.x+rapidez, this.transform.position.y, this.transform.position.z);	
				Hor=this.transform.position.x;
				}
			}
		}

	}
}
