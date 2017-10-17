using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScene : MonoBehaviour {

	public Animator animator;

	public float speed;

	public GameObject logo;

	public GameObject start;

	public GameObject UI;

	public GameHandler GH;

	public AudioSource audio;

	public GameObject startObject;

	bool stoppedLogo = false;

	bool startedAnimation = false;

	// Use this for initialization
	void Start () {
		animator.speed = speed;
		animator.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (!stoppedLogo) {
			if (Time.time > 5) {
				stoppedLogo = true;
				logo.SetActive (false);
				start.SetActive (true);
				UI.SetActive (true);
			}
		}
		if (startedAnimation) {
			if (!audio.isPlaying) {
				GH.chapter (5);
			}
		}
	}

	public void click() {
		UI.SetActive (false);
		audio.Play ();
		animator.enabled = true;
		startedAnimation = true;
		startObject.SetActive (false);
	}
}
