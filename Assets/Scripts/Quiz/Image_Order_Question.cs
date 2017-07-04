using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Order_Question : Question , INotifiableQuestion {

	string[] correctOrder;
	Quiz_Handler quizHandler;

	public Image_Order_Question (string questionToSet, string[] correctOrderToSet, int pointsToSet) : base (questionToSet, pointsToSet) {
		correctOrder = correctOrderToSet;
	}

	public override void buildQuestion (GameObject answersPanelLeft, GameObject answersPanelRight, Quiz_Handler quizHandler_) {

		answersPanelLeftUsed = answersPanelLeft;
		answersPanelRightUsed = answersPanelRight;

		quizHandler = quizHandler_;

		List<string> possibilities = new List<string> ();

		foreach (string orderElement in correctOrder) {
			possibilities.Add (orderElement);
		}

		GameObject circle = Instantiate (quizHandler.circlePrefab) as GameObject;
		circle.transform.SetParent (answersPanelRight.transform, false);

		while (possibilities.Count > 0) {
			string answer = possibilities [UnityEngine.Random.Range(0, possibilities.Count)];
			possibilities.Remove (answer);
			GameObject newSlot = Instantiate (quizHandler.slotPanelPrefab) as GameObject;
			newSlot.transform.SetParent (answersPanelLeft.transform, false);

			GameObject newAnswer = Instantiate (quizHandler.orderButtonPrefab) as GameObject;

			newAnswer.GetComponent<DragHandler> ().canvas = quizHandler.canvas;
			newAnswer.GetComponent<DragHandler> ().questionToNotifiy = this;
			newAnswer.GetComponentInChildren<Text> ().text = answer;
			newAnswer.transform.SetParent (newSlot.transform, false);
		}
	}

	public void answersChanged() {
		Transform circle = answersPanelRightUsed.transform.GetChild (0);

		foreach (Transform child in circle.transform) {
			if (child.gameObject.GetComponent<DragSlot> ().item == null) {
				quizHandler.setEvaluteButtonEnabled (false);
				return;
			}
		}
		quizHandler.setEvaluteButtonEnabled(true);
	}

	public override int evaluate () {

		bool correct = true;

		int i = 0;
		foreach (Transform child in answersPanelRightUsed.transform.GetChild(0)) {
			DragSlot answerSlot = child.gameObject.GetComponent<DragSlot> ();
			GameObject answer = answerSlot.item;
			answer.GetComponent<DragHandler> ().enabled = false;
			if (answer.GetComponentInChildren<Text> ().text == correctOrder [i]) {
				setImageColor (answer.GetComponent<Image> (), "#8CE5B9FF");
			} else {
				setImageColor (answer.GetComponent<Image> (), "#EA4758FF");
				correct = false;
			}
			i++;
		}

		getAnswersPanelLeftElements().ForEach (child => Destroy (child));

		if (correct) {
			return getPoints();
		} else {
			return 0;
		}
	}

	void setImageColor (Image image, string colorString) {
		Color color = new Color ();
		if (!ColorUtility.TryParseHtmlString (colorString, out color)) {
			Debug.LogError ("Could not parse " + colorString + " as a color.");
		} else {
			image.color = color;
		}
	}
}
