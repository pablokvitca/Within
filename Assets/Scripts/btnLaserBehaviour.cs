using UnityEngine;
using System.Collections;

public class btnLaserBehaviour : MonoBehaviour {

	public static string resColor = "white";
	public static int intResColor = 0;
	private static bool[] isOn = new bool[3] {false, false, false};

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		resColor = ResultingColor ();
		intResColor = ColorStringToInt (resColor);
	}

	void OnMouseDown () {
		switch (this.name) {
		case "btnRed":
			isOn[0] = !isOn[0];
			/*if (isOn[0])
				this.transform.position = this.transform.GetChild(0).transform.position; //Unpress
			else
				this.transform.position = this.transform.GetChild(1).transform.position; //Pressed*/
			break;
		case "btnGreen":
			isOn[1] = !isOn[1];
			/*if (isOn[1])
				this.transform.position = this.transform.GetChild(0).transform.position; //Unpress
			else
				this.transform.position = this.transform.GetChild(1).transform.position; //Pressed*/
			break;
		case "btnBlue":
			isOn[2] = !isOn[2];
			/*if (isOn[2])
				this.transform.position = this.transform.GetChild(0).transform.position; //Unpress
			else
				this.transform.position = this.transform.GetChild(1).transform.position; //Pressed*/
			break;
		}
		Debug.Log ("Laser states are: red(" + isOn [0].ToString () + "); green(" + isOn [1].ToString () + "); blue(" + isOn [2].ToString () + ")");
	}

	public static string ResultingColor() {
		if (isOn [0] && isOn[1] && isOn[2]) //Red & Green & Blue
		    return "white";
		if (isOn [0] && isOn [1]) //Red & Green
			return "yellow";
		if (isOn [1] && isOn [2]) //Green & Blue
			return "cyan";
		if (isOn [2] && isOn [0]) //Blue & Red
			return "magenta";
		if (isOn [0]) //Only Red
			return "red";
		if (isOn [1]) //Only Green
			return "green";
		if (isOn [2]) //Only blue
			return "blue";
		return "black"; //None
	}

	public static int ColorStringToInt(string input) {
		switch (input) {
		case "white":
			return 0;
		case "red":
			return 1;
		case "green":
			return 2;
		case "blue":
			return 3;
		case "cyan":
			return 4;
		case "magenta":
			return 5;
		case "yellow":
			return 6;
		case "black":
		default:
			return 7;
		}
	}

	public static string ColorIntToString(int input) {
		switch (input) {
		case 0:
			return "white";
		case 1:
			return "red";
		case 2:
			return "green";
		case 3:
			return "blue";
		case 4:
			return "cyan";
		case 5:
			return "magenta";
		case 6:
			return "yellow";
		case 7:
		default:
			return "black";
		}
	}
}
