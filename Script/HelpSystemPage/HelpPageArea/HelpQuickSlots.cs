using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpQuickSlots : MonoBehaviour
{
    [SerializeField] GameObject HelpQuickSlotsPage;
    [SerializeField] GameObject HelpQuickSlotsArea;
    [SerializeField] HelpPage helpPage;
    private bool pageChanged;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource ChangePage;

    void Start()
    {
        HelpQuickSlotsArea.SetActive(true);
        pageChanged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(helpPage.lastSeenPage != 3) 
            {
                if(helpPage.isHelpPageOpen == true)
                {
                    ChangePage.Play();
                    pageChanged = true;
                }
                helpPage.CloseCurrentPage();
            }
            if(pageChanged == false && helpPage.isHelpPageOpen == false) OpenHelpPage.Play();
            HelpQuickSlotsPage.SetActive(true);
            Destroy(HelpQuickSlotsArea); 
        }   
    }
}