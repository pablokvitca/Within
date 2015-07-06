using UnityEngine;
using System.Collections;

public class MoveVertically : MonoBehaviour {

	bool Clicked =false;
	float Hor;
	public float rapidez;
	
	// Use this for initialization
	void Start () {
		
	}
	void OnMouseDown(){
		Clicked = true;
		Hor = Input.mousePosition.z;

	}
	void OnMouseUp(){
		Clicked = false;
		Hor=0;
	}
	// Update is called once per frame
	void Update () {
		if (Clicked) {
			if (Input.mousePosition.y -Hor>300)
			{
				
				this.transform.position = new Vector3 (this.transform.position.x , this.transform.position.y, this.transform.position.z- rapidez);
				Hor = this.transform.position.z;
			}
			else
			{
				if (Input.mousePosition.y-Hor <300){
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+rapidez);	
					Hor=this.transform.position.z;
				}
			}
		}
		
	}
}
