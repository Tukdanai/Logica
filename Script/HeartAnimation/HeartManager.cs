using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] GameObject Heart2GameObject;
    [SerializeField] Heart2 heart2;
    [SerializeField] GameObject Heart3GameObject;
    [SerializeField] Heart3 heart3;
    [SerializeField] GameObject Heart4GameObject;
    [SerializeField] Heart4 heart4;
    [SerializeField] GameObject Heart5GameObject;
    [SerializeField] Heart5 heart5;
    [SerializeField] Sprite HeartSprite;

    private Color normalTransparent = new Color(1f, 1f, 1f, 1f);
    private Color zeroTransparent = new Color(1f, 1f, 1f, 0f);

    void Update()
    {   
        if(!Heart2GameObject.activeSelf && heart2.setNormalTransparent == false)
        {
            heart2.HeartSpriteRenderer.sprite = HeartSprite;
            heart2.HeartSpriteRenderer.color = zeroTransparent;
            Heart2GameObject.SetActive(true);
        }
        if(heart2.setNormalTransparent == true)
        {
            Heart2GameObject.SetActive(false);
            heart2.HeartSpriteRenderer.sprite = HeartSprite;
            heart2.HeartSpriteRenderer.color = normalTransparent;
            Heart2GameObject.SetActive(true);
            heart2.setNormalTransparent = false;
        }
        if(!Heart3GameObject.activeSelf && heart3.setNormalTransparent == false)
        {
            heart3.HeartSpriteRenderer.sprite = HeartSprite;
            heart3.HeartSpriteRenderer.color = zeroTransparent;
            Heart3GameObject.SetActive(true);
        }
        if(heart3.setNormalTransparent == true)
        {
            Heart3GameObject.SetActive(false);
            heart3.HeartSpriteRenderer.sprite = HeartSprite;
            heart3.HeartSpriteRenderer.color = normalTransparent;
            Heart3GameObject.SetActive(true);
            heart3.setNormalTransparent = false;
        }
        if(!Heart4GameObject.activeSelf && heart4.setNormalTransparent == false)
        {
            heart4.HeartSpriteRenderer.sprite = HeartSprite;
            heart4.HeartSpriteRenderer.color = zeroTransparent;
            Heart4GameObject.SetActive(true);
        }
        if(heart4.setNormalTransparent == true)
        {
            Heart4GameObject.SetActive(false);
            heart4.HeartSpriteRenderer.sprite = HeartSprite;
            heart4.HeartSpriteRenderer.color = normalTransparent;
            Heart4GameObject.SetActive(true);
            heart4.setNormalTransparent = false;
        }
        if(!Heart5GameObject.activeSelf && heart5.setNormalTransparent == false)
        {
            heart5.HeartSpriteRenderer.sprite = HeartSprite;
            heart5.HeartSpriteRenderer.color = zeroTransparent;
            Heart5GameObject.SetActive(true);
        }
        if(heart5.setNormalTransparent == true)
        {
            Heart5GameObject.SetActive(false);
            heart5.HeartSpriteRenderer.sprite = HeartSprite;
            heart5.HeartSpriteRenderer.color = normalTransparent;
            Heart5GameObject.SetActive(true);
            heart5.setNormalTransparent = false;
        }
    }
}
