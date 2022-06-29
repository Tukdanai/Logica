using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSenseInput : MonoBehaviour
{
    [SerializeField] GameObject rabbitSenseGameObject;
    [SerializeField] GameObject wireGameObject;
    [SerializeField] GameObject Player;

    void Start()
    {
        rabbitSenseGameObject.SetActive(false);
        wireGameObject.SetActive(false);
    }
    
    void Update()
    {
        if(Player.activeSelf)   
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                rabbitSenseGameObject.SetActive(true);
                wireGameObject.SetActive(true);
            }
            if(Input.GetKeyUp(KeyCode.V))
            {
                rabbitSenseGameObject.SetActive(false);
                wireGameObject.SetActive(false);
            }
        }
    }
}
