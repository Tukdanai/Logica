using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPage : MonoBehaviour
{
    [SerializeField] GameObject PlayerGameObject;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject page1;
    [SerializeField] GameObject page2;
    [SerializeField] GameObject page3;
    [SerializeField] GameObject page4;
    [SerializeField] GameObject page5;
    [SerializeField] GameObject page6;
    [SerializeField] GameObject page7;
    [SerializeField] GameObject page8;
    [SerializeField] GameObject page9;
    [SerializeField] GameObject page10;
    [SerializeField] GameObject page11;
    [SerializeField] GameObject page12;
    [SerializeField] GameObject page13;
    [SerializeField] GameObject page14;
    [SerializeField] GameObject page15;
    [SerializeField] GameObject page16;
    [SerializeField] GameObject page17;
    [SerializeField] GameObject page18;
    [SerializeField] GameObject page19;
    [SerializeField] GameObject page20;
    [SerializeField] GameObject page21;
    [SerializeField] GameObject page22;
    [SerializeField] GameObject page23;
    [SerializeField] GameObject page24;
    public int lastSeenPage;
    public bool isHelpPageOpen;
    [SerializeField] AudioSource OpenHelpPage;
    [SerializeField] AudioSource CloseUI;
    
    void Start()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
        page7.SetActive(false);
        page8.SetActive(false);
        page9.SetActive(false);
        page10.SetActive(false);
        page11.SetActive(false);
        page12.SetActive(false);
        page13.SetActive(false);
        page14.SetActive(false);
        page15.SetActive(false);
        page16.SetActive(false);
        page17.SetActive(false);
        page18.SetActive(false);
        page19.SetActive(false);
        page20.SetActive(false);
        page21.SetActive(false);
        page22.SetActive(false);
        page23.SetActive(false);
        page24.SetActive(false);
    }

    void Update()
    {   
        if(lastSeenPage != 0 && PlayerGameObject.activeSelf == true && player.canHelp == true)
        {
            if(lastSeenPage == 1 && Input.GetKeyDown(KeyCode.F2)) 
            {
                if(page1.activeSelf == false) OpenHelpPage.Play(); 
                else if(page1.activeSelf == true) CloseUI.Play();
                page1.SetActive(!page1.activeSelf);
            }

            if(lastSeenPage == 2 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page2.activeSelf == false) OpenHelpPage.Play(); 
                else if(page2.activeSelf == true) CloseUI.Play();
                page2.SetActive(!page2.activeSelf);
            }

            if(lastSeenPage == 3 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page3.activeSelf == false) OpenHelpPage.Play(); 
                else if(page3.activeSelf == true) CloseUI.Play();
                page3.SetActive(!page3.activeSelf);
            }

            if(lastSeenPage == 4 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page4.activeSelf == false) OpenHelpPage.Play(); 
                else if(page4.activeSelf == true) CloseUI.Play();
                page4.SetActive(!page4.activeSelf);
            }

            if(lastSeenPage == 5 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page5.activeSelf == false) OpenHelpPage.Play(); 
                else if(page5.activeSelf == true) CloseUI.Play();
                page5.SetActive(!page5.activeSelf);
            }

            if(lastSeenPage == 6 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page6.activeSelf == false) OpenHelpPage.Play(); 
                else if(page6.activeSelf == true) CloseUI.Play();
                page6.SetActive(!page6.activeSelf);
            }

            if(lastSeenPage == 7 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page7.activeSelf == false) OpenHelpPage.Play(); 
                else if(page7.activeSelf == true) CloseUI.Play();
                page7.SetActive(!page7.activeSelf);
            }

            if(lastSeenPage == 8 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page8.activeSelf == false) OpenHelpPage.Play(); 
                else if(page8.activeSelf == true) CloseUI.Play();
                page8.SetActive(!page8.activeSelf);
            }

            if(lastSeenPage == 9 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page9.activeSelf == false) OpenHelpPage.Play(); 
                else if(page9.activeSelf == true) CloseUI.Play();
                page9.SetActive(!page9.activeSelf);
            }

            if(lastSeenPage == 10 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page10.activeSelf == false) OpenHelpPage.Play(); 
                else if(page10.activeSelf == true) CloseUI.Play();
                page10.SetActive(!page10.activeSelf);
            }

            if(lastSeenPage == 11 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page11.activeSelf == false) OpenHelpPage.Play(); 
                else if(page11.activeSelf == true) CloseUI.Play();
                page11.SetActive(!page11.activeSelf);
            }

            if(lastSeenPage == 12 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page12.activeSelf == false) OpenHelpPage.Play(); 
                else if(page12.activeSelf == true) CloseUI.Play();
                page12.SetActive(!page12.activeSelf);
            }

            if(lastSeenPage == 13 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page13.activeSelf == false) OpenHelpPage.Play(); 
                else if(page13.activeSelf == true) CloseUI.Play();
                page13.SetActive(!page13.activeSelf);
            }

            if(lastSeenPage == 14 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page14.activeSelf == false) OpenHelpPage.Play(); 
                else if(page14.activeSelf == true) CloseUI.Play();
                page14.SetActive(!page14.activeSelf);
            }

            if(lastSeenPage == 15 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page15.activeSelf == false) OpenHelpPage.Play(); 
                else if(page15.activeSelf == true) CloseUI.Play();
                page15.SetActive(!page15.activeSelf);
            }

            if(lastSeenPage == 16 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page16.activeSelf == false) OpenHelpPage.Play(); 
                else if(page16.activeSelf == true) CloseUI.Play();
                page16.SetActive(!page16.activeSelf);
            }

            if(lastSeenPage == 17 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page17.activeSelf == false) OpenHelpPage.Play(); 
                else if(page17.activeSelf == true) CloseUI.Play();
                page17.SetActive(!page17.activeSelf);
            }

            if(lastSeenPage == 18 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page18.activeSelf == false) OpenHelpPage.Play(); 
                else if(page18.activeSelf == true) CloseUI.Play();
                page18.SetActive(!page18.activeSelf);
            }

            if(lastSeenPage == 19 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page19.activeSelf == false) OpenHelpPage.Play(); 
                else if(page19.activeSelf == true) CloseUI.Play();
                page19.SetActive(!page19.activeSelf);
            }

            if(lastSeenPage == 20 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page20.activeSelf == false) OpenHelpPage.Play(); 
                else if(page20.activeSelf == true) CloseUI.Play();
                page20.SetActive(!page20.activeSelf);
            }

            if(lastSeenPage == 21 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page21.activeSelf == false) OpenHelpPage.Play(); 
                else if(page21.activeSelf == true) CloseUI.Play();
                page21.SetActive(!page21.activeSelf);
            }

            if(lastSeenPage == 22 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page22.activeSelf == false) OpenHelpPage.Play(); 
                else if(page22.activeSelf == true) CloseUI.Play();
                page22.SetActive(!page22.activeSelf);
            }

            if(lastSeenPage == 23 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page23.activeSelf == false) OpenHelpPage.Play(); 
                else if(page23.activeSelf == true) CloseUI.Play();
                page23.SetActive(!page23.activeSelf);
            }

            if(lastSeenPage == 24 && Input.GetKeyDown(KeyCode.F2))
            {
                if(page24.activeSelf == false) OpenHelpPage.Play(); 
                else if(page24.activeSelf == true) CloseUI.Play();
                page24.SetActive(!page24.activeSelf);
            }
        }

        if(page1.activeSelf == true) 
        {
            lastSeenPage = 1;
            player.currentHelpPage = 1;
            isHelpPageOpen = true;
        }
        if(page2.activeSelf == true)
        {
            lastSeenPage = 2;
            player.currentHelpPage = 2;
            isHelpPageOpen = true;
        }
        if(page3.activeSelf == true)
        {
            lastSeenPage = 3;
            player.currentHelpPage = 3;
            isHelpPageOpen = true;
        }
        if(page4.activeSelf == true)
        {
            lastSeenPage = 4;
            player.currentHelpPage = 4;
            isHelpPageOpen = true;
        }
        if(page5.activeSelf == true)
        {
            lastSeenPage = 5;
            player.currentHelpPage = 5;
            isHelpPageOpen = true;
        }
        if(page6.activeSelf == true)
        {
            lastSeenPage = 6;
            player.currentHelpPage = 6;
            isHelpPageOpen = true;
        }
        if(page7.activeSelf == true)
        {
            lastSeenPage = 7;
            player.currentHelpPage = 7;
            isHelpPageOpen = true;
        }
        if(page8.activeSelf == true)
        {
            lastSeenPage = 8;
            player.currentHelpPage = 8;
            isHelpPageOpen = true;
        }
        if(page9.activeSelf == true)
        {
            lastSeenPage = 9;
            player.currentHelpPage = 9;
            isHelpPageOpen = true;
        }
        if(page10.activeSelf == true)
        {
            lastSeenPage = 10;
            player.currentHelpPage = 10;
            isHelpPageOpen = true;
        }
        if(page11.activeSelf == true)
        {
            lastSeenPage = 11;
            player.currentHelpPage = 11;
            isHelpPageOpen = true;
        }
        if(page12.activeSelf == true)
        {
            lastSeenPage = 12;
            player.currentHelpPage = 12;
            isHelpPageOpen = true;
        }
        if(page13.activeSelf == true)
        {
            lastSeenPage = 13;
            player.currentHelpPage = 13;
            isHelpPageOpen = true;
        }
        if(page14.activeSelf == true)
        {
            lastSeenPage = 14;
            player.currentHelpPage = 14;
            isHelpPageOpen = true;
        }
        if(page15.activeSelf == true)
        {
            lastSeenPage = 15;
            player.currentHelpPage = 15;
            isHelpPageOpen = true;
        }
        if(page16.activeSelf == true)
        {
            lastSeenPage = 16;
            player.currentHelpPage = 16;
            isHelpPageOpen = true;
        }
        if(page17.activeSelf == true)
        {
            lastSeenPage = 17;
            player.currentHelpPage = 17;
            isHelpPageOpen = true;
        }
        if(page18.activeSelf == true)
        {
            lastSeenPage = 18;
            player.currentHelpPage = 18;
            isHelpPageOpen = true;
        }
        if(page19.activeSelf == true)
        {
            lastSeenPage = 19;
            player.currentHelpPage = 19;
            isHelpPageOpen = true;
        }
        if(page20.activeSelf == true)
        {
            lastSeenPage = 20;
            player.currentHelpPage = 20;
            isHelpPageOpen = true;
        }
        if(page21.activeSelf == true)
        {
            lastSeenPage = 21;
            player.currentHelpPage = 21;
            isHelpPageOpen = true;
        }
        if(page22.activeSelf == true)
        {
            lastSeenPage = 22;
            player.currentHelpPage = 22;
            isHelpPageOpen = true;
        }
        if(page23.activeSelf == true)
        {
            lastSeenPage = 23;
            player.currentHelpPage = 23;
            isHelpPageOpen = true;
        }
        if(page24.activeSelf == true)
        {
            lastSeenPage = 24;
            player.currentHelpPage = 24;
            isHelpPageOpen = true;
        }

        if(!page1.activeSelf && !page2.activeSelf && !page3.activeSelf && !page4.activeSelf && !page5.activeSelf && !page6.activeSelf && !page7.activeSelf && !page8.activeSelf && !page9.activeSelf && !page10.activeSelf && !page11.activeSelf && !page12.activeSelf && !page13.activeSelf && !page14.activeSelf && !page15.activeSelf && !page16.activeSelf && !page17.activeSelf && !page18.activeSelf && !page19.activeSelf && !page20.activeSelf && !page21.activeSelf && !page22.activeSelf && !page23.activeSelf && !page24.activeSelf)
        {
            lastSeenPage = player.currentHelpPage;
            isHelpPageOpen = false;
        }
    }

    public void OpenPage(int pageNum)
    {
        if(pageNum == 1) page1.SetActive(true);
        if(pageNum == 2) page2.SetActive(true);
        if(pageNum == 3) page3.SetActive(true);
        if(pageNum == 4) page4.SetActive(true);
        if(pageNum == 5) page5.SetActive(true);
        if(pageNum == 6) page6.SetActive(true);
        if(pageNum == 7) page7.SetActive(true);
        if(pageNum == 8) page8.SetActive(true);
        if(pageNum == 9) page9.SetActive(true);
        if(pageNum == 10) page10.SetActive(true);
        if(pageNum == 11) page11.SetActive(true);
        if(pageNum == 12) page12.SetActive(true);
        if(pageNum == 13) page13.SetActive(true);
        if(pageNum == 14) page14.SetActive(true);
        if(pageNum == 15) page15.SetActive(true);
        if(pageNum == 16) page16.SetActive(true);
        if(pageNum == 17) page17.SetActive(true);
        if(pageNum == 18) page18.SetActive(true);
        if(pageNum == 19) page19.SetActive(true);
        if(pageNum == 20) page20.SetActive(true);
        if(pageNum == 21) page21.SetActive(true);
        if(pageNum == 22) page22.SetActive(true);
        if(pageNum == 23) page23.SetActive(true);
        if(pageNum == 24) page24.SetActive(true);
    }

    public void CloseCurrentPage()
    {
        if(lastSeenPage == 1) page1.SetActive(false);
        if(lastSeenPage == 2) page2.SetActive(false);
        if(lastSeenPage == 3) page3.SetActive(false);
        if(lastSeenPage == 4) page4.SetActive(false);
        if(lastSeenPage == 5) page5.SetActive(false);
        if(lastSeenPage == 6) page6.SetActive(false);
        if(lastSeenPage == 7) page7.SetActive(false);
        if(lastSeenPage == 8) page8.SetActive(false);
        if(lastSeenPage == 9) page9.SetActive(false);
        if(lastSeenPage == 10) page10.SetActive(false);
        if(lastSeenPage == 11) page11.SetActive(false);
        if(lastSeenPage == 12) page12.SetActive(false);
        if(lastSeenPage == 13) page13.SetActive(false);
        if(lastSeenPage == 14) page14.SetActive(false);
        if(lastSeenPage == 15) page15.SetActive(false);
        if(lastSeenPage == 16) page16.SetActive(false);
        if(lastSeenPage == 17) page17.SetActive(false);
        if(lastSeenPage == 18) page18.SetActive(false);
        if(lastSeenPage == 19) page19.SetActive(false);
        if(lastSeenPage == 20) page20.SetActive(false);
        if(lastSeenPage == 21) page21.SetActive(false);
        if(lastSeenPage == 22) page22.SetActive(false);
        if(lastSeenPage == 23) page23.SetActive(false);
        if(lastSeenPage == 24) page24.SetActive(false);
    }
}
