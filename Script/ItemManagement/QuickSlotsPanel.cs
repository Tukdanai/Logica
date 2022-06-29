using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class QuickSlotsPanel : MonoBehaviour
{
    [SerializeField] public List<Item> quickSlotItems;
    [SerializeField] Transform quickSlotParent;
    public QuickSlots[] quickSlots;
    [SerializeField] Inventory inventory;

    public event Action<InventorySlots> OnRightClickEvent;
    //public event Action<InventorySlots> OnLeftClickEvent;

    private void Start() //use Start() to prevent this event set to null in some case.
    {
        for(int i = 0; i < quickSlots.Length; i++)
        {
            quickSlots[i].OnRightClickEvent += OnRightClickEvent;
            //quickSlots[i].OnLeftClickEvent += OnLeftClickEvent;
        }
    }

    private void OnValidate()
    {
        if(quickSlotParent != null)
        {
            quickSlots = quickSlotParent.GetComponentsInChildren<QuickSlots>();
        }
        RefreshQuickSlotUI();
    }

    private void RefreshQuickSlotUI()
    {
        int i = 0;
        for(; i < quickSlotItems.Count && i < quickSlots.Length; i++)
        {
            quickSlots[i].Item = quickSlotItems[i];
            if(quickSlotItems[i] == null)
            {
                quickSlotItems.Remove(quickSlotItems[i]);
            }
        }

        for(; i < quickSlots.Length; i++)
        {
            quickSlots[i].Item = null;
        }
    }

    public bool AddQuickSlotItem(Item item)
    {
        for(int i = 0; i < quickSlots.Length; i++)
        {
            if(quickSlots[i].Item == item)
            {
                quickSlotItems.Add(item); 
                quickSlots[i].Amount++; //for UI
                quickSlots[i].UpdateAmount();
                //Debug.Log("Stack");
                return true;
            }
        }
        for(int i = 0; i < quickSlots.Length; i++)
        {
            if(quickSlots[i].Item == null && !item.ItemInPuzzle2)
            {
                quickSlots[i].Item = item;
                quickSlotItems.Add(item);  
                quickSlots[i].Amount = 1; //for UI
                //Debug.Log("NoStack");
                quickSlots[i].UpdateAmount();
                //RefreshQuickSlotUI();
                return true;
            }
        }  
        return false;
    }

    public void IsAutoAddToQuickSlot(Item item)
    {
        for(int i = 0; i < quickSlots.Length; i++)
        {
            if(quickSlots[i].Item == item)
            {
                quickSlotItems.Add(item); 
                quickSlots[i].Amount++; //for UI
                quickSlots[i].UpdateAmount();
                //Debug.Log("Auto add to QuickSlot");
                inventory.RemoveItem(item);
            }
        }
    }

    public bool RemoveQuickSlotItem(Item item)
    {
        for(int i = 0; i < quickSlots.Length; i++)
        {
            if(quickSlots[i].Item == item)
            {
                quickSlots[i].Amount--; //for UI
                quickSlots[i].UpdateAmount();
                quickSlotItems.Remove(item);
                if(quickSlots[i].Amount <= 0)
                {
                    quickSlots[i].Item = null;
                    quickSlots[i].Amount = 0; // for UI
                    quickSlots[i].UpdateAmount();
                    //RefreshUI();
                    //Debug.Log("Empty");
                    return true;
                }
                return true;
            }
        }
        return false;
    }

    public void RemoveQSItem(Item item)
    {
       quickSlotItems.Remove(item);
    }
}
