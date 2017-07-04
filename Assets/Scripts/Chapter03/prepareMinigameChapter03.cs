using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prepareMinigameChapter03 : MonoBehaviour, INotifiableHandler
{
    public UIHandler UI;
    public GameObject informationScene;
    public GameObject minigameScene;
    public GameObject startMinigameButton;
    public GameObject message;
    public GameObject helpBubble;
    public GameObject helper;

    private bool[] checkIfAllInformationObjectAlreadyRead = new bool[6];

    void Start()
    {
        minigameScene.SetActive(false);

        Text text = message.GetComponent<Text>();
        helpBubble.SetActive(true);
        StartCoroutine(LastCall(2));
        helper.transform.localScale = new Vector2(3, 3);
        helper.transform.localPosition = new Vector2(0, -200);
        helpBubble.transform.localPosition = new Vector2(-150, -100);
        text.text = "Lorem Ipsum";
        StopCoroutine("LastCall");

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
            if (list[i].alreadyRead)
            {
                checkIfAllInformationObjectAlreadyRead[i] = true;
                for (int j = 0; j < checkIfAllInformationObjectAlreadyRead.Length; j++)
                {
                    if (checkIfAllInformationObjectAlreadyRead[j] == true && checkIfAllInformationObjectAlreadyRead[j + 1] == true && checkIfAllInformationObjectAlreadyRead[j + 2] == true && checkIfAllInformationObjectAlreadyRead[j + 3] == true && checkIfAllInformationObjectAlreadyRead[j + 4] == true && checkIfAllInformationObjectAlreadyRead[j + 5] == true)
                    {
                        startMinigameButton.SetActive(true);
                        return;
                    }
                }
            }
        }
    }

    public void startMinigame()
    {
        informationScene.SetActive(false);
        startMinigameButton.SetActive(false);
        minigameScene.SetActive(true);
    }

    IEnumerator LastCall(int time)
    {
        yield return new WaitForSeconds(time);
        helper.transform.localPosition = new Vector2(268, 0);
        helpBubble.transform.localPosition = new Vector2(0, 0);
        helper.transform.localScale = new Vector2(1, 1);
        helpBubble.SetActive(false);
    }
}
