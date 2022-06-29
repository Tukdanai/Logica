using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTutorial : MonoBehaviour
{
    [SerializeField] GameObject attack;
    [SerializeField] GameObject attackArea;
    [SerializeField] AudioSource PopUp;

    void Start()
    {
        attack.SetActive(false);
        attackArea.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PopUp.Play();
            StartCoroutine(walkUI());
        }   
    }

    public IEnumerator walkUI()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        attack.SetActive(true);
        yield return new WaitForSeconds(2f);
        attack.SetActive(false);
        Destroy(attackArea); 
    }
}