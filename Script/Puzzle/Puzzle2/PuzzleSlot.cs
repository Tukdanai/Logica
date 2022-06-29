using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class PuzzleSlot : MonoBehaviour
{
    [SerializeField] PuzzleInventory puzzleInventory;
    [SerializeField] Image image;
    [SerializeField] protected TextMeshProUGUI amountText;

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
}
