using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Tutorial : MonoBehaviour
{
    [SerializeField] GameObject puzzle;
    [SerializeField] GameObject puzzleArea;
    [SerializeField] AudioSource PopUp;

    void Start()
    {
        puzzle.SetActive(false);
        puzzleArea.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PopUp.Play();
            StartCoroutine(Puzzle());
        }   
    }

    public IEnumerator Puzzle()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        puzzle.SetActive(true);
        yield return new WaitForSeconds(15f);
        puzzle.SetActive(false);
        Destroy(puzzleArea); 
    }
}