using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitGameButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] AudioSource Click;

    public void OnPointerDown(PointerEventData eventData)
    {
        Click.Play();
        Application.Quit();
        Debug.Log("Game Closed!");
    }
}
