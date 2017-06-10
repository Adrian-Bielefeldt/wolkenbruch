﻿using UnityEngine;

public abstract class Question : ScriptableObject {

	string question;

	int points;

	protected GameObject answersPanelUsed;

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

	public abstract void buildQuestion (GameObject answersPanel, Quiz_Handler quizHandler);

	public abstract int evaluate ();

	public abstract void cleanUpQuestion ();
}
