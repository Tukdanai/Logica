using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class Intro : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GoToMainMenu());
    }

    public IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GamePlay");
    }
}
