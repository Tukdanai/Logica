using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTutorial : MonoBehaviour
{
    [SerializeField] GameObject walk;
    [SerializeField] GameObject walkArea;
    [SerializeField] AudioSource PopUp;

    void Start()
    {
        walk.SetActive(false);
        walkArea.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(walkUI());
        }   
    }

    public IEnumerator walkUI()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        yield return new WaitForSeconds(3f);
        PopUp.Play();
        walk.SetActive(true);
        yield return new WaitForSeconds(3f);
        walk.SetActive(false);
        Destroy(walkArea); 
    }
}