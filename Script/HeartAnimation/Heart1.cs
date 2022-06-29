using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart1 : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject Heart;
    Animator animator;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(player.health < 1 && Heart.activeSelf == true)
        {
            animator.SetBool("HeartBroke",true);
            StartCoroutine(AfterBroke());
        }
    }

    public IEnumerator AfterBroke()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("HeartBroke",false);
        Heart.SetActive(false);
    }
}
