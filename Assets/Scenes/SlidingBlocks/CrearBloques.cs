using UnityEngine;
using System.Collections;

public class CrearBloques : MonoBehaviour {
	public int[,]Bloques = {
		{0, 0, 0, 0, 0, 0},
		{0, 0, 0, 6, 6, 5},
		{0, 2, 2, 6, 6, 5},
		{3, 3, 6, 6, 6, 0},
		{0, 5, 6, 3, 3, 0},
		{0, 5, 6, 0, 0, 0}
	};
	//int cv2 = 0;
	//float xv2 = 0;
	//float zv2 = 0;
	// Use this for initialization
	void Start () {
		/*for (int i=0; i<Bloques.GetLength(0); i++) {
			//verticales
			for (int e=0; e<Bloques.GetLength(1); e++){
				switch(Bloques[i,e])
				{
				case 5:
					if (cv2==0)
					{
						xv2 = i;
						zv2= e;
						cv2++;
					}
					else
					{

						xv2=0;
						zv2=0;
						cv2=0;
					}
					break;
				case 6:
					break;
				}
			}
		}*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
