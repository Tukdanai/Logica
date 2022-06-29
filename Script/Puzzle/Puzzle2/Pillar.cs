using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Pillar : MonoBehaviour
{
    [SerializeField] GameObject PuzzleWindow;
    [SerializeField] PlayerController player;
    [SerializeField] Inventory inventory;
    [SerializeField] PuzzleInventory puzzleInventory;
    [SerializeField] public List<Item> defaultItems;
    private bool IsCollided;
    public bool CanTakeDamage;
    public bool isCorrect;
    public bool wrongAnswer;
    public bool canOpen;
    [SerializeField] AudioSource OpenPuzzlePage;
    [SerializeField] AudioSource CloseUI;
    [SerializeField] GameObject Menu;
    [SerializeField] HelpPage helpPage;

    void Start() 
    {
        PuzzleWindow.SetActive(false);
        isCorrect = false;
        wrongAnswer = false;
        canOpen = true;
    }

    void Update()
    {
        if(IsCollided == true && Input.GetKeyDown(KeyCode.E) && isCorrect == false && canOpen == true && PuzzleWindow.activeSelf == false)
        {   
            OpenPuzzlePage.Play();
            CanTakeDamage = true;
            for(int i = 0; i < inventory.items.Count; i++) //add items from inventory.
            {
                if(inventory.items[i] != null)
                {
                    defaultItems.Add(inventory.items[i]);
                }
            }
            puzzleInventory.ClearAllItem();
            for(int i = 0; i < defaultItems.Count; i++) //add items to puzzleInventory.
            {
                if(defaultItems[i] != null)
                {
                    puzzleInventory.puzzleItems.Add(defaultItems[i]);
                }
            }
            puzzleInventory.SetUpPuzzleInventory();
            PuzzleWindow.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && PuzzleWindow.activeSelf == true && player.canClosePuzzle == true && Menu.activeSelf == false && helpPage.isHelpPageOpen == false)
        {
            CloseUI.Play();
            puzzleInventory.ClearAllItem();
            player.isCameraLocked = false;
            player.canMove = true;
            player.WaitForCanPause();
            PuzzleWindow.SetActive(false);
        }
        if(PuzzleWindow.activeSelf == true)
        {
            player.canMove = false;
            player.isCameraLocked = true;
            player.canPause = false;
        }
        if(PuzzleWindow.activeSelf == false)
        {
            defaultItems.Clear();
        }
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            IsCollided = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        IsCollided = false;
    }

    public void ResetPuzzle()
    {
        CanTakeDamage = true;
        defaultItems.Clear();
        for(int i = 0; i < inventory.items.Count; i++) //add items from inventory.
        {
            if(inventory.items[i] != null)
            {
                defaultItems.Add(inventory.items[i]);
            }
        }
        puzzleInventory.ClearAllItem();
        for(int i = 0; i < defaultItems.Count; i++) //add items to puzzleInventory.
        {
            if(defaultItems[i] != null)
            {
                puzzleInventory.puzzleItems.Add(defaultItems[i]);
            }
        }
        puzzleInventory.SetUpPuzzleInventory();
    }

    public void DelayOpen()
    {
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        canOpen = false;
        yield return new WaitForSeconds(1.85f);
        canOpen = true;
    }
}