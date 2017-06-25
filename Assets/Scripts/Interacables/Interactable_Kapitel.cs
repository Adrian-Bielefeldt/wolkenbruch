using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Kapitel : MonoBehaviour {

	public GameHandler GH;

	public Sprite hoverSprite;

	Sprite normalSprite;

	public string chapter;

	void OnMouseDown () {
		GH.chapter (chapter);
	}

	void OnMouseEnter () {
		normalSprite = GetComponent<SpriteRenderer> ().sprite;
		GetComponent<SpriteRenderer> ().sprite = hoverSprite;
		transform.SetAsLastSibling ();
	}

	void OnMouseExit () {
		GetComponent<SpriteRenderer> ().sprite = normalSprite;
	}
}
