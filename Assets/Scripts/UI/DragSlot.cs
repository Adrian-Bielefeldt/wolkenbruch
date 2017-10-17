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
			GameObject newItem = DragHandler.itemBeingDragged;
			Transform newItemTransform = newItem.transform;
			newItemTransform.SetParent (this.transform);
			newItemTransform.localPosition = Vector3.one;
			newItemTransform.localScale = Vector3.one;
			newItemTransform.localRotation = Quaternion.identity;

			RectTransform rectTransform = newItem.GetComponent<RectTransform> ();
			rectTransform.offsetMin = new Vector2 (0, 0);
			rectTransform.offsetMax = new Vector2 (0, 0);
		}
	}
}
