using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Choice_Question : Question {

	string rightAnswer;
	string[] wrongAnswers;

	public Choice_Question(string questionToSet, string rightAnswerToSet, string[] wrongAnswersToSet, int pointsToSet) : base (questionToSet, pointsToSet) {
		/// <exception cref="ArgumentException">If the right answer is contained in the wrong answers.</exception>
		if (wrongAnswersToSet.Contains (rightAnswerToSet)) {
			throw new ArgumentException ("The right answer is contained in the wrong answers.", rightAnswerToSet);
		}
			
		rightAnswer = rightAnswerToSet;
		wrongAnswers = wrongAnswersToSet;
	}

	public string getRightAnswer() {
		return rightAnswer;
	}

	public string[] getWrongAnswers() {
		return wrongAnswers;
	}

	public override void buildQuestion (GameObject answersPanel, Quiz_Handler quizHandler) {

		answersPanelUsed = answersPanel;

		List<string> possibilities = new List<string> ();

		foreach (string wrongAnswer in wrongAnswers) {
			possibilities.Add (wrongAnswer);
		}
		possibilities.Add (rightAnswer);

		while (possibilities.Count > 0) {
			string answer = possibilities [UnityEngine.Random.Range(0, possibilities.Count)];
			possibilities.Remove (answer);
			GameObject newAnswer = Instantiate (quizHandler.choiceTogglePrefab) as GameObject;
			newAnswer.GetComponent<Toggle> ().group = answersPanel.GetComponent<ToggleGroup>();

			newAnswer.GetComponentInChildren<Text> ().text = answer;
			newAnswer.transform.SetParent (answersPanel.transform, false);
			newAnswer.transform.localScale = Vector3.one;
		}
	}

	public override int evaluate () {

		bool correct = false;

		foreach (GameObject answer in getAnswerPanelElements()) {
			Toggle toggle = answer.GetComponent<Toggle> ();
			toggle.enabled = false;
			if (toggle.isOn) {
				if (answer.GetComponentInChildren<Text> ().text == rightAnswer) {
					setToggleColor (toggle, "#8CE5B9FF");
					correct = true;
				} else {
					setToggleColor (toggle, "#EA4758FF");
				}
			}
		}

		if (correct) {
			return getPoints ();
		} else {
			return 0;
		}
	}

	void setToggleColor (Toggle toggle, String colorString) {
		Color color = new Color ();
		if (!ColorUtility.TryParseHtmlString (colorString, out color)) {
			Debug.LogError ("Could not parse " + colorString + " as a color.");
		} else {
			ColorBlock colorBlock = toggle.colors;
			colorBlock.normalColor = color;
			toggle.colors = colorBlock;
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
