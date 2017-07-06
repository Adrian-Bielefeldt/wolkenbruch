using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions_Chapter03 : MonoBehaviour {

	public Quiz_Handler quizHandler;

	// Use this for initialization
	void Start () {
		string wahr = "Wahr";
		string falsch = "Falsch";
		string frageVerdunstung = "Wasser verdunstet am schnellsten, wenn ...";
		List<Question> questions = new List<Question> () {
				new Choice_Question ("Zu wie viel Prozent besteht ein Mensch aus Wasser?", "69%", new string[]{ "90%", "23%", "26%" }, 3),
				new Choice_Question ("Wie viel Wasser verbraucht ein durchschnittlicher Deutscher pro Tag?", "120 bis 150 l", new string[] {"weniger als 100 l", "mehr als 200 l", "150 bis 200 l"}, 3),
				new Choice_Question ("Welcher Teil der Erdoberfläche ist von Wasser bedeckt?", "71%", new string[] {"78%", "66%", "89%"}, 3),
				new Choice_Question ("Transpiration ist: Verdunstung ...", "aus Pflanzen", new string[] {"von Eis", "aus Wasserflächen", "von Regen"}, 3),
				new Choice_Question ("Wasser verdunstet nur bei 100 °C.", falsch, new string[] {wahr}, 2),
				new Choice_Question ("Unterhalb des Siedepunktes kann Wasser nicht in den gasförmigen Zustand übergehen.", falsch, new string[] {wahr}, 2),
				new Choice_Question ("Der Wasserdampf ist sichtbar.", falsch, new string[] {wahr}, 2),
				new Choice_Question ("Die Wolken bestehen aus kleinen Wassertröpfchen, die durch Kondensation entstehen", wahr, new string[] {falsch}, 2),
				new Choice_Question ("Wäsche trocknet am besten, wenn die Sonne scheint und kein Wind weht.", falsch, new string[] {wahr}, 2),
				new Choice_Question ("Je höher die Temperatur ist, desto mehr Wasserdampf kann in der Luft sein.", wahr, new string[] {falsch}, 2),
				new Choice_Question ("Seen gehören zum Oberflächenwasser.", wahr, new string[] {falsch}, 2),
				new Choice_Question (frageVerdunstung, "die Temperatur hoch ist.", new string[]{"die Temperatur niedrig ist."}, 1),
				new Choice_Question (frageVerdunstung, "die Sonne scheint.", new string[]{"es bewölkt ist."}, 1),
				new Choice_Question (frageVerdunstung, "die Luftfeuchtigkeit niedrig ist.", new string[]{"die Luftfeuchtigkeit hoch ist."}, 1),
				new Choice_Question (frageVerdunstung, "die Windgeschwindigkeit hoch ist.", new string[]{"die Windgeschwindigkeit niedrig ist."}, 1),
				new Image_Order_Question("Ordne die Wörter der Grafik zu.", new string[]{"Schmelzen", "Gefrieren", "Verdampfen", "Kondensieren", "Sublimieren", "Resublimieren"}, 6)
		};

		quizHandler.setQuestions (questions);

		int sum = 0;
		foreach (Question question in questions) {
			sum += question.getPoints ();
		}
		NavigatorData.maxPointsQuiz [3] = sum;
	}
}
