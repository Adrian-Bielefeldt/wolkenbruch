using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class start : MonoBehaviour {

	public VideoPlayer video;

	// Use this for initialization
	void Start () {
		video.Play ();
		video.loopPointReached += EndReached;
	}

	void EndReached(VideoPlayer vp) {
		Debug.Log ("end");
	}
}
