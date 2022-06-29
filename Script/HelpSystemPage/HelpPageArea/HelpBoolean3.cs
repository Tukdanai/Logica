using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBoolean3 : MonoBehaviour
{
    [SerializeField] GameObject HelpBoolean3Page;
    [SerializeField] GameObject HelpBoolean3Area;
    [SerializeField] HelpPage helpPage;
    [SerializeField] GameObject Puzzle2_1Window;
    private bool pageChanged;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource ChangePage;

    void Start()
    {
        HelpBoolean3Area.SetActive(true);
        pageChanged = false;
    }

    void Update()
    {   
        if(Puzzle2_1Window.activeSelf == true)
        {
            if(helpPage.lastSeenPage != 15) 
            {
                if(helpPage.isHelpPageOpen == true)
                {
                    ChangePage.Play();
                    pageChanged = true;
                }
                helpPage.CloseCurrentPage();
            }
            if(pageChanged == false && helpPage.isHelpPageOpen == false) OpenHelpPage.Play();
            HelpBoolean3Page.SetActive(true);
            Destroy(HelpBoolean3Area); 
        }
    }
}