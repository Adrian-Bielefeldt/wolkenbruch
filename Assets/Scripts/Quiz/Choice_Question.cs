using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Choice_Question : Question {

	string rightAnswer;
	string[] wrongAnswers;

	GameObject answersPanelUsed;

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

		answersPanel.AddComponent<ToggleGroup> ();

		List<string> posibilities = new List<string> ();

		foreach (string wrongAnswer in wrongAnswers) {
			posibilities.Add (wrongAnswer);
		}
		posibilities.Add (rightAnswer);

		while (posibilities.Count > 0) {
			string answer = posibilities [UnityEngine.Random.Range(0, posibilities.Count)];
			posibilities.Remove (answer);
			GameObject newAnswer = Instantiate (quizHandler.choiceTogglePrefab) as GameObject;
			newAnswer.GetComponent<Toggle> ().group = answersPanel.GetComponent<ToggleGroup>();

			newAnswer.GetComponentInChildren<Text> ().text = answer;
			newAnswer.transform.SetParent (answersPanel.transform, false);
			newAnswer.transform.localScale = Vector3.one;
		}
	}

	public override bool evaluate () {

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

		return correct;
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

	public override void cleanUpQuestion () {
		Destroy (answersPanelUsed.GetComponent<ToggleGroup> ());

		getAnswerPanelElements().ForEach (child => Destroy (child));
	}

	List<GameObject> getAnswerPanelElements() {
		List<GameObject> children = new List<GameObject>();
		foreach (Transform child in answersPanelUsed.transform)
			children.Add (child.gameObject);
		return children;
	}		
}
