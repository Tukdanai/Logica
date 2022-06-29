using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;
//using UnityEngine.Serialization;

[Serializable] public class Inventory : MonoBehaviour
{   
    //[FormerlySerializedAs("startingItems")] //for change the name of List.

    [SerializeField] public List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] public InventorySlots[] itemSlots;

    public event Action<InventorySlots> OnRightClickEvent;
    //public event Action<InventorySlots> OnLeftClickEvent;

    private void Start() //use Start() to prevent this event set to null in some case. 
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            //itemSlots[i].OnLeftClickEvent += OnLeftClickEvent;
        }
        //items.Clear(); //Clear All Items in Inventory
        RefreshUI();
    }

    private void OnValidate()
    {
        if(itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<InventorySlots>();
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        int i = 0;  
        for(; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
            if(items[i] == null)
            {
                items.Remove(items[i]);
            }
        }
        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {   
            if(itemSlots[i].Item == item)
            {
                itemSlots[i].Amount++; //for UI
                itemSlots[i].UpdateAmount();
                items.Add(item);
                //Debug.Log("Stack");
                return true;
            }
        }
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].Item == null)
            {
                itemSlots[i].Item = item;   
                items.Add(item);
                itemSlots[i].Amount = 1; //for UI
                //Debug.Log("NoStack");
                //RefreshUI();
                itemSlots[i].UpdateAmount();
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].Item == item)
            {
                itemSlots[i].Amount--; //for UI
                itemSlots[i].UpdateAmount();
                items.Remove(item);
                if(itemSlots[i].Amount <= 0)
                {
                    itemSlots[i].Item = null;
                    itemSlots[i].UpdateAmount();
                    //RefreshUI();
                    //Debug.Log("Empty");
                    return true;
                }
                return true;
            }
        }  
        return false;
    }

    public bool IsFull()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

}
