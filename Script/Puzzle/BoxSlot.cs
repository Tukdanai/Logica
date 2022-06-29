using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BoxSlot : MonoBehaviour
{
    [SerializeField] public Image image;
    
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

    protected virtual void OnValidate() 
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
    }
}
