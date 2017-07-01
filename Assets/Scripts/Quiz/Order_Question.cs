using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order_Question : Question , INotifiableQuestion {

	string[] correctOrder;
	Quiz_Handler quizHandler;

	public Order_Question (string questionToSet, string[] correctOrderToSet, int pointsToSet) : base (questionToSet, pointsToSet) {
		correctOrder = correctOrderToSet;
	}

	public string[] getCorrectOrder() {
		return correctOrder;
	}

	public override void buildQuestion (GameObject answersPanelLeft, GameObject answersPanelRight, Quiz_Handler quizHandler_) {

		answersPanelLeftUsed = answersPanelLeft;
		answersPanelRightUsed = answersPanelRight;

		quizHandler = quizHandler_;

		List<string> possibilities = new List<string> ();

		foreach (string orderElement in correctOrder) {
			possibilities.Add (orderElement);
		}

		for (int i = 0; i < possibilities.Count; i++) {
			GameObject newSlot = Instantiate (quizHandler.slotPanelPrefab) as GameObject;
			newSlot.transform.SetParent (answersPanelRight.transform, false);
		}

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

			quizHandler.setEvaluteButtonEnabled (false);
		}
	}

	public void answersChanged() {
		foreach (GameObject answerSlot in getAnswersPanelRightElements()) {
			if (answerSlot.GetComponent<DragSlot> ().item == null) {
				quizHandler.setEvaluteButtonEnabled (false);
				return;
			}
			quizHandler.setEvaluteButtonEnabled (true);
		}
	}

	public override int evaluate () {

		bool correct = true;

		List<GameObject> answerPanelElements = getAnswersPanelRightElements ();

		for (int i = 0; i < answerPanelElements.Count; i++) {
			DragSlot answerSlot = answerPanelElements [i].GetComponent<DragSlot> ();
			GameObject answer = answerSlot.item;
			answer.GetComponent<DragHandler> ().enabled = false;
			if (answer.GetComponentInChildren<Text> ().text == correctOrder [i]) {
				setImageColor (answer.GetComponent<Image> (), "#8CE5B9FF");
			} else {
				setImageColor (answer.GetComponent<Image> (), "#EA4758FF");
				correct = false;
			}
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
