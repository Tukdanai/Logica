using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBoolean4 : MonoBehaviour
{
    [SerializeField] GameObject HelpBoolean4Page;
    [SerializeField] GameObject HelpBoolean4Area;
    [SerializeField] HelpPage helpPage;
    private bool pageChanged;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource ChangePage;

    void Start()
    {
        HelpBoolean4Area.SetActive(true);
        pageChanged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(helpPage.lastSeenPage != 12) 
            {
                if(helpPage.isHelpPageOpen == true)
                {
                    ChangePage.Play();
                    pageChanged = true;
                }
                helpPage.CloseCurrentPage();
            }
            if(pageChanged == false && helpPage.isHelpPageOpen == false) OpenHelpPage.Play();
            HelpBoolean4Page.SetActive(true);
            Destroy(HelpBoolean4Area); 
        }   
    }
}