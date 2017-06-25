using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour {

    public GameObject panelInformation;
    public GameObject backgroundInformation;
    public GameObject informationItems;
    public GameObject toMinigame;
    public GameObject answer;
    public GameObject erdeLoesung;
    public GameObject humusLoesung;
    public GameObject kiesLoesung;
    public GameObject sandLoesung;
    public GameObject minigame;
    public GameObject maincharakter;
    public GameObject dirtycharakter;
    public GameObject healthycharakter;
    public GameObject helpBubble;
    public GameObject message;
    public GameObject helper;

    private bool erde = false;
    private bool humus = false;
    private bool kies = false;
    private bool sand = false;

    private void Start()
    {
        Text text = message.GetComponent<Text>();
        helpBubble.SetActive(true);
        StartCoroutine(LastCall());
        helper.transform.localScale = new Vector2(4, 4);
        helper.transform.localPosition = new Vector2(0, -200);
        helpBubble.transform.localPosition = new Vector2(-200, -200);
        text.text = "Der Hauptcharakter muss ins Grundwasser gelangen um seine Freunde zu finden. Hilf ihm indem du die richtigen Schichten auswählst. ACHTUNG in einigen Schichten bleibt er stecken.";
        LastCall();
        StopCoroutine(LastCall());
    }
    public void StartingKonfiguration()
    {
        minigame.SetActive(true);
        panelInformation.SetActive(false);
        backgroundInformation.SetActive(false);
        informationItems.SetActive(false);
        toMinigame.SetActive(false);
        erdeLoesung.SetActive(false);
        humusLoesung.SetActive(false);
        kiesLoesung.SetActive(false);
        sandLoesung.SetActive(false);
        healthycharakter.SetActive(false);
        helpBubble.SetActive(false);
    }

    public void showAnswer(Button button)
    {
        if (button.name == "erde")
        {
            if(erde == true)
            {
                showAndHideBubbleWithText("Diese Schicht wurde bereits ausgewählt");
            }
            else
            {
                maincharakter.transform.localPosition = new Vector2(maincharakter.transform.localPosition.x, maincharakter.transform.localPosition.y - 83);
                dirtycharakter.transform.localPosition = new Vector2(dirtycharakter.transform.localPosition.x, dirtycharakter.transform.localPosition.y - 83);
                erde = true;
                erdeLoesung.SetActive(true);
            }
        }
        else if(button.name == "felsen")
        {
            showAndHideBubbleWithText("Es sieht nicht so aus das deine Figuren hier durch können");
        }
        else if(button.name == "humus")
        {
            if (humus == true)
            {
                showAndHideBubbleWithText("Diese Schicht wurde bereits ausgewählt");
            }
            else if(erde == false)
            {
                showAndHideBubbleWithText("Anscheinend erscheint vorher eine andere Schicht");
            }
            else
            {
                maincharakter.transform.localPosition = new Vector2(maincharakter.transform.localPosition.x, maincharakter.transform.localPosition.y - 79);
                dirtycharakter.transform.localPosition = new Vector2(dirtycharakter.transform.localPosition.x, dirtycharakter.transform.localPosition.y - 79);
                humus = true;
                humusLoesung.SetActive(true);
            }
        }
        else if(button.name == "kies")
        {
            if (kies == true)
            {
                showAndHideBubbleWithText("Diese Schicht wurde bereits ausgewählt");
            }
            else if (humus == false)
            {
                showAndHideBubbleWithText("Anscheinend erscheint vorher eine andere Schicht");
            }
            else
            {
                maincharakter.transform.localPosition = new Vector2(maincharakter.transform.localPosition.x, maincharakter.transform.localPosition.y - 95);
                dirtycharakter.transform.localPosition = new Vector2(dirtycharakter.transform.localPosition.x, dirtycharakter.transform.localPosition.y - 95);
                kies = true;
                kiesLoesung.SetActive(true);
            }
        }
        else if(button.name == "sand")
        {
            if (sand == true)
            {
                showAndHideBubbleWithText("Diese Schicht wurde bereits ausgewählt");
            }
            else if (kies == false)
            {
                showAndHideBubbleWithText("Anscheinend erscheint vorher eine andere Schicht");
            }
            else
            {
                maincharakter.transform.localPosition = new Vector2(maincharakter.transform.localPosition.x, maincharakter.transform.localPosition.y - 225);
                dirtycharakter.SetActive(false);
                healthycharakter.SetActive(true);
                healthycharakter.transform.localPosition = new Vector2(-254, -255);
                sand = true;
                sandLoesung.SetActive(true);
            }
        }
        else
        {
            showAndHideBubbleWithText("Es sieht nicht so aus das deine Figuren hier durch können");
        }
    }

    void showAndHideBubbleWithText(string showedText)
    {
        Text text = message.GetComponent<Text>();
        helpBubble.SetActive(true);
        StartCoroutine(LastCall());
        text.text = showedText;
        LastCall();
        StopCoroutine(LastCall());
    }

    IEnumerator LastCall()
    {
        yield return new WaitForSeconds(5);
        helper.transform.localPosition = new Vector2(280,0);
        helpBubble.transform.localPosition = new Vector2(114,0);
        helper.transform.localScale = new Vector2(1,1);
        helpBubble.SetActive(false);
    }
}
