using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GetDamage : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] SpriteRenderer earL;
    [SerializeField] SpriteRenderer earR;
    [SerializeField] SpriteRenderer head;
    [SerializeField] SpriteRenderer body;
    [SerializeField] SpriteRenderer armL;
    [SerializeField] SpriteRenderer armR;
    [SerializeField] SpriteRenderer legL;
    [SerializeField] SpriteRenderer legR;
    [SerializeField] SpriteRenderer footL;
    [SerializeField] SpriteRenderer footR;
    [SerializeField] SpriteRenderer tail;

    private Color normalTransparent = new Color(1f, 1f, 1f, 1f);
    private Color lowTransparent = new Color(1f, 1f, 1f, 0.5f);
    private Color zeroTransparent = new Color(1f, 1f, 1f, 0f);

    public void getDamageAnimation()
    {
        StartCoroutine(Blinking());
    }

    public IEnumerator Blinking()
    {
        AllLowTransparent();
        yield return new WaitForSeconds(0.15f);
        AllNormalTransparent();
        yield return new WaitForSeconds(0.15f);
        AllLowTransparent();
        yield return new WaitForSeconds(0.15f);
        AllNormalTransparent();
        yield return new WaitForSeconds(0.15f);
        AllLowTransparent();
        yield return new WaitForSeconds(0.15f);
        AllNormalTransparent();
    }

    private void AllLowTransparent()
    {
        earL.color = lowTransparent;
        earR.color = lowTransparent;
        head.color = lowTransparent;
        body.color = lowTransparent;
        armL.color = lowTransparent;
        armR.color = lowTransparent;
        legL.color = lowTransparent;
        legR.color = lowTransparent;
        footL.color = lowTransparent;
        footR.color = lowTransparent;
        tail.color = lowTransparent;
    }

    public void AllNormalTransparent()
    {
        earL.color = normalTransparent;
        earR.color = normalTransparent;
        head.color = normalTransparent;
        body.color = normalTransparent;
        armL.color = normalTransparent;
        armR.color = normalTransparent;
        legL.color = normalTransparent;
        legR.color = normalTransparent;
        footL.color = normalTransparent;
        footR.color = normalTransparent;
        tail.color = normalTransparent;
    }

    public void ZeroTransparent()
    {
        earL.color = zeroTransparent;
        earR.color = zeroTransparent;
        head.color = zeroTransparent;
        body.color = zeroTransparent;
        armL.color = zeroTransparent;
        armR.color = zeroTransparent;
        legL.color = zeroTransparent;
        legR.color = zeroTransparent;
        footL.color = zeroTransparent;
        footR.color = zeroTransparent;
        tail.color = zeroTransparent;
    }

}
