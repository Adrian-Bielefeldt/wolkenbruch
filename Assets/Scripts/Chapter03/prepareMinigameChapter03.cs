using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prepareMinigameChapter03 : MonoBehaviour, INotifiableHandler
{
    public UIHandler UI;
    public GameObject informationScene;
    public GameObject minigameScene;
    public GameObject message;
    public GameObject helpBubble;
    public GameObject helper;

    void Start()
    {

        Text text = message.GetComponent<Text>();
        UI.displayMinigameButton(false);

        helpBubble.SetActive(true);
        text.text = "Endlich sind wir im See angekommen. Schau dich auch hier um damit wir die letzte Etappe meistern können.";

        minigameScene.SetActive(false);
        Interactable_Information[] list = informationScene.GetComponentsInChildren<Interactable_Information>();
        foreach (Interactable_Information interactable in list)
        {
            interactable.handler = this;
        }
    }

    public void notifyChange()
    {
        Interactable_Information[] list = informationScene.GetComponentsInChildren<Interactable_Information>();
        for (int i = 0; i < list.Length; i++)
        {
            if (!list[i].alreadyRead)
            {
                return;
            }
        }
        UI.displayMinigameButton(true);
    }

    public void startMinigame()
    {
        informationScene.SetActive(false);
        minigameScene.SetActive(true);
    }
}
