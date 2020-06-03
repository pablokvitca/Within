using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class FinLoad : MonoBehaviour {

	public UnityEngine.Video.VideoClip videoClip;

	public AudioSource audioss;

	//public VideoPlayer vp;

	// Use this for initialization
	void Start () {

		//var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
		//var audioSource = gameObject.AddComponent<AudioSource>();

		//videoPlayer.playOnAwake = false;
		//videoPlayer.clip = videoClip;
		//videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
		//videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
		//videoPlayer.targetMaterialProperty = "_MainTex";
		//videoPlayer.audioOutputMode = UnityEngine.Video.VideoAudioOutputMode.AudioSource;
		//videoPlayer.SetTargetAudioSource(0, audioSource);

		//vp = GetComponent<UnityEngine.Video.VideoPlayer>();
		//if(!vp.isPlaying)
  //      {
		//	vp.Play();
  //      }
	}

	void Update() {
		//if (!vp.isPlaying) {
		//	ChangeScene.changeScene("Creditos");
		//}
		//if (Input.GetMouseButtonDown(1)) {
		//	ChangeScene.changeScene("Menu");
		//}

	}
}
