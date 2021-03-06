﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour {

	public GameObject primaryPanel;
	public GameObject HelpBubble;

	public AudioSource helpSound;

	public string currentHelp;

	// Use this for initialization
	void Start() {
		//HelpBubble.SetActive (true);
	}

	public void test() {
		help (currentHelp);
	}

	public void help (string help) {
		helpSound.PlayOneShot (helpSound.clip, 1f);
		HelpBubble.GetComponentInChildren<Text> ().text = help;
		HelpBubble.SetActive (true);
	}

	public void cancelHelp() {
		HelpBubble.SetActive (false);
	}
}