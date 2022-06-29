using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBoolean : MonoBehaviour
{
    [SerializeField] GameObject HelpBooleanPage;
    [SerializeField] GameObject HelpBooleanArea;
    [SerializeField] HelpPage helpPage;
    private bool pageChanged;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource ChangePage;

    void Start()
    {
        HelpBooleanArea.SetActive(true);
        pageChanged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player")) 
        {
            if(helpPage.lastSeenPage != 11) 
            {
                if(helpPage.isHelpPageOpen == true)
                {
                    ChangePage.Play();
                    pageChanged = true;
                }
                helpPage.CloseCurrentPage();
            }
            if(pageChanged == false && helpPage.isHelpPageOpen == false) OpenHelpPage.Play();
            HelpBooleanPage.SetActive(true);
            Destroy(HelpBooleanArea); 
        }   
    }
}