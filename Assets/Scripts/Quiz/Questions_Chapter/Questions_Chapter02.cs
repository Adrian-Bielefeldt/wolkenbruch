using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions_Chapter02 : MonoBehaviour {

	public Quiz_Handler quizHandler;

	// Use this for initialization
	void Start () {
		string wahr = "Wahr";
		string falsch = "Falsch";
		quizHandler.setQuestions (
			new List<Question> () {
				new Choice_Question ("Was bedeutet Kondensation?", "Der Übergang eines Stoffen vom gasförmigen in den flüssigen Aggregatzustand.", new string[] {
					"Der Übergang eines Stoffes vom festen in den gasförmigen Aggregatzustand.",
					"Der Übergang einer Flüssigkeit in den gasförmigen Aggregatzustand.",
					"Der Übergang eines Stoffes vom flüssigen in den gasförmigen zustand, ohne dabei die Siedetemperatur zu erreichen."
				}, 3),
				new Choice_Question ("Wasserteilchen verdichten sich zu Wassertröpfchen. Man kann das bei ... beobachten.", "einem Spiegel im dampfenden Raum",
					new string[]{ "Hagel", "dem Trinken", "dem Schwitzen" }, 3),
				new Choice_Question ("Bei welchen Temperaturen kommt Wasser unter normalem Druck vor?", "0 bis 100 °C",
					new string[]{ "0 bis 10 °C", "-10 bis 100 °C", "36,6 bis 100 °C" }, 3),
				new Choice_Question ("Was bezeichnet man nicht als Niederschlag?", "Einen Blitz",
					new string[]{ "Den Regen", "Den Hagel", "Den Tau" }, 3),
				new Choice_Question ("Die Gebirge haben keinen Einfluss auf Niederschlag.", falsch, new string[]{ wahr }, 1),
				new Choice_Question ("Ohne Sonne gibt es keinen Regen.", wahr, new string[]{ falsch }, 1),
				new Choice_Question ("Es regnet, wenn die Tropfen zu schwer sind.", wahr, new string[]{ falsch }, 1),
				new Choice_Question ("Im Wasserkreislauf geht Wasser verloren, weil es seinen Zustand ändert.", falsch, new string[]{ wahr }, 1),
				new Order_Question ("Ordne die Schritte der Entstehung von Regen in richtiger Reihenfolge an.", new string[] {
					"Die Sonne erwärmt das Wasser.",
					"Einige Moleküle sind schneller, sodass sie die Anziehungskraft anderer Wassermoleküle überwinden.",
					"Die Wasserteilchen steigen mit der warmen Luft nach oben.",
					"Es enstehen Wolken.",
					"Die Tröpfchen in den Wolken werden schwerer.",
					"Es entsteht Regen."
				}, 6)
			});
	}
}
