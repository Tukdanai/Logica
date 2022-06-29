using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] QuickSlotsPanel quickSlotsPanel;
    [SerializeField] PlayerController player;
    public Item item;  
    [SerializeField] AudioSource PickupItem;
    [SerializeField] AudioSource PickupHeart;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player") && item.ItemName != "Heart")
        {
            if(!inventory.IsFull() && !item.cantPickUp)
            {
                PickupItem.Play();
                inventory.AddItem(item); 
                Destroy(gameObject); 
                quickSlotsPanel.IsAutoAddToQuickSlot(item);
            }                                        
        }   
        else if(collision.gameObject.CompareTag("Player") && item.ItemName == "Heart")
        {
            PickupHeart.Play();
            player.health = 5;
            player.getHP = true;
            Destroy(gameObject);            
        }   
    }

}
