using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hanoi : MonoBehaviour {

	private static Stack<int>[] postes = new Stack<int>[3] { new Stack<int>(), new Stack<int>(), new Stack<int>()};
	private static Stack<int> objective = new Stack<int>();
	public int post;
	private static int click1 = -1;
	private static int click2 = -1;

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
	
	// Update is called once per frame
	void Update () {
		postes[0].TrimExcess();
		postes[1].TrimExcess();
		postes[2].TrimExcess();
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
		GoDown(disc);
	}

	private void GoUp(GameObject disc) {
		disc.transform.position += new Vector3(0, 10, 0);
	}

	private void GoDown(GameObject disc) {
		//disc.transform.position -= new Vector3(0, 10, 0);
		RaycastHit hit;
		Physics.Raycast (disc.transform.position, -disc.transform.up, out hit, 30.0f);
		disc.transform.position -= new Vector3(0, hit.distance, 0);
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
