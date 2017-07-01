using System.Collections.Generic;

using UnityEngine;

public abstract class Question : ScriptableObject {

	string question;

	int points;

	protected GameObject answersPanelLeftUsed;
	protected GameObject answersPanelRightUsed;

	public Question(string questionToSet, int pointsToSet) {
		question = questionToSet;
		points = pointsToSet;
	}

	public string getQuestion() {
		return question;
	}

	public int getPoints() {
		return points;
	}

	public abstract void buildQuestion (GameObject answersPanelLeft, GameObject answersPanelRight, Quiz_Handler quizHandler);

	public abstract int evaluate ();


	public List<GameObject> getAnswersPanelLeftElements() {
		List<GameObject> children = new List<GameObject>();
		foreach (Transform child in answersPanelLeftUsed.transform)
			children.Add (child.gameObject);
		return children;
	}

	public List<GameObject> getAnswersPanelRightElements() {
		List<GameObject> children = new List<GameObject>();
		foreach (Transform child in answersPanelRightUsed.transform)
			children.Add (child.gameObject);
		return children;
	}

	public void cleanUpQuestion () {
		getAnswersPanelLeftElements().ForEach (child => Destroy (child));
		getAnswersPanelRightElements().ForEach (child => Destroy (child));
	}
}
