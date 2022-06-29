using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTutorial : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject inventoryArea;
    [SerializeField] AudioSource PopUp;

    void Start()
    {
        inventory.SetActive(false);
        inventoryArea.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PopUp.Play();
            StartCoroutine(inventoryUI());
        }   
    }

    public IEnumerator inventoryUI()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        inventory.SetActive(true);
        yield return new WaitForSeconds(3f);
        inventory.SetActive(false);
        Destroy(inventoryArea); 
    }
}