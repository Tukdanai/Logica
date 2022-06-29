using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[CreateAssetMenu]

public class Item : ScriptableObject
{
    public enum ItemType 
    {
        Logic_0,
        Logic_1,
        Logic_AND,
        Logic_OR,
        Logic_NOT,
        Logic_NAND,
        Logic_NOR,
        Logic_XOR,
        Logic_XNOR,
        Var_A,
        Var_B,
        Var_C,
        Bar,
        Plus,
        Multiply,
        Open_Bracket,
        Close_Bracket,
        Boolean_0,
        Boolean_1,
        Heart,
    }

    public ItemType itemType;
    public string ItemName;
    public bool ItemInPuzzle2;
    public bool cantPickUp;
    public Sprite Icon;
}
