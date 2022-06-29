using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Lever : MonoBehaviour
{
    [SerializeField] Animator leverAnimator;
    private bool IsCollided;
    public bool Activated;
    public bool CanTakeDamage;
    [SerializeField] AudioSource PullLever;

    void Start() 
    {
        leverAnimator.SetBool("Activate",false);
        Activated = false;
    }

    void Update()
    {
        if(IsCollided == true && Input.GetKeyDown(KeyCode.E))
        {   
            StartCoroutine(LeverAnimation());
        }
        if(PullLever.isPlaying == false && Activated == true) PullLever.Play();
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            IsCollided = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        IsCollided = false;
    }

    public IEnumerator LeverAnimation()
    {
        CanTakeDamage = true;
        leverAnimator.SetBool("Activate",true);
        Activated = true;
        yield return new WaitForSeconds(1f);
        leverAnimator.SetBool("Activate",false);
        Activated = false;
    }
}