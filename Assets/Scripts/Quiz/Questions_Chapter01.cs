using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions_Chapter01 : MonoBehaviour {

	public Quiz_Handler quizHandler;

	// Use this for initialization
	void Start () {
		quizHandler.setQuestions (new List<Question>() {
			new Order_Question("Bring the items in the correct order.", new string[]{"firstItem", "secondItem", "thirdItem", "fourthItem"}, 1),
			new Choice_Question("First Question to be asked.", "rightAnswer", new string[]{"wrongAnswer1", "wrongAnswer2"}, 1),
			new Choice_Question("Question2, extra long to test the scaling", "anotherRightAnswer", new string[]{"FalseAnswer1", "FalseAnswer2", "FalseAnswer3"}, 1)
		});
	}
}
