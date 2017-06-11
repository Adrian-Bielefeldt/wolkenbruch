using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInformation : MonoBehaviour {

    public GameObject informationBox;
    public GameObject cancel;
    public GameObject message;
    public GameObject toMinigame;
    public GameObject minigame;
    public GameObject house;
    public GameObject backgroundMinigame;

    private int activateMinigameIfItsFive = 0;

    void Start ()
    {
        minigame.SetActive(false);
        toMinigame.SetActive(false);
        informationBox.SetActive(false);
    }
	
    public void ShowInformation()
    {
        house.SetActive(false);
        informationBox.SetActive(true);
    }

    public void HideInformation()
    {
        house.SetActive(true);
        activateMinigameIfItsFive++;
        informationBox.SetActive(false);
        showButtonToStartMinigame();
    }

    public void OnClicked(Button button)
    {
        Text text = message.GetComponent<Text>();

        if (button.name == "PlusIconHouse")
        {
            text.text = "Wie kommt Wasser zu unserem Haus? Zuerst wird Wasser aus Quellen, Flüssen etc. geschöpft. Danach wird es gereinigt und in den Hochbehälter gepumpt. Dann befindet sich es in der Fallleitung und später im Wasserhahn.";
        }
        else if (button.name == "PlusIconFlower")
        {
            text.text = "Der Tau entsteht, wenn der Wasserdampf der Luft auf kältere Dinge am Boden trifft. Es passiert zum Beispiel am Morgen, wenn der Wasserdampf an kalter Oberfläche vom Gras (nach der Nacht) flüssig wird.";
        }
        else if(button.name == "PlusIconBones")
        {
            text.text = "Durch den sich immer wiederholenden Kreislauf des Wassers in der Natur geht nämlich kein Wasser verloren, es kommt aber auch keins hinzu. Das Wasser kann nur seinen Aggregatszustand wechseln, es gibt drei: Eis, Wasser, Wasserdampf. Die Wasservorräte der Erde sind festgelegt, deshalb soll man mit Wasser vorsichtig umgehen und nicht unnötig trinkbares Wasser verschwenden.";  
        }
        else if (button.name == "PlusIconMountain")
        {
            text.text = "Berge sind ein natürliches Hindernis für die Wolken. Wenn der Wind die Wolken treibt, dann besteht einzige Möglichkeit für Wolken darin, sich zu heben. Dadurch sinkt die Temperatur und die Teilchen vom Wasserdampf werden grösser und es regnet. Deswegen gibt es in bergischer Landschaft nur auf einer Seite von Bergen sehr oft die Niederschläge, auf anderer Seite dagegen regnet es selten.";
        }
        else if(button.name == "PlusIconGras")
        {
            text.text = "Bei einer Verdunstung geht ein Stoff vom flüssigen in den gasförmigen Zustand über, ohne dabei die Siedetemperatur zu erreichen. Transpiration ist eine spezielle Art von der Verdunstung - über die Blätter der Pflanzen. ";
        }
        else
        {
            text.text = "Grundwasser sieht man normalerweise nicht, denn es befindet sich unter der Erde. Das Wasser, das versickert, wird durch Schichten gesäubert. Felsen, Ton und Lehm gehören zu den wasserundurchlässigen Schichten, befinden sich unter dem Grundwasserschicht. Humus, Kies, Sand gehören zu den wasserdurchlässigen Schichten und befinden sich über dem Grundwasserschicht. Das Grundwasser kann zu einer Quelle werden und als Trinkwasser verwendet werden oder der Ursprung des Flusses werden und dann ins Meer münden.";
        }
    }

    void showButtonToStartMinigame()
    {
        if (activateMinigameIfItsFive == 6)
        {
            toMinigame.SetActive(true);
        }
    }
}
