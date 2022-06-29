using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class InventorySlots : MonoBehaviour, IPointerClickHandler
{
    public event Action<InventorySlots> OnRightClickEvent;
    //public event Action<InventorySlots> OnLeftClickEvent;

    [SerializeField] Inventory inventory;
    [SerializeField] QuickSlotsPanel quickSlotsPanel;
    [SerializeField] Image image;
    [SerializeField] GameObject inventoryGameObject; //for Toggle open the Inventory
    [SerializeField] protected TextMeshProUGUI amountText;

    public static InventorySlots instance;

    private Item _item;
    public Item Item 
    {
        get { return _item; }
        set 
        { 
            _item = value;
            if(_item == null)
            {
                image.sprite = null;
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }

    [SerializeField] public int Amount; //for UI

    public void UpdateAmount()
    {
        if(Amount <= 0)
        {
            amountText.enabled = false;
            Amount = 0;
        }
        else
        {
            amountText.enabled = true;
            amountText.text = Amount.ToString();
        }
        
    }

    private void Awake()
    {
        instance = this;
    }

    protected virtual void OnValidate() 
    {
        if(image == null)
        {
            image = GetComponent<Image>();       
        }   
        if(amountText == null)
        {
            amountText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right && inventoryGameObject.activeSelf)
        {
            if(OnRightClickEvent != null)
            {
                OnRightClickEvent(this);
            }
            /*else if(OnLeftClickEvent != null)
            {
                OnLeftClickEvent(this);
            }*/
        }
    }
}
