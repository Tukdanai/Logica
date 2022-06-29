using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public enum QuickSlotNumber
{
    QuickSlot1,
    QuickSlot2,
    QuickSlot3,
    QuickSlot4,
    QuickSlot5,
}

public class QuickSlots : InventorySlots
{
    public QuickSlotNumber QuickSlotNumber;


    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name =  QuickSlotNumber.ToString();
    }

}
