using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Kapitel : MonoBehaviour {

	public GameHandler GH;

	public string chapter;

	void OnMouseDown () {
		GH.chapter (chapter);
	}
}
