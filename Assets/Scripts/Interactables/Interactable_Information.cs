using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable_Information : MonoBehaviour {

	public UIHandler UI;

	public INotifiableHandler handler;

	public string title;

	public List<string> pages;

	public bool alreadyRead = false;

	void OnMouseDown () {
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
		alreadyRead = true;
		handler.notifyChange ();
		UI.DisplayInformation (title, pages);
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
