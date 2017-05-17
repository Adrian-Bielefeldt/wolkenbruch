using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Kapitel_Grundwasser : MonoBehaviour {

	public GameHandler GH;

	void OnMouseDown () {
		GH.chapter ("Chapter01");
	}
}
