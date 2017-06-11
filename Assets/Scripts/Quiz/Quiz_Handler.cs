using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz_Handler : MonoBehaviour {

	public GameObject choiceTogglePrefab;

	public GameObject quizPanel;
	public GameObject answersPanel;

	public GameObject questionText;
	public GameObject pointsText;

	public GameObject scoreText;

	public GameObject furtherButton;

    public GameObject informationItems;
    public GameObject plusIcons;
	List<Question> questions;

	int pointsAchieved = 0;
	int pointsPossible = 0;

	Question activeQuestion;

	bool asking = true;

	public void toggleShow() {
		if (quizPanel.activeSelf) {
            plusIcons.SetActive(true);
            informationItems.SetActive(true);
            quizPanel.SetActive (false);
		} else {
            plusIcons.SetActive(false);
            informationItems.SetActive(false);
            quizPanel.SetActive (true);
			if (questions.Count <= 0) {
				questionText.GetComponent<Text> ().text = "ERROR: No question were given.";
				Debug.LogError ("ERROR: No questions where given.");
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

		activeQuestion.buildQuestion (answersPanel, this);
	}

	void addToScore(int change) {
		pointsAchieved += change;
		scoreText.GetComponent<Text> ().text = "Punkte erreicht: " + pointsAchieved + " von " + pointsPossible;
	}

	public void evaluateOrFurther() {
		if (asking) {
			furtherButton.GetComponentInChildren<Text> ().text = "Nächste Frage";
			if (activeQuestion.evaluate ()) {
				addToScore (activeQuestion.getPoints());
			}
		} else {
			int nextPosition = questions.IndexOf (activeQuestion) + 1;
			if (nextPosition < questions.Count) {
				setActiveQuestion (questions [nextPosition]);
			} else {
				Debug.Log ("Quiz beendet.");
				toggleShow ();
			}
		}
		asking = !asking;
	}
}
