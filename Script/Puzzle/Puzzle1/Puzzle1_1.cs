using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Puzzle1_1 : MonoBehaviour
{
    [SerializeField] PuzzleBox puzzleBox1;
    [SerializeField] Lever lever;
    [SerializeField] Animator gateAnimator;
    [SerializeField] Animator spikeAnimator;
    [SerializeField] GameObject EButton;
    [SerializeField] AudioSource SpikeSound;
    private bool playSound;
    [SerializeField] AudioSource GateSound;
    
    void Start()
    {
        puzzleBox1 = puzzleBox1.GetComponent<PuzzleBox>();
        puzzleBox1.Correct = false;
        gateAnimator.SetBool("Open",false);
        EButton.SetActive(false);
        playSound = true;
    }

    void Update()
    {
        if(puzzleBox1.boxSlot[0].Item == null || puzzleBox1.Correct == true)
        {
            EButton.SetActive(false);
        }
        foreach(Item item1 in puzzleBox1.GetBoxItemList())
        {
            if(item1.ItemName == "Logic 0" && puzzleBox1.Correct == false && puzzleBox1.boxSlot[0].Item != null)
            {
                EButton.SetActive(true);
            }
            
        }
        if(lever.Activated == true && puzzleBox1.Correct == false && puzzleBox1.boxSlot[0].Item != null)
        {
            foreach(Item item1 in puzzleBox1.GetBoxItemList())
            {
                if(item1.ItemName == "Logic 0")
                {
                    puzzleBox1.Correct = true;
                    GateSound.Play();
                    gateAnimator.SetBool("Open",true);
                }
                else
                {
                    StartCoroutine(SpikeAnimation());
                }
            }
        }
    }

    public IEnumerator SpikeAnimation()
    {
        if(SpikeSound.isPlaying == false && playSound == true) SpikeSound.Play();
        playSound = false;
        spikeAnimator.SetBool("Activate",true);
        spikeAnimator.SetBool("Deactivate",false);
        yield return new WaitForSeconds(1f);
        spikeAnimator.SetBool("Activate",false);
        spikeAnimator.SetBool("Deactivate",true);
        playSound = true;
    }
}
