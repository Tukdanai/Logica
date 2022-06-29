using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpLogic2 : MonoBehaviour
{
    [SerializeField] GameObject HelpLogic2Page;
    [SerializeField] GameObject HelpLogic2Area;
    [SerializeField] HelpPage helpPage;
    private bool pageChanged;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource ChangePage;

    void Start()
    {
        HelpLogic2Area.SetActive(true);
        pageChanged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(helpPage.lastSeenPage != 5) 
            {
                if(helpPage.isHelpPageOpen == true)
                {
                    ChangePage.Play();
                    pageChanged = true;
                }
                helpPage.CloseCurrentPage();
            }
            if(pageChanged == false && helpPage.isHelpPageOpen == false) OpenHelpPage.Play();
            HelpLogic2Page.SetActive(true);
            Destroy(HelpLogic2Area); 
        }   
    }
}