using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class JKBoss2 : MonoBehaviour
{
    public int health;
    public Slider sliderHP;
    public Animator animator;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject Boss;
    [SerializeField] JK2 puzzle;
    [SerializeField] AudioSource BossDisappeared;

    void Start()
    {
        animator = Boss.GetComponent<Animator>();
        health = 5;
        sliderHP.maxValue = 5;
        StartCoroutine(ToRock());
    }


    void Update()
    {
        health = player.JKBossHP;
        sliderHP.value = health;
    }

    public IEnumerator ToRock()
    {
        yield return new WaitForSeconds(3.8f);
        BossDisappeared.Play();
        animator.SetBool("Transform", true);
        yield return new WaitForSeconds(1.8f);
        animator.SetBool("Transform", false);
        Boss.SetActive(false);
        puzzle.Gate0GameObject.SetActive(true);
        puzzle.Gate1GameObject.SetActive(true);
        puzzle.Gate2GameObject.SetActive(true);
        puzzle.Gate3GameObject.SetActive(true);
    }
}
