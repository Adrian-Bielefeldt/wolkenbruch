using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Kapitel : MonoBehaviour {

	public GameHandler GH;

	public string chapter;

	void OnMouseDown () {
		GH.chapter (chapter);
	}

	void OnMouseEnter () {
		GetComponent<SpriteOutline> ().UpdateOutline (true);
	}

	void OnMouseExit () {
		GetComponent<SpriteOutline> ().UpdateOutline (false);
	}
}
