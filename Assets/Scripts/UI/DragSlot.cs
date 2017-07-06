using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSlot : MonoBehaviour, IDropHandler {
	public GameObject item  {
		get {
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

	public void OnDrop (PointerEventData eventData) {
		if (!item) {
			DragHandler.itemBeingDragged.transform.SetParent (transform);
			DragHandler.itemBeingDragged.transform.localPosition = Vector3.one;
			DragHandler.itemBeingDragged.transform.localScale = Vector3.one;
		}
	}
}
