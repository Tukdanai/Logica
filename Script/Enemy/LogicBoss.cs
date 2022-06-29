using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LogicBoss : MonoBehaviour
{
    public int health;
    public Slider sliderHP;
    public float walkSpeed;
    public float walkDirection;
    Vector3 walkAmount;
    
    [SerializeField] GameObject helpBossJump;
    [SerializeField] GameObject helpBossPuzzle;
    [SerializeField] GameObject BossGameObject;
    [SerializeField] Boss1 puzzle;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject shadow;
    [SerializeField] Cannon cannon;
    [SerializeField] CannonLever lever;
    private bool follow;
    [SerializeField] SpriteRenderer Head;
    [SerializeField] SpriteRenderer ShoulderL;
    [SerializeField] SpriteRenderer ShoulderR;
    [SerializeField] SpriteRenderer Body;
    [SerializeField] SpriteRenderer ElbowL;
    [SerializeField] SpriteRenderer HandL;
    [SerializeField] SpriteRenderer HandR;
    [SerializeField] SpriteRenderer LegL;
    [SerializeField] SpriteRenderer LegR;
    [SerializeField] SpriteRenderer FootL;
    [SerializeField] SpriteRenderer FootR;
    private Rigidbody2D rigidBody2D;
    public bool canAttack;
    public bool isJumping;
    public bool isImmortal;
    public bool isPuzzle;
    public bool getAttack;
    public bool godDamage;
    public Animator animator;
    [SerializeField] SightRange sightRange;
    [SerializeField] AttackRange attackRange;
    [SerializeField] PlayerController player;
    [SerializeField] GetDamage getDamage;
    [SerializeField] AudioSource Walk;
    [SerializeField] AudioSource HammerAttack;
    [SerializeField] AudioSource Jump;
    [SerializeField] AudioSource Stomp;
    [SerializeField] AudioSource BossGetDamage;
    [SerializeField] public AudioSource Laugh;
    [SerializeField] public AudioSource FallDown;
    [SerializeField] public AudioSource ShieldBreak;
    [SerializeField] public AudioSource ShieldBrust;
    [SerializeField] AudioSource PlayerGetDamage;
    [SerializeField] AudioSource PopUp;
    [SerializeField] AudioSource BossDead;
    private bool playDeadSound;
    public bool isDead;
    [SerializeField] Animator ConnectorAnimator;

    public bool shield1;
    public bool shield2;
    public bool shield3;
    public bool shield4;
    public bool shield5;

    private Color normalTransparent = new Color(1f, 1f, 1f, 1f);
    private Color lowTransparent = new Color(1f, 1f, 1f, 0.5f);

    void Start()
    {
        rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        health = 30;
        sliderHP.maxValue = health;
        sliderHP.value = health;
        isImmortal = false;
        canAttack = true;
        getAttack = false;
        isJumping = false;
        walkDirection = -1;
        follow = false;
        shadow.SetActive(false);
        godDamage = false;
        isPuzzle  = false;
        shield.SetActive(false);
        shield1 = true;
        shield2 = true;
        shield3 = true;
        shield4 = true;
        shield5 = true;
        helpBossJump.SetActive(false);
        helpBossPuzzle.SetActive(false);
        playDeadSound = true;
        isDead = false;
    }

    void Update()
    {
        sliderHP.value = health;
        
        if(sightRange.PlayerFounded == false && isJumping == false && isPuzzle == false && isDead == false)
        {
            if(transform.rotation.eulerAngles.y == 0) transform.eulerAngles = new Vector3(0,180,0);  
            else if(transform.rotation.eulerAngles.y == 180) transform.eulerAngles = new Vector3(0,0,0);
        }
        if(isJumping == false && isPuzzle == false && isDead == false) walkAmount.x = (walkDirection * walkSpeed) * Time.deltaTime;
        if(isJumping == false && isPuzzle == false && isDead == false) 
        {
            if(Walk.isPlaying == false)
            {
                Walk.volume = Random.Range(0.02f,0.08f);
                Walk.pitch = Random.Range(0.85f,0.95f);
                Walk.Play();
            }
            transform.Translate(walkAmount); //Move
        }

        if(attackRange.AttackPlayer == true && isPuzzle == false && isDead == false)
        {
            if(canAttack == true && health > 17) StartCoroutine(HammerAttackAnimation());
            else if(canAttack == true && health <= 17)
            {
                int random = Random.Range(1,3);
                if(random == 2) StartCoroutine(JumpAttackAnimation());
                else StartCoroutine(HammerAttackAnimation());
            }
        }

        if(health <= 24 && health > 19 && isJumping == false && isPuzzle == false && shield1 == true && isDead == false) 
        {
            StartCoroutine(JumpToPuzzle1());
        }
        
        if(health <= 19 && health > 14 && isJumping == false && isPuzzle == false && shield2 == true && isDead == false) 
        {
            StartCoroutine(JumpToPuzzle2());
        }
        

        if(health <= 14 && health > 9 && isJumping == false && isPuzzle == false && shield3 == true && isDead == false) 
        {
            StartCoroutine(JumpToPuzzle3());
        }
        

        if(health <= 9 && health > 5 && isJumping == false && isPuzzle == false && shield4 == true && isDead == false) 
        {
            StartCoroutine(JumpToPuzzle4());
        }
        
        if(health <= 5 && health > 0 && isJumping == false && isPuzzle == false && shield5 == true && isDead == false) 
        {
            StartCoroutine(JumpToPuzzle5());
        }
        
        if(getAttack == true && isDead == false) 
        {
            StartCoroutine(Blinking());
            StartCoroutine(ImmortalDeley());
        }

        if(follow == true && shadow.activeSelf == true && isPuzzle == false) 
        {
            shadow.transform.position = new Vector3(player.transform.position.x,shadow.transform.position.y,0);
        }

        if(shadow.transform.position.x > 15.99f) shadow.transform.position = new Vector3(16.1f,shadow.transform.position.y,0);

        if(isPuzzle == true && shadow.activeSelf == true)
        {
            shadow.transform.position = new Vector3(16f,shadow.transform.position.y,0);
        }

        if(shield.activeSelf == true) isImmortal = true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(player.isImmortal == false && player.health > 0 && isDead == false) 
            {
                if(godDamage == true) player.health -= 5;
                else
                {
                    player.health -= 1;
                    if(player.health > 0) 
                    {
                        PlayerGetDamage.Play();
                        getDamage.getDamageAnimation();
                    }
                    player.KnockBackFromMonster(transform.rotation.eulerAngles.y);
                }
            }
        }
        if(other.gameObject.CompareTag("ExCarrotSword") && isImmortal == false && isDead == false)
        {
            if(player.attack == true)
            {
                getAttack = true;
                health -= 1;        
                BossGetDamage.Play();
                if(health <= 0) 
                {
                    isDead = true;
                    StartCoroutine(DeadAnimation());
                }
            }
        }
    }

    public IEnumerator HammerAttackAnimation()
    {
        canAttack = false;
        animator.SetBool("Hammer", true);
        yield return new WaitForSeconds(0.1f);
        if(HammerAttack.isPlaying == false) HammerAttack.Play();
        yield return new WaitForSeconds(1.3f);
        animator.SetBool("Hammer", false);
        walkDirection = 1;
        animator.SetBool("Backward", true);
        int randomBack = Random.Range(1,7);
        if(randomBack == 1) yield return new WaitForSeconds(1.5f);
        else if(randomBack == 2) yield return new WaitForSeconds(2f);
        else if(randomBack == 3) yield return new WaitForSeconds(2.5f);
        else if(randomBack == 4) yield return new WaitForSeconds(3f);
        else if(randomBack == 5) yield return new WaitForSeconds(3.5f);
        else if(randomBack == 5) yield return new WaitForSeconds(4f);
        walkDirection = -1;
        animator.SetBool("Backward", false);
        canAttack = true;
    }

    public IEnumerator JumpAttackAnimation()
    {
        bool bossFollow;
        float shadowX;
        bossFollow = false;
        follow = true;
        isJumping = true;
        canAttack = false;
        if(Jump.isPlaying == false) Jump.Play();
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(BossJump());
        rigidBody2D.gravityScale = 0;
        rigidBody2D.AddForce(Vector2.up * 10000f);
        yield return new WaitForSeconds(0.5f);
        shadow.SetActive(true);
        animator.SetBool("Jump", false);
        yield return new WaitForSeconds(3f);
        follow = false;
        shadowX = shadow.transform.position.x;
        bossFollow = true;
        if(shadow.activeSelf == true && follow == false && bossFollow == true) transform.position = new Vector3(shadowX,10,0);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        bossFollow = false;
        yield return new WaitForSeconds(1f);
        rigidBody2D.gravityScale = 5;
        godDamage = true;
        yield return new WaitForSeconds(1.6f);
        if(Stomp.isPlaying == false) Stomp.Play();
        yield return new WaitForSeconds(0.4f);
        shadow.SetActive(false);
        isJumping = false;
        godDamage = false;
        rigidBody2D.gravityScale = 1;
        yield return new WaitForSeconds(0.001f);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        walkDirection = 1;
        animator.SetBool("Backward", true);
        yield return new WaitForSeconds(3f);
        walkDirection = -1;
        animator.SetBool("Backward", false);
        yield return new WaitForSeconds(0.001f);
        canAttack = true;
    }

    public IEnumerator JumpToPuzzle1()
    {
        shield1 = false;
        isImmortal = true;
        isPuzzle = true;
        bool bossFollow;
        float shadowX;
        bossFollow = false;
        isJumping = true;
        canAttack = false;
        if(Jump.isPlaying == false) Jump.Play();
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(BossJump());
        rigidBody2D.gravityScale = 0;
        rigidBody2D.AddForce(Vector2.up * 10000f);
        yield return new WaitForSeconds(0.5f);
        shadow.SetActive(true);
        animator.SetBool("Jump", false);
        yield return new WaitForSeconds(2f);
        shadowX = shadow.transform.position.x;
        bossFollow = true;
        if(shadow.activeSelf == true && follow == false && bossFollow == true) transform.position = new Vector3(shadowX,10,0);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        bossFollow = false;
        yield return new WaitForSeconds(1f);
        rigidBody2D.gravityScale = 5;
        godDamage = true;
        puzzle.ShowPuzzle(1);
        yield return new WaitForSeconds(1.2f);
        ConnectorAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(0.4f);
        if(Stomp.isPlaying == false) Stomp.Play();
        yield return new WaitForSeconds(0.2f);
        shadow.SetActive(false);
        isJumping = false;
        godDamage = false;
        animator.enabled = false;
        rigidBody2D.gravityScale = 1;
        yield return new WaitForSeconds(0.001f);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.eulerAngles = new Vector3(0,0,0);
        shield.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(BossPuzzle());
        cannon.green.SetActive(true);
        lever.red.SetActive(true);
        canAttack = true;
    }

    public IEnumerator JumpToPuzzle2()
    {
        shield2 = false;
        isImmortal = true;
        isPuzzle = true;
        bool bossFollow;
        float shadowX;
        bossFollow = false;
        isJumping = true;
        canAttack = false;
        if(Jump.isPlaying == false) Jump.Play();
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.25f);
        rigidBody2D.gravityScale = 0;
        rigidBody2D.AddForce(Vector2.up * 10000f);
        yield return new WaitForSeconds(0.5f);
        shadow.SetActive(true);
        animator.SetBool("Jump", false);
        yield return new WaitForSeconds(2f);
        shadowX = shadow.transform.position.x;
        bossFollow = true;
        if(shadow.activeSelf == true && follow == false && bossFollow == true) transform.position = new Vector3(shadowX,10,0);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        bossFollow = false;
        yield return new WaitForSeconds(1f);
        rigidBody2D.gravityScale = 5;
        godDamage = true;
        int randomPuzzle = Random.Range(2,4);
        puzzle.ShowPuzzle(randomPuzzle);
        yield return new WaitForSeconds(1.2f);
        ConnectorAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(0.4f);
        if(Stomp.isPlaying == false) Stomp.Play();
        yield return new WaitForSeconds(0.2f);
        shadow.SetActive(false);
        isJumping = false;
        godDamage = false;
        animator.enabled = false;
        rigidBody2D.gravityScale = 1;
        yield return new WaitForSeconds(0.001f);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.eulerAngles = new Vector3(0,0,0);
        shield.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(BossPuzzle());
        cannon.green.SetActive(true);
        lever.red.SetActive(true);
        canAttack = true;
    }

    public IEnumerator JumpToPuzzle3()
    {
        shield3 = false;
        isImmortal = true;
        isPuzzle = true;
        bool bossFollow;
        float shadowX;
        bossFollow = false;
        isJumping = true;
        canAttack = false;
        if(Jump.isPlaying == false) Jump.Play();
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.25f);
        rigidBody2D.gravityScale = 0;
        rigidBody2D.AddForce(Vector2.up * 10000f);
        yield return new WaitForSeconds(0.5f);
        shadow.SetActive(true);
        animator.SetBool("Jump", false);
        yield return new WaitForSeconds(2f);
        shadowX = shadow.transform.position.x;
        bossFollow = true;
        if(shadow.activeSelf == true && follow == false && bossFollow == true) transform.position = new Vector3(shadowX,10,0);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        bossFollow = false;
        yield return new WaitForSeconds(1f);
        rigidBody2D.gravityScale = 5;
        godDamage = true;
        int randomPuzzle = Random.Range(2,4);
        puzzle.ShowPuzzle(randomPuzzle);
        yield return new WaitForSeconds(1.2f);
        ConnectorAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(0.4f);
        if(Stomp.isPlaying == false) Stomp.Play();
        yield return new WaitForSeconds(0.2f);
        shadow.SetActive(false);
        isJumping = false;
        godDamage = false;
        animator.enabled = false;
        rigidBody2D.gravityScale = 1;
        yield return new WaitForSeconds(0.001f);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.eulerAngles = new Vector3(0,0,0);
        shield.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(BossPuzzle());
        cannon.green.SetActive(true);
        lever.red.SetActive(true);
        canAttack = true;
    }

    public IEnumerator JumpToPuzzle4()
    {
        shield4 = false;
        isImmortal = true;
        isPuzzle = true;
        bool bossFollow;
        float shadowX;
        bossFollow = false;
        isJumping = true;
        canAttack = false;
        if(Jump.isPlaying == false) Jump.Play();
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.25f);
        rigidBody2D.gravityScale = 0;
        rigidBody2D.AddForce(Vector2.up * 10000f);
        yield return new WaitForSeconds(0.5f);
        shadow.SetActive(true);
        animator.SetBool("Jump", false);
        yield return new WaitForSeconds(2f);
        shadowX = shadow.transform.position.x;
        bossFollow = true;
        if(shadow.activeSelf == true && follow == false && bossFollow == true) transform.position = new Vector3(shadowX,10,0);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        bossFollow = false;
        yield return new WaitForSeconds(1f);
        rigidBody2D.gravityScale = 5;
        godDamage = true;
        int randomPuzzle = Random.Range(4,6);
        puzzle.ShowPuzzle(randomPuzzle);
        yield return new WaitForSeconds(1.2f);
        ConnectorAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(0.4f);
        if(Stomp.isPlaying == false) Stomp.Play();
        yield return new WaitForSeconds(0.2f);
        shadow.SetActive(false);
        isJumping = false;
        godDamage = false;
        animator.enabled = false;
        rigidBody2D.gravityScale = 1;
        yield return new WaitForSeconds(0.001f);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.eulerAngles = new Vector3(0,0,0);
        shield.SetActive(true);
        yield return new WaitForSeconds(1f);
        cannon.green.SetActive(true);
        lever.red.SetActive(true);
        canAttack = true;
    }

    public IEnumerator JumpToPuzzle5()
    {
        shield5 = false;
        isImmortal = true;
        isPuzzle = true;
        bool bossFollow;
        float shadowX;
        bossFollow = false;
        isJumping = true;
        canAttack = false;
        if(Jump.isPlaying == false) Jump.Play();
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.25f);
        rigidBody2D.gravityScale = 0;
        rigidBody2D.AddForce(Vector2.up * 10000f);
        yield return new WaitForSeconds(0.5f);
        shadow.SetActive(true);
        animator.SetBool("Jump", false);
        yield return new WaitForSeconds(2f);
        shadowX = shadow.transform.position.x;
        bossFollow = true;
        if(shadow.activeSelf == true && follow == false && bossFollow == true) transform.position = new Vector3(shadowX,10,0);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        bossFollow = false;
        yield return new WaitForSeconds(1f);
        rigidBody2D.gravityScale = 5;
        godDamage = true;
        puzzle.ShowPuzzle(6);
        yield return new WaitForSeconds(1.2f);
        ConnectorAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(0.4f);
        if(Stomp.isPlaying == false) Stomp.Play();
        yield return new WaitForSeconds(0.2f);
        shadow.SetActive(false);
        isJumping = false;
        godDamage = false;
        animator.enabled = false;
        rigidBody2D.gravityScale = 1;
        yield return new WaitForSeconds(0.001f);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.eulerAngles = new Vector3(0,0,0);
        shield.SetActive(true);
        yield return new WaitForSeconds(1f);
        cannon.green.SetActive(true);
        lever.red.SetActive(true);
        canAttack = true;
    }
    
    public IEnumerator Blinking()
    {
        Head.color = lowTransparent;
        ShoulderL.color = lowTransparent;
        ShoulderR.color = lowTransparent;
        Body.color = lowTransparent;
        ElbowL.color = lowTransparent;
        HandL.color = lowTransparent;
        HandR.color = lowTransparent;
        LegL.color = lowTransparent;
        LegR.color = lowTransparent;
        FootL.color = lowTransparent;
        FootR.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        Head.color = normalTransparent;
        ShoulderL.color = normalTransparent;
        ShoulderR.color = normalTransparent;
        Body.color = normalTransparent;
        ElbowL.color = normalTransparent;
        HandL.color = normalTransparent;
        HandR.color = normalTransparent;
        LegL.color = normalTransparent;
        LegR.color = normalTransparent;
        FootL.color = normalTransparent;
        FootR.color = normalTransparent;
        yield return new WaitForSeconds(0.15f);
    }

    public IEnumerator ImmortalDeley()
    {
        isImmortal = true;
        getAttack = false;
        yield return new WaitForSeconds(0.4f);
        isImmortal = false;
    }

    public IEnumerator BossJump()
    {
        PopUp.Play();
        helpBossJump.SetActive(true);
        yield return new WaitForSeconds(2f);
        helpBossJump.SetActive(false);
    }

    public IEnumerator BossPuzzle()
    {
        PopUp.Play();
        helpBossPuzzle.SetActive(true);
        yield return new WaitForSeconds(8f);
        helpBossPuzzle.SetActive(false);
    }

    public IEnumerator DeadAnimation()
    {
        Head.color = lowTransparent;
        ShoulderL.color = lowTransparent;
        ShoulderR.color = lowTransparent;
        Body.color = lowTransparent;
        ElbowL.color = lowTransparent;
        HandL.color = lowTransparent;
        HandR.color = lowTransparent;
        LegL.color = lowTransparent;
        LegR.color = lowTransparent;
        FootL.color = lowTransparent;
        FootR.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        Head.color = normalTransparent;
        ShoulderL.color = normalTransparent;
        ShoulderR.color = normalTransparent;
        Body.color = normalTransparent;
        ElbowL.color = normalTransparent;
        HandL.color = normalTransparent;
        HandR.color = normalTransparent;
        LegL.color = normalTransparent;
        LegR.color = normalTransparent;
        FootL.color = normalTransparent;
        FootR.color = normalTransparent;
        if(BossDead.isPlaying == false && playDeadSound == true) BossDead.Play();
        playDeadSound = false;
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(1.2f);
        Head.color = lowTransparent;
        ShoulderL.color = lowTransparent;
        ShoulderR.color = lowTransparent;
        Body.color = lowTransparent;
        ElbowL.color = lowTransparent;
        HandL.color = lowTransparent;
        HandR.color = lowTransparent;
        LegL.color = lowTransparent;
        LegR.color = lowTransparent;
        FootL.color = lowTransparent;
        FootR.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        Head.color = normalTransparent;
        ShoulderL.color = normalTransparent;
        ShoulderR.color = normalTransparent;
        Body.color = normalTransparent;
        ElbowL.color = normalTransparent;
        HandL.color = normalTransparent;
        HandR.color = normalTransparent;
        LegL.color = normalTransparent;
        LegR.color = normalTransparent;
        FootL.color = normalTransparent;
        FootR.color = normalTransparent;
        yield return new WaitForSeconds(0.2f);
        Head.color = lowTransparent;
        ShoulderL.color = lowTransparent;
        ShoulderR.color = lowTransparent;
        Body.color = lowTransparent;
        ElbowL.color = lowTransparent;
        HandL.color = lowTransparent;
        HandR.color = lowTransparent;
        LegL.color = lowTransparent;
        LegR.color = lowTransparent;
        FootL.color = lowTransparent;
        FootR.color = lowTransparent;
        yield return new WaitForSeconds(0.1f);
        Head.color = normalTransparent;
        ShoulderL.color = normalTransparent;
        ShoulderR.color = normalTransparent;
        Body.color = normalTransparent;
        ElbowL.color = normalTransparent;
        HandL.color = normalTransparent;
        HandR.color = normalTransparent;
        LegL.color = normalTransparent;
        LegR.color = normalTransparent;
        FootL.color = normalTransparent;
        FootR.color = normalTransparent;
        yield return new WaitForSeconds(0.1f);
        Head.color = lowTransparent;
        ShoulderL.color = lowTransparent;
        ShoulderR.color = lowTransparent;
        Body.color = lowTransparent;
        ElbowL.color = lowTransparent;
        HandL.color = lowTransparent;
        HandR.color = lowTransparent;
        LegL.color = lowTransparent;
        LegR.color = lowTransparent;
        FootL.color = lowTransparent;
        FootR.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        Head.color = normalTransparent;
        ShoulderL.color = normalTransparent;
        ShoulderR.color = normalTransparent;
        Body.color = normalTransparent;
        ElbowL.color = normalTransparent;
        HandL.color = normalTransparent;
        HandR.color = normalTransparent;
        LegL.color = normalTransparent;
        LegR.color = normalTransparent;
        FootL.color = normalTransparent;
        FootR.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        Head.color = lowTransparent;
        ShoulderL.color = lowTransparent;
        ShoulderR.color = lowTransparent;
        Body.color = lowTransparent;
        ElbowL.color = lowTransparent;
        HandL.color = lowTransparent;
        HandR.color = lowTransparent;
        LegL.color = lowTransparent;
        LegR.color = lowTransparent;
        FootL.color = lowTransparent;
        FootR.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        Head.color = normalTransparent;
        ShoulderL.color = normalTransparent;
        ShoulderR.color = normalTransparent;
        Body.color = normalTransparent;
        ElbowL.color = normalTransparent;
        HandL.color = normalTransparent;
        HandR.color = normalTransparent;
        LegL.color = normalTransparent;
        LegR.color = normalTransparent;
        FootL.color = normalTransparent;
        FootR.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        Head.color = lowTransparent;
        ShoulderL.color = lowTransparent;
        ShoulderR.color = lowTransparent;
        Body.color = lowTransparent;
        ElbowL.color = lowTransparent;
        HandL.color = lowTransparent;
        HandR.color = lowTransparent;
        LegL.color = lowTransparent;
        LegR.color = lowTransparent;
        FootL.color = lowTransparent;
        FootR.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        Head.color = normalTransparent;
        ShoulderL.color = normalTransparent;
        ShoulderR.color = normalTransparent;
        Body.color = normalTransparent;
        ElbowL.color = normalTransparent;
        HandL.color = normalTransparent;
        HandR.color = normalTransparent;
        LegL.color = normalTransparent;
        LegR.color = normalTransparent;
        FootL.color = normalTransparent;
        FootR.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        Head.color = lowTransparent;
        ShoulderL.color = lowTransparent;
        ShoulderR.color = lowTransparent;
        Body.color = lowTransparent;
        ElbowL.color = lowTransparent;
        HandL.color = lowTransparent;
        HandR.color = lowTransparent;
        LegL.color = lowTransparent;
        LegR.color = lowTransparent;
        FootL.color = lowTransparent;
        FootR.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        BossGameObject.SetActive(false);
    }
}
