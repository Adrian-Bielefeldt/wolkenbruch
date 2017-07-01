using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter01_handler : MonoBehaviour , INotifiableHandler {

	public UIHandler UI;

	public GameObject information_scene;

	void Start() {
		Interactable_Information[] list = information_scene.GetComponentsInChildren<Interactable_Information> ();
		foreach (Interactable_Information interactable in list) {
			Debug.Log ("Setting");
			interactable.handler = this;
		}
	}

	public void notifyChange() {
		Interactable_Information[] list = information_scene.GetComponentsInChildren<Interactable_Information> ();
		foreach (Interactable_Information interactable in list) {
			if (!interactable.alreadyRead) {
				return;
			}
		}

		UI.displayMinigameButton (true);
	}

	public void startMinigame() {

	}
}
