using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour {

	public GameObject primaryPanel;
	public GameObject HelpBubble;

	int i = 0;

	// Use this for initialization
	void Start() {
		HelpBubble.SetActive (false);
	}

	public void test() {
		if (i == 0) {
			help ("Testing the help bubble.");
			i++;
		} else if (i == 1) {
			help ("Does the bubble grow and change as I want it to? Can I still read everything? Does this work?");
			i++;
		} else if (i == 2) {
			help ("And back to a small bubble");
			i++;
		} else {
			help ("The Number " + i);
			i++;
		}

	}

	public void help (string help) {
		HelpBubble.GetComponentInChildren<Text> ().text = help;
		HelpBubble.SetActive (true);
	}

	public void cancelHelp() {
		HelpBubble.SetActive (false);
	}
}