using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigameChaper01 : MonoBehaviour {

    public GameObject message;
    public GameObject helper;
    public GameObject helpBubble;
    public GameObject erdeSolution;
    public GameObject humusSolution;
    public GameObject kiesSolution;
    public GameObject sandSolution;
    public GameObject charakter;
    public GameObject dirtyCharacter;
    public GameObject healthyCharacter;
    public UIHandler UI;

    private bool erde = false;
    private bool humus = false;
    private bool kies = false;
    private bool sand = false;

	int pointsMinigameChapter01 = 4;

    // Use this for initialization
    void Start () {
        healthyCharacter.SetActive(false);
        UI.displayMinigameButton(false);

        Text text = message.GetComponent<Text>();
        helpBubble.SetActive(true);
        text.text = "Mit den Informationen die wir erhalten haben müssten wir das Rätsel doch lösen können. Durch welche Erdschichten müssen wir durchsickern um in das Grundwasser zu gelangen?";
    }

    public void showAnswer(Button button)
    {
        if(button.name == "erde")
        {
            if (erde == true)
            {
                showAndHideBubbleWithText("Diese Schicht wurde bereits ausgewählt");
            }
            else
            {
                changeLocationCharakter(0.9f);
                erde = true;
                erdeSolution.SetActive(true);
            }
        }
        else if (button.name == "humus")
        {
            if (humus == true)
            {
                showAndHideBubbleWithText("Diese Schicht wurde bereits ausgewählt");
            }
            else if (erde == false)
            {
				getMinusPoints ();
                showAndHideBubbleWithText("Anscheinend erscheint vorher eine andere Schicht");
            }
            else
            {
                changeLocationCharakter(0.9f);
                humus = true;
                humusSolution.SetActive(true);
            }
        }
        else if (button.name == "kies")
        {
            if (kies == true)
            {
                showAndHideBubbleWithText("Diese Schicht wurde bereits ausgewählt");
            }
            else if (humus == false)
            {
				getMinusPoints ();
                showAndHideBubbleWithText("Anscheinend erscheint vorher eine andere Schicht");
            }
            else
            {
                changeLocationCharakter(0.7f);
                kies = true;
                kiesSolution.SetActive(true);
            }
        }
        else if (button.name == "lehm")
        {
            if (sand == true)
            {
                showAndHideBubbleWithText("Diese Schicht wurde bereits ausgewählt");
            }
            else if (kies == false)
            {
				getMinusPoints ();
                showAndHideBubbleWithText("Anscheinend erscheint vorher eine andere Schicht");
            }
            else
            {
                changeLocationCharakter(0.7f);
                dirtyCharacter.SetActive(false);
                healthyCharacter.SetActive(true);
                sand = true;
                sandSolution.SetActive(true);
                UI.displayQuizButton(true);

				NavigatorData.achievedPointsGame [1] = pointsMinigameChapter01;

                Text text = message.GetComponent<Text>();
                helpBubble.SetActive(true);
                text.text = "Glückwunsch du hast die Aufgabe erfolgreich gelöst. Zeige im Quiz was du gelernt hast und sieh dir an was im Fluss so alles passieren kann.";
            }
        }
        else
        {
			getMinusPoints ();
            showAndHideBubbleWithText("Es sieht nicht so aus das deine Figuren hier durch können");
        } 
    }

    void changeLocationCharakter(float changeVerticalPosition)
    {
        charakter.transform.localPosition = new Vector2(charakter.transform.localPosition.x, charakter.transform.localPosition.y - changeVerticalPosition);
    }

    void showAndHideBubbleWithText(string showedText)
    {
        Text text = message.GetComponent<Text>();
        helpBubble.SetActive(true);
        text.text = showedText;
    }

	void getMinusPoints()
	{
		if(pointsMinigameChapter01 > 0)
		{
			pointsMinigameChapter01--;
		}
		else
		{
			pointsMinigameChapter01 = 0;
		}
	}
}
