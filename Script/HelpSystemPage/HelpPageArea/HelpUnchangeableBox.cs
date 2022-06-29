using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpUnchangeableBox : MonoBehaviour
{
    [SerializeField] GameObject HelpUnchangeableBoxPage;
    [SerializeField] GameObject HelpUnchangeableBoxArea;
    [SerializeField] HelpPage helpPage;
    private bool pageChanged;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource ChangePage;

    void Start()
    {
        HelpUnchangeableBoxArea.SetActive(true);
        pageChanged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(helpPage.lastSeenPage != 9) 
            {
                if(helpPage.isHelpPageOpen == true)
                {
                    ChangePage.Play();
                    pageChanged = true;
                }
                helpPage.CloseCurrentPage();
            }
            if(pageChanged == false && helpPage.isHelpPageOpen == false) OpenHelpPage.Play();
            HelpUnchangeableBoxPage.SetActive(true);
            Destroy(HelpUnchangeableBoxArea);
        }   
    }
}