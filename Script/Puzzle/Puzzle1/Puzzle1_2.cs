using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Puzzle1_2 : MonoBehaviour
{
    [SerializeField] PuzzleBox puzzleBox1;
    [SerializeField] PuzzleBox puzzleBox2;
    [SerializeField] PuzzleBox puzzleBox3;
    [SerializeField] Lever lever;
    [SerializeField] Animator spikeAnimator;
    [SerializeField] GameObject Light;
    [SerializeField] GameObject RockGate;
    [SerializeField] MainCameraController mainCamera;
    private bool canOpenGate;
    [SerializeField] AudioSource SpikeSound;
    private bool playSound;
    [SerializeField] AudioSource EarthQuakeSound;
    [SerializeField] AudioSource RockRollingSound;
    [SerializeField] AudioSource OpenLightSound;
    private bool playEarth;
    private bool playRock;
    private bool playLight;
    
    void Start()
    {
        puzzleBox1 = puzzleBox1.GetComponent<PuzzleBox>();
        puzzleBox2 = puzzleBox2.GetComponent<PuzzleBox>();
        puzzleBox3 = puzzleBox3.GetComponent<PuzzleBox>();
        puzzleBox1.Correct = false;
        puzzleBox3.Correct = false;
        Light.SetActive(false);
        playSound = true;
        playEarth = true;
        playRock = true;
        playLight = true;
        canOpenGate = true;
    }

    void Update()
    {
        if(lever.Activated == true && puzzleBox1.boxSlot[0].Item != null && puzzleBox3.boxSlot[0].Item != null)
        {
            foreach(Item item1 in puzzleBox1.GetBoxItemList())
            {
                if(item1.ItemName == "Logic 1")
                {
                    foreach(Item item2 in puzzleBox2.GetBoxItemList())
                    {
                        if(item2.ItemName == "Logic 1")
                        {
                            foreach(Item item3 in puzzleBox3.GetBoxItemList())
                            {
                                if(item3.ItemName == "Logic AND")
                                {
                                    if(canOpenGate == true) StartCoroutine(OpenGate());
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

    public IEnumerator OpenGate()
    {
        if(playEarth == true) EarthQuakeSound.Play();
        playEarth = false;
        mainCamera.ScreenShake(true,1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(CountDownLight());
        if(playRock == true) RockRollingSound.Play();
        playRock = false;
        RockGate.transform.Translate(new Vector3(10f, 0f, 0f) * (Time.deltaTime/1.22f), Camera.main.transform);
        RockGate.transform.Rotate(new Vector3(0f, 0f, -1f));
        yield return new WaitForSeconds(1.6f);
        Light.SetActive(true);
        puzzleBox1.Correct = true;
        puzzleBox3.Correct = true;
        canOpenGate = false;
    }

    public IEnumerator CountDownLight()
    {
        yield return new WaitForSeconds(1.2f);
        if(playLight == true) OpenLightSound.Play();
        playLight = false;
    }
}