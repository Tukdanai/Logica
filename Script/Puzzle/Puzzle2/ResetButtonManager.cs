using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ResetButtonManager : MonoBehaviour
{
    [SerializeField] GameObject PuzzleWindow;
    [SerializeField] GameObject ResetButton;
    [SerializeField] PuzzleReset puzzleReset;
    [SerializeField] Pillar pillar;
    public bool isResetAnswer;

    void Update()
    {
        if(PuzzleWindow.activeSelf == true)
        {
            ResetButton.SetActive(true);
        }
        if(PuzzleWindow.activeSelf == false)
        {
            ResetButton.SetActive(false);
        }
        if(puzzleReset.isReset ==  true)
        {
            pillar.ResetPuzzle();
            puzzleReset.isReset = false;
            isResetAnswer = true;
            PuzzleWindow.SetActive(true);
        }
    }
}
