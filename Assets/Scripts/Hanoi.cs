﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hanoi : MonoBehaviour {

	private static Stack<int>[] postes = new Stack<int>[3] { new Stack<int>(), new Stack<int>(), new Stack<int>()};
	private static Stack<int> objective = new Stack<int>();
	public int post;
	private static int click1 = -1;
	private static int click2 = -1;
	private static int hover = -1;
	public GameObject disc1;
	public GameObject disc2;
	public GameObject disc3;
	public GameObject disc4;
	public Light p0;
	public Light p1;
	public Light p2;
	public Light p0b;
	public Light p1b;
	public Light p2b;

	public static bool active = false;

	private static bool won = false;

	// Use this for initialization
	void Awake () {
		if (objective.Count == 0) {
			objective.Push(5);
			objective.Push(4);
			objective.Push(3);
			objective.Push(2);
			objective.Push(1);
		}
		if (postes[0].Count == 0) {
			postes[0].Push(5);
			postes[0].Push(4);
			postes[0].Push(3);
			postes[0].Push(2);
			postes[0].Push(1);
		}
		if (postes[1].Count == 0) {
			postes[1].Push(5);
			//postes[1].Push(4);
			//postes[1].Push(3);
			//postes[1].Push(2);
			//postes[1].Push(1);
		}
		if (postes[2].Count == 0) {
			postes[2].Push(5);
			//postes[2].Push(4);
			//postes[2].Push(3);
			//postes[2].Push(2);
			//postes[2].Push(1);
		}
	}

	void OnMouseEnter() {
		Hanoi.hover = post;
	}

	void OnMouseExit() {
		Hanoi.hover = -1;
	}

	void Lights() {
		switch (click1) {
		case 0:
			p0.enabled = true;
			p1.enabled = false;
			p2.enabled = false;
			break;
		case 1:
			p0.enabled = false;
			p1.enabled = true;
			p2.enabled = false;
			break;
		case 2:
			p0.enabled = false;
			p1.enabled = false;
			p2.enabled = true;
			break;
		default:
			p0.enabled = false;
			p1.enabled = false;
			p2.enabled = false;
			break;
		}
		switch (hover) {
		case 0:
			p0b.enabled = true;
			p1b.enabled = false;
			p2b.enabled = false;
			break;
		case 1:
			p0b.enabled = false;
			p1b.enabled = true;
			p2b.enabled = false;
			break;
		case 2:
			p0b.enabled = false;
			p1b.enabled = false;
			p2b.enabled = true;
			break;
		default:
			p0b.enabled = false;
			p1b.enabled = false;
			p2b.enabled = false;
			break;
		}
		if (Hanoi.won) {
			p0.enabled = true;
			p1.enabled = true;
			p2.enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
		Lights();
		if (active) {
			postes[0].TrimExcess();
			postes[1].TrimExcess();
			postes[2].TrimExcess();
			if (IsCorrect() && !Hanoi.won) {
				//CD
				GameObject.Find("CD").GetComponent<ClickControl>().OnSingleClick();
				Messenger.Message("MUY BIEN!!!", 0.1f, Color.green, true, true);
				Debug.Log("Hanoi won!");
				Hanoi.won = true;
			}
		}
	}

	bool IsCorrect() {
		postes[2].TrimExcess();
		objective.TrimExcess();
		int[] a = postes[2].ToArray();
		int[] b = objective.ToArray();
		//Stack<int> tempA = postes[2];
		//Stack<int> tempB = objective;
		if (postes[2].Count > 4)
			return (a[0] == b[0] && a[1] == b[1] && a[2] == b[2] && a[3] == b[3]);
		else
			return false;
	}

	void OnMouseDown() {
		if (click1 == -1)
			click1 = post;
		else
			click2 = post;
		if (click1 == click2) {
			click1 = -1;
			click2 = -1;
		}
		if (click1 != -1 && click2 != -1)
			MoveDisc(click1, click2);
	}

	private void MoveDisc(int post, int dest) {
		if (CanDiscMove(post, dest)) {
			Animate(post, dest, GameObject.Find("HanoiDisc" + postes[post].Peek().ToString()));
			postes[dest].Push(postes[post].Pop());
		}
		click1 = -1;
			click2 = -1;
	}

	private void Animate(int post, int dest, GameObject disc) {
		GoUp(disc);
		GoRightLeft(disc, GameObject.Find("HanoiPoste" + dest.ToString()));
		GoDown(disc, dest);
	}

	private void GoUp(GameObject disc) {
		disc.transform.position += new Vector3(0, 10, 0);
	}

	private void GoDown(GameObject disc, int dest) {
		//disc.transform.position -= new Vector3(0, 10, 0);
		//RaycastHit hit;
		//Physics.Raycast (disc.transform.position, -disc.transform.up, out hit, 30.0f);
		//disc.transform.position -= new Vector3(0, hit.distance, 0);
		disc.transform.position = Destiny(dest);
	}

	private Vector3 Destiny(int post) {
		switch (postes[post].Count) {
		case 0:
		default:
			Messenger.Message("Error, por favor reinicie el juego", 0.0001f, Color.red, true, false);
			Debug.Log("Hanoi error");
			return Vector3.zero;
		case 1:
			return this.transform.FindChild("HanoiDiscPosition4").position;
		case 2:
			return this.transform.FindChild("HanoiDiscPosition3").position;
		case 3:
			return this.transform.FindChild("HanoiDiscPosition2").position;
		case 4:
			return this.transform.FindChild("HanoiDiscPosition1").position;
		}
	}

	private void GoRightLeft(GameObject disc, GameObject destPost) {
		disc.transform.position = new Vector3(destPost.transform.position.x, disc.transform.position.y, destPost.transform.position.z);
	}

	private bool CanDiscMove(int post, int dest) {
		if (post >= 0 && post <= 2 && dest >= 0 && dest <= 2) {
			postes[0].TrimExcess();
			postes[1].TrimExcess();
			postes[2].TrimExcess();
			int a = postes[post].Peek();
			int b = postes[dest].Peek();
			return (a < b);
			//return (postes[post].Peek() < postes[dest].Peek());
		}
		return false;
	}
}
