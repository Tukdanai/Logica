using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class Exit : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Button exitButton;
    [SerializeField] AudioSource Click;

    public void OnPointerDown(PointerEventData eventData)
    {
        Click.Play();
        Application.Quit();
        Debug.Log("Game Closed!");
    }
}
