using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PuzzleReset : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject PuzzleWindow;
    public bool isReset;
    [SerializeField] AudioSource Click;

    void Start()
    {
        isReset = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Click.Play();
        PuzzleWindow.SetActive(false);
        isReset = true;
    }
}
