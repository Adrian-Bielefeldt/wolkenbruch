using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public Canvas canvas;
	public INotifiableQuestion questionToNotifiy;
	public bool draggable = true;

	Vector3 startPosition;
	Transform startParent;

	public void OnBeginDrag(PointerEventData eventData) {
		if (!draggable) {
			return;
		}
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		itemBeingDragged.transform.SetParent (canvas.transform);
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData) {
		Vector3 screenPoint = Input.mousePosition;
		screenPoint.z = canvas.planeDistance;
		transform.position = Camera.main.ScreenToWorldPoint (screenPoint);
	}
		
	public void OnEndDrag(PointerEventData eventData) {
		itemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == canvas.transform) {
			transform.SetParent (startParent);
		}
		if (transform.parent == startParent) {
			transform.position = startPosition;
		}
		questionToNotifiy.answersChanged ();
	}
}
