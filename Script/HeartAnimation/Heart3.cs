using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Heart3 : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject Heart;
    [SerializeField] public SpriteRenderer HeartSpriteRenderer;
    Animator animator;
    public bool isNormalTransparent;
    public bool setNormalTransparent;

    private Color normalTransparent = new Color(1f, 1f, 1f, 1f);
    private Color zeroTransparent = new Color(1f, 1f, 1f, 0f);

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        isNormalTransparent = true;
        setNormalTransparent = false;
    }

    void Update()
    {
        if(HeartSpriteRenderer.color == zeroTransparent)
        {
            isNormalTransparent = false;
        }
        if(HeartSpriteRenderer.color != zeroTransparent)
        {
            isNormalTransparent = true;
            setNormalTransparent = false;
        }
        if(player.health >= 3 && isNormalTransparent == false && player.getHP == true)
        {
            animator.SetBool("GetHeart",true);
            StartCoroutine(AfterGet());
        }
        if(player.health < 3 && isNormalTransparent == true)
        {
            animator.SetBool("HeartBroke",true);
            StartCoroutine(AfterBroke());
        }
    }

    public IEnumerator AfterGet()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("GetHeart",false);
        player.getHP = false;
        setNormalTransparent = true;
    }

    public IEnumerator AfterBroke()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("HeartBroke",false);
        Heart.SetActive(false);
    }
}
