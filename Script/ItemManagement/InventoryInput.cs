using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject inventoryGameObject;
    [SerializeField] KeyCode toggleInventoryKey;
    [SerializeField] AudioSource OpenInventory;
    [SerializeField] AudioSource CloseInventory;

    void Start()
    {
        inventoryGameObject.SetActive(false);
    }
    
    void Update()
    {   
        if(Input.GetKeyDown(toggleInventoryKey))
        {
            if(inventoryGameObject.activeSelf == false) OpenInventory.Play();
            else if(inventoryGameObject.activeSelf == true) CloseInventory.Play();
            inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
        }
    }
}
