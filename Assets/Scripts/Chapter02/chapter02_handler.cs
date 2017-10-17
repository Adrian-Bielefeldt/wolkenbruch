using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter02_handler : MonoBehaviour , INotifiableHandler {

	public UIHandler UI;

	public Helper helper;

	public GameObject information_scene;

	public GameObject game_scene;

	void Start() {
		Interactable_Information[] list = information_scene.GetComponentsInChildren<Interactable_Information> ();
		foreach (Interactable_Information interactable in list) {
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
		helper.currentHelp = "Jetzt kannst du mit dem Minispiel anfangen. Du findest es oben links.";
		helper.help (helper.currentHelp);
	}

	public void startMinigame() {
		information_scene.SetActive (false);
		game_scene.SetActive (true);
		game_scene.transform.GetChild (0).gameObject.SetActive (true);

		UI.displayMinigameButton (false);

		helper.currentHelp = "Wähle den Weg des Flusses. Dein Ziel ist es, möglichst schnell zum Meer zu kommen. Das ist direkt unter mir.";
		helper.help (helper.currentHelp);
	}

	public void notifyRiverGame(bool finalChoice) {
		int correct = 0;
		int incorrect = 0;

		foreach (Transform child in game_scene.transform) {
			if (child.GetComponent<river_choice> ().answered) {
				if (child.GetComponent<river_choice> ().wasRight) {
					correct++;
				} else {
					incorrect++;
				}
				child.gameObject.SetActive (false);
			} else {
				child.gameObject.SetActive (true);
				if (!finalChoice) {
					return;
				}
			}
		}

		Transform gameTransform = game_scene.transform;

		gameTransform.GetChild (gameTransform.childCount - 1).gameObject.SetActive (true);

		string quizLine = "Jetzt kannst du dich am Quiz versuchen. Klicke auf Quiz links oben, um loszulegen.";

		if (incorrect == 0) {
			helper.currentHelp = "Gratulation. Du hast den Fluss bis ins Meer gebracht, ohne dich zu verirren.\n" + quizLine;
		} else {
			if (incorrect == 1) {
				helper.currentHelp = "Trotz einer falscher Abzweigung sind wir im Meer angekommen. Gut gemacht.\n" + quizLine;
			} else {
				helper.currentHelp = "Trotz einiger falscher Abzweigungen sind wir im Meer angekommen. Gut gemacht.\n" + quizLine;
			}

		}
		UI.displayQuizButton (true);

		NavigatorData.achievedPointsGame [2] = correct;
	}
}
