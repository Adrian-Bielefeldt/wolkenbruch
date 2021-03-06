﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz_Handler : MonoBehaviour {

	public GameObject choiceTogglePrefab;
	public GameObject orderButtonPrefab;
	public GameObject slotPanelPrefab;
	public GameObject circlePrefab;

	public Canvas canvas;
	public GameObject quizPanel;
	public GameObject answersPanelLeft;
	public GameObject answersPanelRight;

	public GameObject questionText;
	public GameObject pointsText;

	public GameObject scoreText;

	public GameObject furtherButton;

	public int chapter;

	public GameHandler GH;

	List<Question> questions;

	int pointsAchieved = 0;
	int pointsPossible = 0;

	Question activeQuestion;

	bool asking = true;

	public void toggleShow() {
		if (quizPanel.activeSelf) {
            quizPanel.SetActive (false);
		} else {
            quizPanel.SetActive (true);
			if (questions.Count <= 0) {
				questionText.GetComponent<Text> ().text = "ERROR: No questions were given.";
				Debug.LogError ("ERROR: No questions were given.");
			} else {
				setActiveQuestion (questions [0]);
				addToScore (-pointsAchieved);
			}
		}
	}

	public void setQuestions (List<Question> questionsToSet) {
		foreach (Question question in questionsToSet) {
			pointsPossible += question.getPoints ();
		}
		questions = questionsToSet;
	}

	void setActiveQuestion(Question question) {
		if (activeQuestion != null) {
			activeQuestion.cleanUpQuestion ();
		}
		activeQuestion = question;
		questionText.GetComponent<Text> ().text = activeQuestion.getQuestion ();
		pointsText.GetComponent<Text> ().text = "Wert dieser Frage: " + activeQuestion.getPoints ();
		furtherButton.GetComponentInChildren<Text> ().text = "Antwort abgeben";



		activeQuestion.buildQuestion (answersPanelLeft, answersPanelRight, this);
	}

	void addToScore(int change) {
		pointsAchieved += change;
		scoreText.GetComponent<Text> ().text = "Punkte erreicht: " + pointsAchieved + " von " + pointsPossible;
	}

	public void setEvaluteButtonEnabled(bool enabled) {
		furtherButton.GetComponent<Button>().interactable = enabled;
	}

	public void evaluateOrFurther() {
		if (asking) {
			furtherButton.GetComponentInChildren<Text> ().text = "Nächste Frage";
			addToScore (activeQuestion.evaluate ());
		} else {
			int nextPosition = questions.IndexOf (activeQuestion) + 1;
			if (nextPosition < questions.Count) {
				setActiveQuestion (questions [nextPosition]);
			} else {
				toggleShow ();
				NavigatorData.achievedPointsQuiz [chapter] = pointsAchieved;
				if (NavigatorData.unlockedScenes.ContainsKey (chapter + 1)) {
					NavigatorData.unlockedScenes [chapter + 1] = true;
					GH.chapter (5);
				} else {
					GH.chapter (6);
				}
			}
		}
		asking = !asking;
	}
}
