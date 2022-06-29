using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSenseTutorial : MonoBehaviour
{
    [SerializeField] GameObject rabbitSense;
    [SerializeField] GameObject rabbitSenseArea;
    [SerializeField] AudioSource PopUp;

    void Start()
    {
        rabbitSense.SetActive(false);
        rabbitSenseArea.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PopUp.Play();
            StartCoroutine(rabbitSenseUI());
        }   
    }

    public IEnumerator rabbitSenseUI()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        rabbitSense.SetActive(true);
        yield return new WaitForSeconds(5f);
        rabbitSense.SetActive(false);
        Destroy(rabbitSenseArea); 
    }
}