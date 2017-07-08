using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countClicksCloud : MonoBehaviour {

    public GameObject fog1;
    public GameObject fog2;
    public GameObject sunshine13;
    public GameObject wind;
    public Animator animator;
    
    private int countClicks = 0;

    public void OnMouseDown()
    {
        animator.speed = countClicks/4;
        wind.SetActive(true);
        countClicks++;
        Debug.Log(countClicks);
    }

    private void Update()
    {
        float Geschwindigkeit = countClicks/5;
        var Richtung = new Vector3(1f, 0f, 0f);
        if (sunshine13.activeSelf)
        {
            fog1.transform.position += Richtung * Geschwindigkeit * Time.deltaTime;
            fog2.transform.position += Richtung * Geschwindigkeit * Time.deltaTime;
        }
    }
}
