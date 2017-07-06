﻿using System.Collections;
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

    private bool erde = false;
    private bool humus = false;
    private bool kies = false;
    private bool sand = false;

    // Use this for initialization
    void Start () {
        healthyCharacter.SetActive(false);

        Text text = message.GetComponent<Text>();
        helpBubble.SetActive(true);
        StartCoroutine(LastCall(10));
        Debug.Log("test");
        helper.transform.localScale = new Vector2(4, 4);
        helper.transform.localPosition = new Vector2(0, -200);
        helpBubble.transform.localPosition = new Vector2(-200, -200);
        text.text = "Der Hauptcharakter muss ins Grundwasser gelangen um seine Freunde zu finden. Hilf ihm indem du die richtigen Schichten auswählst. ACHTUNG in einigen Schichten bleibt er stecken.";
        StopCoroutine("LastCall");
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
                showAndHideBubbleWithText("Anscheinend erscheint vorher eine andere Schicht");
            }
            else
            {
                changeLocationCharakter(0.7f);
                kies = true;
                kiesSolution.SetActive(true);
            }
        }
        else if (button.name == "sand")
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
                changeLocationCharakter(1.7f);
                StartCoroutine(LastCall(10));
                StopCoroutine("LastCall");
                dirtyCharacter.SetActive(false);
                healthyCharacter.SetActive(true);
                sand = true;
                sandSolution.SetActive(true);
            }
        }
        else
        {
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
        StartCoroutine(LastCall(5));
        text.text = showedText;
        StopCoroutine("LastCall");
    }

    IEnumerator LastCall(int time)
    {
        yield return new WaitForSeconds(time);
        helper.transform.localPosition = new Vector2(250, 0); 
        helpBubble.transform.localPosition = new Vector2(114, 0);
        helper.transform.localScale = new Vector2(1, 1);
        helpBubble.SetActive(false);
    }
}