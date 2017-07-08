using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigameChapter03 : MonoBehaviour
{
    public GameObject[] Sonnenstrahlen = new GameObject[13];
    public GameObject Sonne;
    public GameObject fog1;
    public GameObject fog2;
    public GameObject wind;
    public UIHandler UI;
    public GameObject message;
    public GameObject helper;
    public GameObject helpBubble;
    public GameObject charakter;

    private int NumberOfDeactivatedSunshine;
    private bool stopChangeSunshine = false;
    private bool ifFogIsInPosition = false;
	private bool showTextOneTime = false;

    // Use this for initialization
    void Start()
    {
        UI.displayMinigameButton(false);
        Text text = message.GetComponent<Text>();
        helpBubble.SetActive(true);
        StartCoroutine(LastCall(8));
        helper.transform.localScale = new Vector2(3, 3);
        helper.transform.localPosition = new Vector2(0, -200);
        helpBubble.transform.localPosition = new Vector2(-200, -200);
        text.text = "Wie können wir Verdunsten? Ich habe gehört die Sonne dreht sich gerne nach links.";
		helper.GetComponent<Helper> ().currentHelp = "Wir sollten verdunsten, indem wir die Sonne aufdrehen. Und wenn zuviel Wasserdampf vor uns aufsteigt, pusten wir ihn einfach mit den Wolken weg.";
        StopCoroutine("LastCall");        
        
        wind.SetActive(false);
        fog1.SetActive(false);
        fog2.SetActive(false);
        foreach (GameObject strahl in Sonnenstrahlen)
        {
            strahl.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var Geschwindigkeit = 4f;
        var Richtungrechts = new Vector3(1f, 0f, 0f);
        var RichtunngCharakter = new Vector3(-0.5f, 1f, 0f);
        if (stopChangeSunshine == false)
        {
            if (Input.GetMouseButton(0))
            {
                NumberOfDeactivatedSunshine = 13 - (int)Sonne.transform.eulerAngles.z / 27;

                for (int i = 0; i < Sonnenstrahlen.Length - NumberOfDeactivatedSunshine; i++)
                {
                    Sonnenstrahlen[i].SetActive(true);
                    Sonnenstrahlen[i + NumberOfDeactivatedSunshine].SetActive(false);
                    if (Sonnenstrahlen[11].activeSelf)
                    {
                        Sonnenstrahlen[12].SetActive(true);
                        fog1.transform.position = new Vector3(-12, -0.7835863f, 0);
                        fog2.transform.position = new Vector3(-7f, -2.1f, 0);
                        fog1.SetActive(true);
                        fog2.SetActive(true);
                        stopChangeSunshine = true;
                    }
                }
            }
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Sonne.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos);
        }
        if (fog1.transform.position.x <= -1)
        {
            fog1.transform.position += Richtungrechts * Geschwindigkeit * Time.deltaTime;
            fog2.transform.position += Richtungrechts * Geschwindigkeit * Time.deltaTime;
        }else if(fog1.transform.position.x >= 9f && charakter.transform.position.y <= 2)
        {
            charakter.transform.position += RichtunngCharakter * 0.5f * Time.deltaTime;
            charakter.transform.localScale = new Vector2(charakter.transform.localScale.x * 0.99f, charakter.transform.localScale.y * 0.99f);
		}else if(charakter.transform.position.y >= 02 && showTextOneTime == false)
        {
			wind.SetActive (false);
            UI.displayQuizButton(true);
			NavigatorData.achievedPointsGame [3] = 2;
            Text text = message.GetComponent<Text>();
            helpBubble.SetActive(true);
            StartCoroutine(LastCall(10));
            helper.transform.localScale = new Vector2(4, 4);
            helper.transform.localPosition = new Vector2(0, -200);
            helpBubble.transform.localPosition = new Vector2(-200, -200);
            text.text = "Juhu du hast das Rätsel gelöst. Schließe nun das Quiz ab um das letzte Kapitel zu starten";
            StopCoroutine("LastCall");
			showTextOneTime = true;
        }
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
