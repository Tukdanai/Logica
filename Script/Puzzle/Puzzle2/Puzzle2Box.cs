using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Puzzle2Box : MonoBehaviour, IDropHandler
{
    [SerializeField] public List<Item> itemInBox;
    [SerializeField] public BoxSlot[] boxSlot;
    public bool isDropped;

    void Start()
    {
        isDropped = false;
    }
    
    void Update()
    {
        if(boxSlot[0].Item == null)
        {
            boxSlot[0].image.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            boxSlot[0].image.enabled = true;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        isDropped = true;
    }

    public List<Item> GetBoxItemList()
    {
        return itemInBox;
    }
}
