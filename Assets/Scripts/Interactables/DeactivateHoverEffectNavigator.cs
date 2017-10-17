using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DeactivateHoverEffectNavigator : MonoBehaviour
{
    private Image image;

    void Start ()
    {
        image = gameObject.GetComponent<Image>();
        image.enabled = false;
    }
}
