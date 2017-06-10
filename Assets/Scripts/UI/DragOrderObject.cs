using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragOrderObject : MonoBehaviour {

	DragOrderContainer container = null;

	// Use this for initialization
	void Start () {
		container = GetComponentInParent<DragOrderContainer> ();
	}

	public void OnBeginDrag(BaseEventData eventData) {
		Debug.Log ("Beginning drag on: " + this.GetComponentInChildren<Text>().text);
		container.setObjectBeingDragged (this.gameObject);
	}

	public void OnDrag(BaseEventData eventData) {
		// empty method for interface compliancy
	}

	public void OnEndDrag(BaseEventData eventData) {
		if (container.getObjectBeingDragged () == this.gameObject) {
			container.setObjectBeingDragged (null);
		}
	}

	public void OnPointerEnter(BaseEventData eventData) {
		GameObject objectBeingDragged = container.getObjectBeingDragged ();
		if (objectBeingDragged != null && objectBeingDragged != this.gameObject) {
			objectBeingDragged.transform.SetSiblingIndex (this.transform.GetSiblingIndex());
		}
	}
}
