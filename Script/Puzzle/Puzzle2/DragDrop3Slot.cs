using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DragDrop3Slot : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    [SerializeField] Puzzle2Box puzzleBox1;
    [SerializeField] Puzzle2Box puzzleBox2;
    [SerializeField] Puzzle2Box puzzleBox3;
    private CanvasGroup canvasGroup;
    public Item item;
    [SerializeField] PuzzleInventory puzzleInventory;
    public PuzzleSlot puzzleSlot;
    Vector3 StartPosition;
    [SerializeField] PlayerController player;
    [SerializeField] AudioSource PuzzleBoxFill;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if(puzzleSlot != null) item = puzzleSlot.Item;
        if(Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2)) player.canClosePuzzle = false;
        else player.canClosePuzzle = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartPosition = rectTransform.anchoredPosition;
        puzzleBox1.isDropped = false;
        puzzleBox2.isDropped = false;
        puzzleBox3.isDropped = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        HideMouseCursor();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition += eventData.delta / 60;
        rectTransform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rectTransform.position = new Vector3(rectTransform.position.x,rectTransform.position.y,0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = StartPosition;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        CheckBoxToAdd();
        ShowMouseCursor();
    }

    public void CheckBoxToAdd()
    {
        if(puzzleBox1.isDropped == true && puzzleBox1.itemInBox.Count == 0)
        {
            PuzzleBoxFill.Play();
            puzzleBox1.itemInBox.Add(item);
            puzzleBox1.boxSlot[0].Item = item;
            puzzleBox1.boxSlot[0].image.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            if(item != null && item.ItemName != "Close_Bracket" && item.ItemName != "Open_Bracket")
            {
                puzzleInventory.RemovePuzzleInventoryItem(item);
            }
        }
        else if(puzzleBox2.isDropped == true && puzzleBox2.itemInBox.Count == 0)
        {
            PuzzleBoxFill.Play();
            puzzleBox2.itemInBox.Add(item);
            puzzleBox2.boxSlot[0].Item = item;
            puzzleBox2.boxSlot[0].image.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            if(item != null && item.ItemName != "Close_Bracket" && item.ItemName != "Open_Bracket")
            {
                puzzleInventory.RemovePuzzleInventoryItem(item);
            }
        }
        else if(puzzleBox3.isDropped == true && puzzleBox3.itemInBox.Count == 0)
        {
            PuzzleBoxFill.Play();
            puzzleBox3.itemInBox.Add(item);
            puzzleBox3.boxSlot[0].Item = item;
            puzzleBox3.boxSlot[0].image.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            if(item != null && item.ItemName != "Close_Bracket" && item.ItemName != "Open_Bracket")
            {
                puzzleInventory.RemovePuzzleInventoryItem(item);
            }
        }
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
    }

    public void HideMouseCursor()
    {
        Cursor.visible = false;
    }
}
