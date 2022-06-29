using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject quickSlot;
    public Inventory inventory;
    public QuickSlotsPanel quickSlotsPanel;
    [SerializeField] AudioSource equipItem;
    [SerializeField] AudioSource unequipItem;

    private void Awake() 
    {
        inventory.OnRightClickEvent += EquipFromInventory;
        quickSlotsPanel.OnRightClickEvent += UnEquipFromQuickSlot;
        //inventory.OnLeftClickEvent += EquipFromInventory;
        //quickSlotsPanel.OnLeftClickEvent += UnEquipFromQuickSlot;
    }

  /*  void Update() //for using Input.mousePosition
    {
        Vector3 mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);
    }
*/
    private void EquipFromInventory(InventorySlots itemSlot)
    { 
        if(!itemSlot.Item.ItemInPuzzle2 && quickSlot.activeSelf == true)
        {
            equipItem.Play();
            Equip((Item)itemSlot.Item);
        }
    }

    private void UnEquipFromQuickSlot(InventorySlots itemSlot)
    {
        unequipItem.Play();
        UnEquip((Item)itemSlot.Item);
    }
    
    public void Equip(Item item)
    {
        if(inventory.RemoveItem(item) && !item.ItemInPuzzle2 && quickSlot.activeSelf == true)
        {
            quickSlotsPanel.AddQuickSlotItem(item);
        }
    }

    public void UnEquip(Item item)
    {
        if(quickSlotsPanel.RemoveQuickSlotItem(item))
        {
            inventory.AddItem(item);
        }
    }
}


