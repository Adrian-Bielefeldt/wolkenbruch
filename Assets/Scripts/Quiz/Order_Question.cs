using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order_Question : Question {

	string[] correctOrder;

	public Order_Question (string questionToSet, string[] correctOrderToSet, int pointsToSet) : base (questionToSet, pointsToSet) {
		correctOrder = correctOrderToSet;
	}

	public string[] getCorrectOrder() {
		return correctOrder;
	}

	public override void buildQuestion (GameObject answersPanel, Quiz_Handler quizHandler) {

		answersPanelUsed = answersPanel;

		List<string> possibilities = new List<string> ();

		foreach (string orderElement in correctOrder) {
			possibilities.Add (orderElement);
		}

		while (possibilities.Count > 0) {
			string answer = possibilities [UnityEngine.Random.Range(0, possibilities.Count)];
			possibilities.Remove (answer);
			GameObject newAnswer = Instantiate (quizHandler.orderButtonPrefab) as GameObject;

			newAnswer.GetComponentInChildren<Text> ().text = answer;
			newAnswer.transform.SetParent (answersPanel.transform, false);
		}
	}

	public override int evaluate () {

		bool correct = true;

		List<GameObject> answerPanelElements = getAnswerPanelElements ();

		for (int i = 0; i < answerPanelElements.Count; i++) {
			GameObject answer = answerPanelElements [i];
			if (answer.GetComponentInChildren<Text> ().text == correctOrder [i]) {
				setImageColor (answer.GetComponent<Image> (), "#8CE5B9FF");
			} else {
				setImageColor (answer.GetComponent<Image> (), "#EA4758FF");
				correct = false;
			}
		}

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

	List<GameObject> getAnswerPanelElements() {
		List<GameObject> children = new List<GameObject>();
		foreach (Transform child in answersPanelUsed.transform)
			children.Add (child.gameObject);
		return children;
	}

	public override void cleanUpQuestion () {
		getAnswerPanelElements().ForEach (child => Destroy (child));
	}
}
