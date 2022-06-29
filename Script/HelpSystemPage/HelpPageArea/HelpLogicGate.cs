using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpLogicGate : MonoBehaviour
{
    [SerializeField] GameObject HelpLogicGatePage;
    [SerializeField] GameObject HelpLogicGateArea;
    [SerializeField] HelpPage helpPage;
    private bool pageChanged;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource ChangePage;

    void Start()
    {
        HelpLogicGateArea.SetActive(true);
        pageChanged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(helpPage.lastSeenPage != 8) 
            {
                if(helpPage.isHelpPageOpen == true)
                {
                    ChangePage.Play();
                    pageChanged = true;
                }
                helpPage.CloseCurrentPage();
            }
            if(pageChanged == false && helpPage.isHelpPageOpen == false) OpenHelpPage.Play();
            HelpLogicGatePage.SetActive(true);
            Destroy(HelpLogicGateArea); 
        }   
    }
}