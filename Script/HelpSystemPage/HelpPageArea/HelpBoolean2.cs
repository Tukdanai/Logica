using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBoolean2 : MonoBehaviour
{
    [SerializeField] GameObject HelpBoolean2Page;
    [SerializeField] GameObject HelpBoolean2Area;
    [SerializeField] HelpPage helpPage;
    private bool pageChanged;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource ChangePage;

    void Start()
    {
        HelpBoolean2Area.SetActive(true);
        pageChanged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player")) 
        {
            if(helpPage.lastSeenPage != 14) 
            {
                if(helpPage.isHelpPageOpen == true)
                {
                    ChangePage.Play();
                    pageChanged = true;
                }
                helpPage.CloseCurrentPage();
            }
            if(pageChanged == false && helpPage.isHelpPageOpen == false) OpenHelpPage.Play();
            HelpBoolean2Page.SetActive(true);
            Destroy(HelpBoolean2Area); 
        }   
    }
}