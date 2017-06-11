using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour {

	public GameObject primaryPanel;
	public GameObject HelpBubble;

	// Use this for initialization
	void Start() {
		//HelpBubble.SetActive (true);
	}

	public void test() {
		help ("Dies ist ein Test des Helfers. Klicken sie auf die Sprechblase, um sie zu schließen.");
	}

	public void help (string help) {
		HelpBubble.GetComponentInChildren<Text> ().text = help;
		HelpBubble.SetActive (true);
	}

	public void cancelHelp() {
		HelpBubble.SetActive (false);
	}
}