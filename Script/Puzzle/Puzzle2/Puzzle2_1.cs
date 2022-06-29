using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Puzzle2_1 : MonoBehaviour
{
    [SerializeField] GameObject PuzzleWindow;
    [SerializeField] PlayerController player;
    [SerializeField] Inventory inventory;
    [SerializeField] Puzzle2Box puzzleBox1;
    [SerializeField] Puzzle2Box puzzleBox2;
    [SerializeField] Pillar pillar;
    [SerializeField] PuzzleActivate puzzleActivate;
    [SerializeField] ResetButtonManager resetManager;
    [SerializeField] Animator gateAnimator;
    [SerializeField] Animator spike2Animator;
    [SerializeField] GameObject EButton;
    public Item NOTGate;
    public Item Logic_1;
    [SerializeField] AudioSource SpikeSound;
    private bool playSound;
    [SerializeField] AudioSource GateSound;

    void Start()
    {
        gateAnimator.SetBool("Open",false);
        EButton.SetActive(true);
        playSound = true;
    }

    void Update()
    {
        if(puzzleActivate.Activated == true && puzzleBox1.boxSlot[0].Item != null && puzzleBox2.boxSlot[0].Item != null)
        {
            PuzzleWindow.SetActive(false);
            foreach(Item item1 in puzzleBox1.GetBoxItemList())
            {
                if(item1.ItemName == "Bar")
                {
                    foreach(Item item2 in puzzleBox2.GetBoxItemList())
                    {
                        if(item2.ItemName == "Boolean 1")
                        {
                            pillar.isCorrect = true;
                            EButton.SetActive(false);
                            player.isCameraLocked = false;
                            player.canMove = true;
                            player.WaitForCanPause();
                            inventory.RemoveItem(NOTGate);
                            inventory.RemoveItem(Logic_1);
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
            puzzleActivate.Activated = false;
            
        }
        if(puzzleActivate.Activated == true && (puzzleBox1.boxSlot[0].Item == null || puzzleBox2.boxSlot[0].Item == null ))
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
