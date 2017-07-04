using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonne : MonoBehaviour {
    public GameObject strahl1;
    public GameObject strahl2;
    public GameObject strahl3;
    public GameObject strahl4;
    public GameObject strahl5;
    public GameObject strahl6;
    public GameObject strahl7;
    public GameObject strahl8;
    public GameObject strahl9;
    public GameObject strahl10;
    public GameObject strahl11;
    public GameObject strahl12;
    public GameObject strahl13;

    // Use this for initialization
    void Start()
    {
        strahl1.SetActive(false);
        strahl2.SetActive(false);
        strahl3.SetActive(false);
        strahl4.SetActive(false);
        strahl5.SetActive(false);
        strahl6.SetActive(false);
        strahl7.SetActive(false);
        strahl8.SetActive(false);
        strahl9.SetActive(false);
        strahl10.SetActive(false);
        strahl11.SetActive(false);
        strahl12.SetActive(false);
        strahl13.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos);
            if (transform.rotation.z >= 0)
            {
                if (transform.rotation.z >= 27)
                {
                    strahl1.SetActive(true);
                    strahl2.SetActive(true);
                    return;
                }
                strahl1.SetActive(true);
            }
        }
    }
}
