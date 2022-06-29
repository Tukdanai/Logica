using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpLogic3 : MonoBehaviour
{
    [SerializeField] GameObject HelpLogic3Page;
    [SerializeField] GameObject HelpLogic3Area;
    [SerializeField] HelpPage helpPage;
    private bool pageChanged;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource ChangePage;

    void Start()
    {
        HelpLogic3Area.SetActive(true);
        pageChanged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(helpPage.lastSeenPage != 6) 
            {
                if(helpPage.isHelpPageOpen == true)
                {
                    ChangePage.Play();
                    pageChanged = true;
                }
                helpPage.CloseCurrentPage();
            }
            if(pageChanged == false && helpPage.isHelpPageOpen == false) OpenHelpPage.Play();
            HelpLogic3Page.SetActive(true);
            Destroy(HelpLogic3Area); 
        }   
    }
}