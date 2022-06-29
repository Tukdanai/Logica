using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class LoadGame : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject saveSlotGameObject;
    [SerializeField] GameObject loadSlotGameObject;
    [SerializeField] GameObject mainMenuGameObject;
    [SerializeField] GameObject Player;
    [SerializeField] private Button loadGameButton;
    [SerializeField] AudioSource Click;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Click.Play();
        loadSlotGameObject.SetActive(true);
        saveSlotGameObject.SetActive(false);
        mainMenuGameObject.SetActive(false);
    }
}
