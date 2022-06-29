using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable] public class SavedData
{
    public int saveSlot;
    public int playerHealth;
    public float playerPositionX;
    public float playerPositionY;
    public bool isPlayerHaveSword;
    public int lastOpenedPage;

    public string saveChapter;
    public string saveLocation;
    public string saveDateTime;
    public float playedTime;
    public bool isCurrentPlayingSlot;
    public bool LoadScene;

    [SerializeField] public List<Item> MyItems;
    [SerializeField] public List<Item> MyQuickSlotItems;

    public int wrongAnswerInLogicBoss;
    public int wrongAnswerInBooleanBoss;
    public int wrongAnswerInJKBoss;
    public int HPofJKBoss;
    public bool canSaveChapter3;
}