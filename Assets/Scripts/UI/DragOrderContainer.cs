using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragOrderContainer : MonoBehaviour {

	GameObject objectBeingDragged;

	public GameObject getObjectBeingDragged() {
		return objectBeingDragged;
	}

	public void setObjectBeingDragged(GameObject objectToSet) {
		objectBeingDragged = objectToSet;
	}

	void Awake () {
		objectBeingDragged = null;
	}
}
