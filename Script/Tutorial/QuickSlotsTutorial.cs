using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotsTutorial : MonoBehaviour
{
    [SerializeField] GameObject quickSlots;
    [SerializeField] GameObject quickSlotsArea;
    [SerializeField] AudioSource PopUp;

    void Start()
    {
        quickSlots.SetActive(false);
        quickSlotsArea.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PopUp.Play();
            StartCoroutine(quickSlotsUI());
        }   
    }

    public IEnumerator quickSlotsUI()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        quickSlots.SetActive(true);
        yield return new WaitForSeconds(5f);
        quickSlots.SetActive(false);
        Destroy(quickSlotsArea); 
    }
}