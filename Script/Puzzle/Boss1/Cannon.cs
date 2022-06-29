using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GetDamage getDamage;
    [SerializeField] AudioSource PlayerGetDamage;
    [SerializeField] CannonLever lever;
    [SerializeField] public GameObject noPower;
    [SerializeField] public GameObject green;
    [SerializeField] public GameObject red;
    [SerializeField] GameObject greenBullet;
    [SerializeField] GameObject redBullet;
    [SerializeField] LogicBoss boss;
    [SerializeField] Boss1 puzzle;
    [SerializeField] CameraBoss1 Boss1Camera;
    [SerializeField] GameObject ShieldBurst;
    [SerializeField] GameObject Heart1;
    [SerializeField] GameObject Heart2;
    [SerializeField] GameObject Heart3;
    [SerializeField] GameObject Heart4;
    [SerializeField] GameObject Heart5;
    [SerializeField] GameObject Heart6;
    private Rigidbody2D greenRB;
    private Rigidbody2D redRB;
    public bool IsCollided;
    public bool canFire;
    public Animator greenAnimator;
    public Animator redAnimator;
    public bool greenAnswerCheck;
    public bool redAnswerCheck;
    private GameObject Heart;
    [SerializeField] AudioSource CannonFire;
    [SerializeField] SavedManager savedManager;
    [SerializeField] GameObject helpNoPower;
    [SerializeField] AudioSource PopUp;
    [SerializeField] Animator ConnectorAnimator;

    void Start()
    {
        greenAnswerCheck = false;
        redAnswerCheck = false;
        canFire = true;
        ShieldBurst.SetActive(false);
        noPower.SetActive(true);
        green.SetActive(false);
        red.SetActive(false);
        greenBullet.SetActive(false);
        redBullet.SetActive(false);
        greenRB = greenBullet.GetComponent<Rigidbody2D>();
        redRB = redBullet.GetComponent<Rigidbody2D>();
        greenAnimator = green.GetComponent<Animator>();
        redAnimator = red.GetComponent<Animator>();
        helpNoPower.SetActive(false);
    }

    void Update()
    {
        if(IsCollided == true && Input.GetKeyDown(KeyCode.E))
        {
            if(noPower.activeSelf == true && canFire == true && helpNoPower.activeSelf == false)
            {
                StartCoroutine(NoPower());
            }
            else if(green.activeSelf == true && canFire == true)
            {
                canFire = false;
                if(CannonFire.isPlaying == false) CannonFire.Play();
                greenBullet.SetActive(true);
                greenAnimator.SetBool("Shoot", true);
                greenRB.AddForce(new Vector2(13.7f,5f), ForceMode2D.Impulse);
            }
            else if(red.activeSelf == true && canFire == true)
            {
                canFire = false;
                if(CannonFire.isPlaying == false) CannonFire.Play();
                redBullet.SetActive(true);
                redAnimator.SetBool("Shoot", true);
                redRB.AddForce(new Vector2(13.7f,5f), ForceMode2D.Impulse);
            }
        }

        if(green.activeSelf == true || red.activeSelf == true) noPower.SetActive(false);

        if(noPower.activeSelf == true)
        {
            lever.noPower.SetActive(true);
            lever.green.SetActive(false);
            lever.red.SetActive(false);
            green.SetActive(false);
            red.SetActive(false);
        }

        if(greenBullet.activeSelf == false && redBullet.activeSelf == false) canFire = true;   

        if(greenAnswerCheck == true)
        {
            greenAnswerCheck = false;
            StartCoroutine(greenCheck());
        }

        if(redAnswerCheck == true)
        {
            redAnswerCheck = false;
            StartCoroutine(redCheck());
        }
    } 

    public IEnumerator greenCheck()
    {
        ConnectorAnimator.SetBool("Close", true);
        if(boss.shield5 == false) Heart = Heart5;
        else if(boss.shield4 == false) Heart = Heart4;
        else if(boss.shield3 == false) Heart = Heart3;
        else if(boss.shield2 == false) Heart = Heart2;
        else if(boss.shield1 == false) Heart = Heart1;
        boss.animator.enabled = true;
        if(1 == puzzle.Answer)
        {
            boss.FallDown.Play();
            boss.animator.SetBool("Correct", true);
            yield return new WaitForSeconds(1.5f);
            boss.animator.SetBool("Correct", false);
            Heart.SetActive(true);
            Heart.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(DelayFreezeHeart());
        }
        else
        {
            player.LogicWrongCount += 1;
            ShieldBurst.SetActive(true);
            player.health -= 2;
            if(player.health > 0) 
            {
                PlayerGetDamage.Play();
                getDamage.getDamageAnimation();
            }
            player.KnockBackAnimation();
            boss.Laugh.Play();
            boss.ShieldBrust.Play();
            boss.animator.SetBool("Wrong", true);
            savedManager.SaveWrongCount();
            yield return new WaitForSeconds(1.5f);
            boss.animator.SetBool("Wrong", false);
            ShieldBurst.SetActive(false);
        }
        boss.isPuzzle = false;
        boss.isImmortal = false;
        yield return new WaitForSeconds(1f);
        ConnectorAnimator.SetBool("Close", false);
        Boss1Camera.back = true;
        puzzle.Reset();
    }

    public IEnumerator redCheck()
    {
        ConnectorAnimator.SetBool("Close", true);
        if(boss.shield5 == false) Heart = Heart5;
        else if(boss.shield4 == false) Heart = Heart4;
        else if(boss.shield3 == false) Heart = Heart3;
        else if(boss.shield2 == false) Heart = Heart2;
        else if(boss.shield1 == false) Heart = Heart1;
        boss.animator.enabled = true;
        if(0 == puzzle.Answer)
        {
            boss.FallDown.Play();
            boss.animator.SetBool("Correct", true);
            yield return new WaitForSeconds(1.5f);
            boss.animator.SetBool("Correct", false);
            Heart.SetActive(true);
            Heart.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(DelayFreezeHeart());
        }
        else
        {
            player.LogicWrongCount += 1;
            ShieldBurst.SetActive(true);
            player.health -= 2;
            if(player.health > 0) 
            {
                PlayerGetDamage.Play();
                getDamage.getDamageAnimation();
            }
            player.KnockBackAnimation();
            boss.Laugh.Play();
            boss.ShieldBrust.Play();
            boss.animator.SetBool("Wrong", true);
            savedManager.SaveWrongCount();
            yield return new WaitForSeconds(1.5f);
            boss.animator.SetBool("Wrong", false);
            ShieldBurst.SetActive(false);
        }
        boss.isPuzzle = false;
        boss.isImmortal = false;
        yield return new WaitForSeconds(1f);
        ConnectorAnimator.SetBool("Close", false);
        Boss1Camera.back = true;
        puzzle.Reset();
    }

    public IEnumerator DelayFreezeHeart()
    {
        yield return new WaitForSeconds(1.41f);
        Heart.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            IsCollided = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        IsCollided = false;
    }

    public IEnumerator NoPower()
    {
        PopUp.Play();
        helpNoPower.SetActive(true);
        yield return new WaitForSeconds(2f);
        helpNoPower.SetActive(false);
    }

}
