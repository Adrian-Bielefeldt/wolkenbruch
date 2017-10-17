using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions_Chapter01 : MonoBehaviour {

	public Quiz_Handler quizHandler;

	// Use this for initialization
	void Start () {
		string wahr = "Wahr";
		string falsch = "Falsch";
		List<Question> questions = new List<Question>() {
			new Choice_Question ("Welche Schicht ist undurchlässig?", "Lehm", new string[]{"Humus", "Kies", "Sand"}, 2),
			new Choice_Question ("Das Schmutzwasser wird sauberer, wenn es im Boden versickert.", wahr, new string[]{falsch}, 1),
			new Choice_Question ("Wasser kommt in drei verschiedenen Aggregatzuständen vor.", wahr, new string[]{falsch}, 1),
			new Choice_Question ("Wasserundurchlässige Schichten befinden sich über dem Grundwasser.", falsch, new string[]{wahr}, 1),
			new Choice_Question ("Das versickerte Wasser wird zu einer Quelle.", wahr, new string[]{falsch}, 1),
			new Choice_Question ("Wir trinken dasselbe Wasser wie unsere Vorfahren.", wahr, new string[]{falsch}, 1),
			new Order_Question ("Ordne in richtiger Reihenfole, wie das Wasser nach Hause kommt.", new string[]{
				"Wasser wird aus Brunnen geschöpft (Pumpwerk).",
				"Das Wasser wird gereinigt.",
				"Das Wasser wird in den Hochbehälter gepumpt.",
				"Das Wasser befindet sich in der Fallleitung.",
				"Wir haben im Wasserhahn sauberes Wasser."}, 5)
		};

		quizHandler.setQuestions (questions);

		int sum = 0;
		foreach (Question question in questions) {
			sum += question.getPoints ();
		}
		NavigatorData.maxPointsQuiz [1] = sum;
	}
}
