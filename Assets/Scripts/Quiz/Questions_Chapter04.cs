using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions_Chapter04 : MonoBehaviour {

	public Quiz_Handler quizHandler;

	// Use this for initialization
	void Start () {
		quizHandler.setQuestions (
			new List<Question> () {
				new Choice_Question ("Welcher Satz ist falsch?", "Die Lehmschicht ist wasserdurchlässig.", new string[]{"Das Wasser verdunstet.", "Der Niederschlag versickert in der Erde.", "Der Wind treibt die Wolken weiter."}, 4),
				new Choice_Question ("Das Grundwasser kann nicht ...", "verdunsten.", new string[]{"der Beginn eines Bachs sein.", "als Trinkwasser verwendet werden.", "zum Meer zurückgelangen."}, 4),
				new Choice_Question ("Was ist nicht wichtig bei der Entstehung von Tau?", "Der Wind", new string[]{"Die Luftfeuchtigkeit", "Die Kondensation", "Die niedrigere Temperatur während der Nacht."}, 4),
				new Choice_Question ("Die maximal mögliche Verdunstung heißt ... Verdunstung.", "potenzielle", new string[]{"potenziele", "potentiale", "potenzialle"}, 4),
				new Choice_Question ("Aerosole sind ...", "feste oder flüssige Teilchen in der Luft.", new string[]{"gasförmige oder flüssige Teilchen in der Luft.", "feste Teilchen in der Luft.", "ein anderer Name für Gas."}, 4),
				new Choice_Question ("Was ist keine Quelle der Verdunstung?", "Das Grundwasser", new string[]{"Der Ozean", "Die Flüsse", "Die Tiere"}, 4)
			}); 
	}
}
