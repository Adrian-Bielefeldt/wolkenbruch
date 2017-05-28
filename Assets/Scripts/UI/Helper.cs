using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour {

	public GameObject speechBubble;
	public GameObject textBox;

	void OnMouseDown () {
		textBox.GetComponent<Text> ().text = "Something that I would want to write in here to test the sizing of the text. Apparently I can change the text, but the fitter does not work.";
	}
}
