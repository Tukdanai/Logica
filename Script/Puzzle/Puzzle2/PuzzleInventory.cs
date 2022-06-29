using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PuzzleInventory : MonoBehaviour
{
    [SerializeField] public List<Item> puzzleItems;
    public PuzzleSlot[] puzzleItemSlots;
    public Item Bar;
    public Item Multiply;
    public Item Plus;
    public Item Boolean_0;
    public Item Boolean_1;

    public void SetUpPuzzleInventory()
    {
        for(int i = 0; i < puzzleItems.Count; i++)
        {
            if(puzzleItems[i] != null)
            {
                if(puzzleItems[i].ItemName == "Logic NOT")
                {
                    puzzleItems[i] = Bar;
                }
                else if(puzzleItems[i].ItemName == "Logic AND")
                {
                    puzzleItems[i] = Multiply;
                }
                else if(puzzleItems[i].ItemName == "Logic OR")
                {
                    puzzleItems[i] = Plus;
                }
                else if(puzzleItems[i].ItemName == "Logic 0")
                {
                    puzzleItems[i] = Boolean_0;
                }
                else if(puzzleItems[i].ItemName == "Logic 1")
                {
                    puzzleItems[i] = Boolean_1;
                }
            }
        }
        for(int i = 0; i < puzzleItems.Count; i++)
        {
            if(puzzleItems[i] != null && puzzleItems[i].ItemInPuzzle2 == false)
            {
                puzzleItems.Remove(puzzleItems[i]);
                i -= 1;
            }
        }
        for(int i = 0; i < puzzleItems.Count; i++)
        {
            if(puzzleItems[i] != null && puzzleItems[i].ItemInPuzzle2 == true)
            {
                AddPuzzleInventoryItem(puzzleItems[i]);
            }
        }
    }

    public void ClearAllItem()
    {
        if(puzzleItems.Count > 0)
        {
            puzzleItems.Clear();
            for(int i = 0; i < puzzleItemSlots.Length; i++)
            {
                puzzleItemSlots[i].Item = null;
                puzzleItemSlots[i].Amount = 0;
                puzzleItemSlots[i].UpdateAmount();
            }
        }
    }

    public bool AddPuzzleInventoryItem(Item item)
    {
        for(int i = 0; i < puzzleItemSlots.Length; i++)
        {
            if(puzzleItemSlots[i].Item == item)
            {
                puzzleItemSlots[i].Amount++; //for UI
                puzzleItemSlots[i].UpdateAmount();
                //Debug.Log("Stack");
                return true;
            }
        }
        for(int i = 0; i < puzzleItemSlots.Length; i++)
        {
            if(puzzleItemSlots[i].Item == null)
            {
                puzzleItemSlots[i].Item = item;  
                puzzleItemSlots[i].Amount = 1; //for UI
                //Debug.Log("NoStack");
                puzzleItemSlots[i].UpdateAmount();
                //RefreshQuickSlotUI();
                return true;
            }
        }  
        return false;
    }

    public bool RemovePuzzleInventoryItem(Item item)
    {
        for(int i = 0; i < puzzleItemSlots.Length; i++)
        {
            if(puzzleItemSlots[i].Item == item)
            {
                puzzleItemSlots[i].Amount--; //for UI
                puzzleItemSlots[i].UpdateAmount();
                puzzleItems.Remove(item);
                if(puzzleItemSlots[i].Amount <= 0)
                {
                    puzzleItemSlots[i].Item = null;
                    puzzleItemSlots[i].Amount = 0; // for UI
                    puzzleItemSlots[i].UpdateAmount();
                    //RefreshUI();
                    //Debug.Log("Empty");
                    return true;
                }
                return true;
            }
        }
        return false;
    }
}
