using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hanoi : MonoBehaviour {

	private static Stack<int>[] postes = new Stack<int>[3] { new Stack<int>(4), new Stack<int>(4), new Stack<int>(4)};
	private static Stack<int> objective = new Stack<int>();
	public int post;
	private int click1 = -1;
	private int click2 = -1;

	// Use this for initialization
	void Start () {
		objective.Push(4);
		objective.Push(3);
		objective.Push(2);
		objective.Push(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void MoveDisc(int post, int dest) {
		if (CanDiscMove(post, dest)) {
			Animate(post, dest);
			postes[dest].Push(postes[post].Pop());
		}
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
		disc.transform.position -= new Vector3(0, 10, 0);
	}

	private void GoRightLeft(GameObject disc, GameObject destPost) {
		RaycastHit hit;
		Physics.Raycast(Physics.Raycast (disc.transform.position, -disc.transform.up, out hit, 30));
		disc.transform.position = new Vector3(destPost.transform.position.x, disc.transform.position.y - hit.distance, destPost.transform.position.z);
	}

	private int PostDist(int post, int dest) {
		int res = post - dest;
	}

	private bool CanDiscMove(int post, int dest) {
		if (post >= 0 && post <= 2 && dest >= 0 && dest <= 2)
			return (postes[post].Peek() < postes[dest].Peek());
		return false;
	}
}
