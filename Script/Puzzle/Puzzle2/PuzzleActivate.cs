using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PuzzleActivate : MonoBehaviour, IPointerDownHandler
{
    public bool Activated;
    [SerializeField] AudioSource Click;

    void Start()
    {
        Activated = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Click.Play();
        Activated = true;
    }
}
