using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLever : MonoBehaviour
{
    [SerializeField] Cannon cannon;
    [SerializeField] public GameObject noPower;
    [SerializeField] public GameObject green;
    [SerializeField] public GameObject red;
    [SerializeField] AudioSource Lever;
    public bool IsCollided;
    public bool canPress;
    public Animator greenAnimator;
    public Animator redAnimator;
    [SerializeField] GameObject helpNoPower;
    [SerializeField] AudioSource PopUp;

    void Start()
    {
        canPress = true;
        noPower.SetActive(true);
        green.SetActive(false);
        red.SetActive(false);
        greenAnimator = green.GetComponent<Animator>();
        redAnimator = red.GetComponent<Animator>();
        helpNoPower.SetActive(false);
    }

    void Update()
    {
        if(IsCollided == true && Input.GetKeyDown(KeyCode.E))
        {
            if(noPower.activeSelf == true && canPress == true && helpNoPower.activeSelf == false)
            {
                StartCoroutine(NoPower());
            }
            else if(green.activeSelf == true && canPress == true)
            {
                canPress = false;
                Lever.Play();
                StartCoroutine(GreenLeverAnimation());
            }
            else if(red.activeSelf == true && canPress == true)
            {
                canPress = false;
                Lever.Play();
                StartCoroutine(RedLeverAnimation());
            }
        }

        if(green.activeSelf == true || red.activeSelf == true) noPower.SetActive(false);

        if(noPower.activeSelf == true)
        {
            green.SetActive(false);
            red.SetActive(false);
        }
  
    }

    public IEnumerator GreenLeverAnimation()
    {
        greenAnimator.SetBool("Activate", true);
        yield return new WaitForSeconds(0.9f);
        greenAnimator.SetBool("Activate", false);
        cannon.green.SetActive(true);
        cannon.red.SetActive(false);
        red.SetActive(true);
        green.SetActive(false);
        canPress = true;
    }

    public IEnumerator RedLeverAnimation()
    {
        redAnimator.SetBool("Activate", true);
        yield return new WaitForSeconds(0.9f);
        cannon.red.SetActive(true);
        cannon.green.SetActive(false);
        redAnimator.SetBool("Activate", false);
        red.SetActive(false);
        green.SetActive(true);
        canPress = true;
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

    public IEnumerator NoPower()
    {
        PopUp.Play();
        helpNoPower.SetActive(true);
        yield return new WaitForSeconds(2f);
        helpNoPower.SetActive(false);
    }
}
