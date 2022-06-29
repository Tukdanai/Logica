using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PuzzleClose : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject PuzzleWindow;
    [SerializeField] PuzzleInventory puzzleInventory;
    [SerializeField] PlayerController player;
    [SerializeField] AudioSource CloseUI;

    public void OnPointerDown(PointerEventData eventData)
    {
        CloseUI.Play();
        puzzleInventory.ClearAllItem();
        player.isCameraLocked = false;
        player.canMove = true;
        player.WaitForCanPause();
        PuzzleWindow.SetActive(false);
    }
}
