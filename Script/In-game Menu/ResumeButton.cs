using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResumeButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject Menu;
    [SerializeField] PlayerController player;
    [SerializeField] HelpPage helpPage;
    [SerializeField] AudioSource Click;
    
    [SerializeField] AudioSource CloseUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Menu.activeSelf == true && helpPage.isHelpPageOpen == false)
        {
            player.canMove = true;
            player.canAttack = true;
            CloseUI.Play();
            Time.timeScale = 1f;
            Menu.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Click.Play();
        CloseUI.Play();
        player.canMove = true;
        Time.timeScale = 1f;
        player.StartCoroutine(player.AttackCooldown());
        Menu.SetActive(false);
    }
}
