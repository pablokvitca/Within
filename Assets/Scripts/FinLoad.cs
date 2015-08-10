﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class FinLoad : MonoBehaviour {
	
	public MovieTexture mt;
	public AudioSource audioss;

	// Use this for initialization
	void Start () {
		//audioss.clip = mt.audioClip;
		mt.Play();
		audioss.Play();
	}

	void Update() {
		if (!mt.isPlaying) {
			ChangeScene.changeScene("Creditos");
		}
		if (Input.GetMouseButtonDown(1)) {
			ChangeScene.changeScene("Menu");
		}
	}
}
