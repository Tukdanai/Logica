using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour
{
    public bool UnchangeableBox;
    [SerializeField] public List<Item> itemInBox;
    [SerializeField] Inventory inventory;
    [SerializeField] QuickSlotsPanel quickSlotsPanel;
    [SerializeField] public BoxSlot[] boxSlot;
    private Item previousItem;
    private bool IsCollided;
    public bool Correct;
    [SerializeField] AudioSource BoxFill;
    [SerializeField] AudioSource RemoveBoxItem;
    
    void Update()
    {
        if(UnchangeableBox == false && Correct == false) //if the puzzle is not solved yet.
        {
            if(Input.GetKeyDown(KeyCode.Alpha1) && IsCollided == true)
            {
                AddBoxItem(quickSlotsPanel.quickSlots[0].Item, 0);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2) && IsCollided == true)
            {
                AddBoxItem(quickSlotsPanel.quickSlots[1].Item, 1);
            }
            if(Input.GetKeyDown(KeyCode.Alpha3) && IsCollided == true)
            {
                AddBoxItem(quickSlotsPanel.quickSlots[2].Item, 2);
            }
            if(Input.GetKeyDown(KeyCode.Alpha4) && IsCollided == true)
            {
                AddBoxItem(quickSlotsPanel.quickSlots[3].Item, 3);
            }
            if(Input.GetKeyDown(KeyCode.Alpha5) && IsCollided == true)
            {
                AddBoxItem(quickSlotsPanel.quickSlots[4].Item, 4);
            }
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

    public bool AddBoxItem(Item item, int i)
    {
        if(boxSlot[0].Item == null && item != null)
        {
            if(BoxFill.isPlaying == false && UnchangeableBox == false) BoxFill.Play();
            itemInBox.Add(item);
            boxSlot[0].Item = item;  
            previousItem = (Item)boxSlot[0].Item;
            quickSlotsPanel.RemoveQuickSlotItem(item);
            return true;
        }
        else if(boxSlot[0].Item != null && item != previousItem && item != null)
        {
            if(BoxFill.isPlaying == false && UnchangeableBox == false) BoxFill.Play();
            itemInBox.Add(item);
            boxSlot[0].Item = item;  
            quickSlotsPanel.RemoveQuickSlotItem(item);

            inventory.AddItem(previousItem);
            quickSlotsPanel.IsAutoAddToQuickSlot(previousItem);
            itemInBox.Remove(previousItem);
            previousItem = (Item)boxSlot[0].Item;
            return true;
        }
        if(boxSlot[0].Item != null && item == null)
        {
            if(RemoveBoxItem.isPlaying == false && UnchangeableBox == false) RemoveBoxItem.Play();
            for(int j = 0; j < quickSlotsPanel.quickSlots.Length; j++) //if there a same ItemName already in Quickslots.
            {
                if(quickSlotsPanel.quickSlots[j].Item == boxSlot[0].Item)
                {
                    quickSlotsPanel.quickSlotItems.Add(boxSlot[0].Item);
                    quickSlotsPanel.quickSlots[j].Amount++;
                    quickSlotsPanel.quickSlots[j].UpdateAmount();
                    itemInBox.Remove(boxSlot[0].Item);
                    boxSlot[0].Item = null;
                    return true;
                }
            }
            quickSlotsPanel.quickSlotItems.Add(boxSlot[0].Item);
            quickSlotsPanel.quickSlots[i].Item = boxSlot[0].Item;
            quickSlotsPanel.quickSlots[i].Amount = 1;
            quickSlotsPanel.quickSlots[i].UpdateAmount();
            itemInBox.Remove(boxSlot[0].Item);
            boxSlot[0].Item = null;
            return true;
        }
        return false;
    }

    public List<Item> GetBoxItemList()
    {
        return itemInBox;
    }
}
