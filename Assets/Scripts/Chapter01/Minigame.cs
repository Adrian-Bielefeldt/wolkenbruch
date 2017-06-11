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
        StartCoroutine(LastCall());
        helpBubble.SetActive(true);
        helper.transform.localScale = new Vector2(4, 4);
        helper.transform.localPosition = new Vector2(0, -200);
        helpBubble.transform.localPosition = new Vector2(-200, -200);
        text.text = "Der Hauptcharakter muss ins Grundwasser gelangen um seine Freunde zu finden. Hilf ihm indem du die richtigen Schichten auswählst. ACHTUNG in einigen Schichten bleibt er stecken.";
        LastCall();
        StopCoroutine(LastCall());
    }
    public void StartingKonfiguration()
    { 
        panelInformation.SetActive(false);
        backgroundInformation.SetActive(false);
        informationItems.SetActive(false);
        toMinigame.SetActive(false);
        minigame.SetActive(true);
        erdeLoesung.SetActive(false);
        humusLoesung.SetActive(false);
        kiesLoesung.SetActive(false);
        sandLoesung.SetActive(false);
        healthycharakter.SetActive(false);
        helpBubble.SetActive(false);

    }

    public void showAnswer(Button button)
    {
        Text text = message.GetComponent<Text>();

        if (button.name == "erde")
        {
            if(erde == true)
            {
                StartCoroutine(LastCall());
                helpBubble.SetActive(true);
                text.text = "Diese Schicht wurde bereits ausgewählt";
                LastCall();
                StopCoroutine(LastCall());
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
            StartCoroutine(LastCall());
            helpBubble.SetActive(true);
            text.text = "Es sieht nicht so aus das deine Figuren hier durch können";
            LastCall();
            StopCoroutine(LastCall());
        }
        else if(button.name == "humus")
        {
            if (humus == true)
            {
                StartCoroutine(LastCall());
                helpBubble.SetActive(true);
                text.text = "Diese Schicht wurde bereits ausgewählt";
                LastCall();
                StopCoroutine(LastCall());
            }
            else if(erde == false)
            {
                StartCoroutine(LastCall());
                helpBubble.SetActive(true);
                text.text = "Anscheinend erscheint vorher eine andere Schicht";
                LastCall();
                StopCoroutine(LastCall());
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
                StartCoroutine(LastCall());
                helpBubble.SetActive(true);
                text.text = "Diese Schicht wurde bereits ausgewählt";
                LastCall();
                StopCoroutine(LastCall());
            }
            else if (humus == false)
            {
                StartCoroutine(LastCall());
                helpBubble.SetActive(true);
                text.text = "Anscheinend erscheint vorher eine andere Schicht";
                LastCall();
                StopCoroutine(LastCall());
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
                StartCoroutine(LastCall());
                helpBubble.SetActive(true);
                text.text = "Diese Schicht wurde bereits ausgewählt";
                LastCall();
                StopCoroutine(LastCall());
            }
            else if (kies == false)
            {
                StartCoroutine(LastCall());
                helpBubble.SetActive(true);
                text.text = "Anscheinend erscheint vorher eine andere Schicht";
                LastCall();
                StopCoroutine(LastCall());
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
            StartCoroutine(LastCall());
            helpBubble.SetActive(true);
            text.text = "Es sieht nicht so aus das deine Figuren hier durch können";
            LastCall();
            StopCoroutine(LastCall());
        }
    }
    IEnumerator LastCall()
    {
        Debug.Log("hi");
        yield return new WaitForSeconds(5);
        helper.transform.localPosition = new Vector2(280,0);
        helpBubble.transform.localPosition = new Vector2(114,0);
        helper.transform.localScale = new Vector2(1,1);
        helpBubble.SetActive(false);
    }
}
