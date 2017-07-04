using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ActivateHoverEffectNavigator : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler {

    public Image image;
    private String name;

    public void Start()
    {
        image.enabled = true;
        name = image.name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject go = GameObject.Find(name + " Hover");
        go.GetComponent<Image>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject go = GameObject.Find(name + " Hover");
        go.GetComponent<Image>().enabled = false;
    }
}
