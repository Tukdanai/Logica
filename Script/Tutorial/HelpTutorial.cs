using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpTutorial : MonoBehaviour
{
    [SerializeField] GameObject help;
    [SerializeField] GameObject helpArea;
    [SerializeField] AudioSource PopUp;

    void Start()
    {
        help.SetActive(false);
        helpArea.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PopUp.Play();
            StartCoroutine(helpUI());
        }   
    }

    public IEnumerator helpUI()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        help.SetActive(true);
        yield return new WaitForSeconds(3f);
        help.SetActive(false);
        Destroy(helpArea); 
    }
}