using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Close : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject currentOpenPage;
    [SerializeField] AudioSource CloseUI;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        CloseUI.Play();
        currentOpenPage.SetActive(false);
    }
}
