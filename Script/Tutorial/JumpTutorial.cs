using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTutorial : MonoBehaviour
{
    [SerializeField] GameObject jump;
    [SerializeField] GameObject jumpArea;
    [SerializeField] AudioSource PopUp;

    void Start()
    {
        jump.SetActive(false);
        jumpArea.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PopUp.Play();
            StartCoroutine(jumpUI());
        }   
    }

    public IEnumerator jumpUI()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        jump.SetActive(true);
        yield return new WaitForSeconds(3f);
        jump.SetActive(false);
        Destroy(jumpArea); 
    }
}