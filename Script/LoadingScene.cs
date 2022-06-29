using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] GameObject LoadScene;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject LoadingUI;
    [SerializeField] GameObject animation1;
    [SerializeField] GameObject animation2;
    [SerializeField] GameObject animation3;

    void Start()
    {
        player.canMove = false;
        player.canAttack = false;
        player.canPause = false;
        player.canHelp = false;
        LoadScene.SetActive(true);
        LoadingUI.SetActive(true);
        animation1.SetActive(false);
        animation2.SetActive(false);
        animation3.SetActive(false);
        StartCoroutine(LoadingAnimation());
    }

    public IEnumerator LoadingAnimation()
    {
        player.canMove = false;
        player.canAttack = false;
        player.canPause = false;
        player.canHelp = false;
        animation1.SetActive(true);
        animation2.SetActive(false);
        animation3.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        animation2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        animation3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        animation2.SetActive(false);
        animation3.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        animation2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        animation3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LoadScene.SetActive(false);
        player.canMove = true;
        player.canAttack = true;
        player.canPause = true;
        player.canHelp = true;
    }
}
