using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Next : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] HelpPage helpPage;
    [SerializeField] GameObject currentOpenPage;
    public int currentPage;
    [SerializeField] AudioSource ChangePage;

    public void OnPointerDown(PointerEventData eventData)
    {
        ChangePage.Play();
        helpPage.OpenPage(currentPage+1);
        currentOpenPage.SetActive(false);
    }
}
