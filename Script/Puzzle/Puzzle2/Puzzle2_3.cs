using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Puzzle2_3 : MonoBehaviour
{
    [SerializeField] GameObject PuzzleWindow;
    [SerializeField] PlayerController player;
    [SerializeField] Inventory inventory;
    [SerializeField] Puzzle2Box puzzleBox1;
    [SerializeField] Puzzle2Box puzzleBox2;
    [SerializeField] Puzzle2Box puzzleBox3;
    [SerializeField] Puzzle2Box puzzleBox4;
    [SerializeField] Puzzle2Box puzzleBox5;
    [SerializeField] Pillar pillar;
    [SerializeField] PuzzleActivate puzzleActivate;
    [SerializeField] ResetButtonManager resetManager;
    [SerializeField] GameObject gate;
    [SerializeField] Animator gateAnimator;
    [SerializeField] Animator spike2Animator;
    public Item A;
    public Item B;
    public Item ORGate;
    public Item NOTGate;
    [SerializeField] AudioSource SpikeSound;
    private bool playSound;
    [SerializeField] AudioSource GateSound;
    
    void Start()
    {
        gateAnimator.SetBool("Open",false);
        gate.SetActive(false);
        playSound = true;
    }

    void Update()
    {
        if(puzzleActivate.Activated == true && puzzleBox1.boxSlot[0].Item != null && puzzleBox2.boxSlot[0].Item != null && puzzleBox3.boxSlot[0].Item != null && puzzleBox4.boxSlot[0].Item != null && puzzleBox5.boxSlot[0].Item != null)
        {
            PuzzleWindow.SetActive(false);
            foreach(Item item1 in puzzleBox1.GetBoxItemList())
            {
                if(item1.ItemName == "A")
                {
                    foreach(Item item2 in puzzleBox2.GetBoxItemList())
                    {
                        if(item2.ItemName == "Plus")
                        {
                            foreach(Item item3 in puzzleBox3.GetBoxItemList())
                            {
                                if(item3.ItemName == "Bar")
                                {
                                    foreach(Item item4 in puzzleBox4.GetBoxItemList())
                                    {
                                        if(item4.ItemName == "A")
                                        {
                                            foreach(Item item5 in puzzleBox5.GetBoxItemList())
                                            {
                                                if(item5.ItemName == "B")
                                                {
                                                    pillar.isCorrect = true;
                                                    player.isCameraLocked = false;
                                                    player.canMove = true;
                                                    player.WaitForCanPause();
                                                    inventory.RemoveItem(A);
                                                    inventory.RemoveItem(ORGate);
                                                    inventory.RemoveItem(NOTGate);
                                                    inventory.RemoveItem(A);
                                                    inventory.RemoveItem(B);
                                                    gate.SetActive(true);
                                                    GateSound.Play();
                                                    gateAnimator.SetBool("Open",true);
                                                }
                                                else
                                                {
                                                    StartCoroutine(SpikeAnimation());
                                                }
                                            }
                                        }
                                        else
                                        {
                                            StartCoroutine(SpikeAnimation());
                                        }
                                    }
                                }
                                else
                                {
                                    StartCoroutine(SpikeAnimation());
                                }
                            }
                        }
                        else
                        {
                            StartCoroutine(SpikeAnimation());
                        }
                    }
                }
                else
                {
                    StartCoroutine(SpikeAnimation());
                }
            }
            puzzleActivate.Activated = false;
        }
        if(puzzleActivate.Activated == true && (puzzleBox1.boxSlot[0].Item == null || puzzleBox2.boxSlot[0].Item == null || puzzleBox3.boxSlot[0].Item == null || puzzleBox4.boxSlot[0].Item == null || puzzleBox5.boxSlot[0].Item == null))
        {
            puzzleActivate.Activated = false;
        }

        if(PuzzleWindow.activeSelf == false)
        {
            if(puzzleBox1.itemInBox.Count == 1) 
            {
                puzzleBox1.itemInBox.Clear();
                puzzleBox1.boxSlot[0].Item = null;
            }
            if(puzzleBox2.itemInBox.Count == 1) 
            {
                puzzleBox2.itemInBox.Clear();
                puzzleBox2.boxSlot[0].Item = null;
            }
            if(puzzleBox3.itemInBox.Count == 1) 
            {
                puzzleBox3.itemInBox.Clear();
                puzzleBox3.boxSlot[0].Item = null;
            }
            if(puzzleBox4.itemInBox.Count == 1) 
            {
                puzzleBox4.itemInBox.Clear();
                puzzleBox4.boxSlot[0].Item = null;
            }
            if(puzzleBox5.itemInBox.Count == 1) 
            {
                puzzleBox5.itemInBox.Clear();
                puzzleBox5.boxSlot[0].Item = null;
            }
        }

        if(resetManager.isResetAnswer == true)
        {
            if(puzzleBox1.itemInBox.Count == 1) 
            {
                puzzleBox1.itemInBox.Clear();
                puzzleBox1.boxSlot[0].Item = null;
            }
            if(puzzleBox2.itemInBox.Count == 1) 
            {
                puzzleBox2.itemInBox.Clear();
                puzzleBox2.boxSlot[0].Item = null;
            }
            if(puzzleBox3.itemInBox.Count == 1) 
            {
                puzzleBox3.itemInBox.Clear();
                puzzleBox3.boxSlot[0].Item = null;
            }
            if(puzzleBox4.itemInBox.Count == 1) 
            {
                puzzleBox4.itemInBox.Clear();
                puzzleBox4.boxSlot[0].Item = null;
            }
            if(puzzleBox5.itemInBox.Count == 1) 
            {
                puzzleBox5.itemInBox.Clear();
                puzzleBox5.boxSlot[0].Item = null;
            }
            resetManager.isResetAnswer = false;
        }
    }

    public IEnumerator SpikeAnimation()
    {
        if(SpikeSound.isPlaying == false && playSound == true) SpikeSound.Play();
        playSound = false;
        spike2Animator.SetBool("Activate",true);
        spike2Animator.SetBool("Deactivate",false);
        yield return new WaitForSeconds(1f);
        spike2Animator.SetBool("Activate",false);
        spike2Animator.SetBool("Deactivate",true);
        playSound = true;
    }
}
