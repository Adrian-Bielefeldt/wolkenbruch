using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class click : MonoBehaviour {

	public VideoPlayer video;


	void OnMouseDown () {
		video.Play ();
		video.GetComponent<VideoPlayer> ().loopPointReached += EndReached;
		gameObject.SetActive (false);
	}

	void EndReached(VideoPlayer vp) {
		SceneManager.LoadScene (0);
	}
}
