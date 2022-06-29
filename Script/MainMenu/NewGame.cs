using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class NewGame : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject saveSlotGameObject;
    [SerializeField] GameObject loadSlotGameObject;
    [SerializeField] GameObject mainMenuGameObject;
    [SerializeField] GameObject Player;
    [SerializeField] private Button newGameButton;
    [SerializeField] AudioSource Click;
    [SerializeField] GameObject LoadScene;
    
    void Start()
    {
        LoadScene.SetActive(false);
        saveSlotGameObject.SetActive(false);
        loadSlotGameObject.SetActive(false);
        Player.SetActive(false);
        Time.timeScale = 1f;
    }   

    public void OnPointerDown(PointerEventData eventData)
    {
        Click.Play();
        loadSlotGameObject.SetActive(false);
        saveSlotGameObject.SetActive(true);
        mainMenuGameObject.SetActive(false);
    }
}
