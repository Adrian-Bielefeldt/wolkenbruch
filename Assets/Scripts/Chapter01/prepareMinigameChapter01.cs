using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prepareMinigameChapter01 : MonoBehaviour, INotifiableHandler
{
    public UIHandler UI;
    public GameObject informationScene;
    public GameObject minigameScene;
    public GameObject erdeSolution;
    public GameObject humusSolution;
    public GameObject kiesSolution;
    public GameObject lehmSolution;
    public GameObject message;
    public GameObject helpBubble;
    public GameObject helper;

    void Start()
    {
        minigameScene.SetActive(false);

        Text text = message.GetComponent<Text>();
        helpBubble.SetActive(true);
        text.text = "Wo sind wir den hier gelandet? Vielleicht sollten wir uns die Gegend mal näher ansehen.";
        
        Interactable_Information[] list = informationScene.GetComponentsInChildren<Interactable_Information>();
        foreach (Interactable_Information interactable in list)
        {
            interactable.handler = this;
        }
    }

    public void notifyChange()
    {
        Interactable_Information[] list = informationScene.GetComponentsInChildren<Interactable_Information>();
        for(int i = 0; i < list.Length; i++)
        {
            if (!list[i].alreadyRead)
            {
				return;
            }
        }
		Debug.Log ("Start Minigame");
		UI.displayMinigameButton (true);
    }

    public void startMinigame()
    {
        informationScene.SetActive(false);
        minigameScene.SetActive(true);
        erdeSolution.SetActive(false);
        humusSolution.SetActive(false);
        kiesSolution.SetActive(false);
        lehmSolution.SetActive(false);
}
}
