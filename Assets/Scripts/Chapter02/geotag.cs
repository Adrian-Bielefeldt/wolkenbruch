using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class geotag : MonoBehaviour {

	public river_choice riverChoice;

	public bool correct;

	public string tipp;

	void OnMouseDown () {
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
		riverChoice.setRight (correct, tipp);
	}

	void OnMouseEnter () {
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
		GetComponent<SpriteOutline> ().UpdateOutline (true);
	}

	void OnMouseExit () {
		GetComponent<SpriteOutline> ().UpdateOutline (false);
	}
}
