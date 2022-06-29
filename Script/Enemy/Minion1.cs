using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Minion1 : MonoBehaviour
{
    public int health;
    public Slider sliderHP;
    public float flySpeed;
    public float flyLeft;
    public float flyRight;
    private float defaultFlyLeft;
    private float defaultFlyRight;
    private float defaultY;
    public float flyDirection;
    Vector3 flyAmount;
    [SerializeField] SpriteRenderer sprite;
    private Rigidbody2D rigidBody2D;
    public bool foundPlayer;
    public bool getAttack;
    public bool isAttack;
    public float nextAttackTime;
    public float attackCooldownTime;
    public bool isImmortal;
    Vector3 originalPosition;
    Animator animator;
    [SerializeField] SightRange sightRange;
    [SerializeField] AttackRange attackRange;
    [SerializeField] PlayerController player;
    [SerializeField] GetDamage getDamage;
    [SerializeField] GameObject DeathEffect;
    [SerializeField] SoulAbsorbDelay soulAbsorb;
    [SerializeField] GameObject droppedItem;
    [SerializeField] AudioSource Walk;
    [SerializeField] AudioSource Run;
    [SerializeField] AudioSource Attack;
    [SerializeField] AudioSource Monster1GetDamage;
    [SerializeField] AudioSource PlayerGetDamage;

    private Color normalTransparent = new Color(1f, 1f, 1f, 1f);
    private Color lowTransparent = new Color(1f, 1f, 1f, 0.5f);

    void Start()
    {
        rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        health = 5;
        sliderHP.maxValue = health;
        sliderHP.value = health;
        getAttack = false;
        isImmortal = false;
        foundPlayer = false;
        isAttack = false;
        nextAttackTime = 0;
        attackCooldownTime = 2f;
        DeathEffect.SetActive(false);
        droppedItem.SetActive(false);
        defaultY = transform.position.y;
        defaultFlyLeft = transform.position.x - 2;
        defaultFlyRight = transform.position.x + 2;
        flyLeft = defaultFlyLeft;
        flyRight = defaultFlyRight;
        
    }

    void Update()
    {
        sliderHP.value = health;
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
        if(getAttack == false)
        {
            flyAmount.x = (flyDirection * flySpeed) * Time.deltaTime;
            if(flyDirection > 0) //Move Right
            {
                transform.eulerAngles = new Vector2(0,180);
                flyAmount.x = -flyAmount.x;
                if(transform.position.x >= defaultFlyRight)
                {
                    flyDirection = -1.0f;
                }
            }
            if(flyDirection < 0) //Move left
            {
                transform.eulerAngles = new Vector2(0,0);
                if(transform.position.x <= flyLeft)
                {
                    flyDirection = 1.0f;
                }
            }
            
        }
        transform.Translate(flyAmount); //Move
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
        if(flySpeed == 1.5f && getAttack == false && Walk.isPlaying == false && Time.timeScale == 1f) Walk.Play();
        else if(flySpeed == 3f && getAttack == false && Run.isPlaying == false && Time.timeScale == 1f) Run.Play();
        else if(flySpeed == 6f && getAttack == false && Attack.isPlaying == false) Attack.Play();

        nextAttackTime += Time.deltaTime;

        if(sightRange.PlayerFounded == true)
        {
            foundPlayer = true;
            if(isAttack == false) 
            {
                flySpeed = 3f;
                flyLeft = defaultFlyLeft - 6;
                flyRight = defaultFlyRight + 6;
            }
            if(isAttack == false)
            {
                transform.LookAt(player.transform.position);
                transform.Rotate(new Vector3(0f,90f,0f), Space.Self);
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,player.transform.position.y,transform.position.z), Time.deltaTime);
            }
            if(transform.position.y < defaultY && isAttack == false)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,defaultY,transform.position.z), Time.deltaTime);
            }
            if(attackRange.AttackPlayer == true && nextAttackTime > attackCooldownTime)
            {
                StartCoroutine(AttackAnimation());
            }
        }
        if(sightRange.PlayerFounded == false)
        {
            foundPlayer = false;
            flySpeed = 1.5f;
            flyLeft = defaultFlyLeft; 
            flyRight = defaultFlyRight;
            if(transform.position.y < defaultY)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,defaultY,transform.position.z), Time.deltaTime);
            }
        }
        if(getAttack == true)
        {
            getDamageAnimation();
            KnockBackAnimation();
        }
        if(attackRange.AttackPlayer == false)
        {
            animator.SetBool("Attack", false);
        }
        DeathEffect.transform.position = transform.position;
        droppedItem.transform.position = transform.position;
        if(health <= 0)
        {
            DeathEffect.SetActive(true);
            droppedItem.SetActive(true);
            soulAbsorb.start = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(player.isImmortal == false)
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
        if(other.gameObject.CompareTag("ExCarrotSword"))
        {
            if(isImmortal == false && player.attack == true)
            {
                Monster1GetDamage.Play();
                getAttack = true;
                health -= 1;
                isImmortal = true;
            }
        }
    }

    public IEnumerator AttackAnimation()
    {
        isAttack = true;
        flySpeed = 6;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.3f);
        flySpeed = 3f;
        animator.SetBool("Attack", false);
        isAttack = false;
        flyLeft = 0.1f; //Force Monster to move back.
        flyRight = 0.1f; //Force Monster to move back.
        nextAttackTime = 0;
        yield return new WaitForSeconds(1f);
    }

    public void KnockBackAnimation()
    {
        isImmortal = true;
        if((transform.rotation.eulerAngles.y >= 91 && transform.rotation.eulerAngles.y <= 270) || (transform.rotation.eulerAngles.y <= -91 && transform.rotation.eulerAngles.y >= -270))
        //if(transform.rotation.eulerAngles.y == 180 || transform.rotation.eulerAngles.y == -180) 
        {        
            
            //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x-1.8f,defaultY,transform.position.z), 3 * Time.deltaTime);
            /*transform.eulerAngles = new Vector2(0,180);
            transform.Translate(Vector2.right * 7 * Time.deltaTime);*/
            transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, new Vector3(transform.position.x-1.8f,defaultY,transform.position.z), 3 * Time.deltaTime), 0.1f);
            StartCoroutine(DisableMovement());
        }
        else if((transform.rotation.eulerAngles.y >= -90 && transform.rotation.eulerAngles.y <= 90) || (transform.rotation.eulerAngles.y <= -271 && transform.rotation.eulerAngles.y >= -450))
        //else if(transform.rotation.eulerAngles.y == 0 || transform.rotation.eulerAngles.y == -360) 
        {     
            //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x+1.8f,defaultY,transform.position.z), 3 * Time.deltaTime);
            /*transform.eulerAngles = new Vector2(0,0);
            transform.Translate(Vector2.right * 7 * Time.deltaTime);*/
            transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, new Vector3(transform.position.x+1.8f,defaultY,transform.position.z), 3 * Time.deltaTime), 0.1f);
            StartCoroutine(DisableMovement());
        }
    }

    public void getDamageAnimation()
    {
        StartCoroutine(Blinking());
    }

    public IEnumerator DisableMovement()
    {
        yield return new WaitForSeconds(0.5f);
        isImmortal = false;
        getAttack = false;
    }

    public IEnumerator Blinking()
    {
        sprite.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        sprite.color = normalTransparent;
        yield return new WaitForSeconds(0.15f);
        sprite.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        sprite.color = normalTransparent;
        yield return new WaitForSeconds(0.15f);
        /*sprite.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        sprite.color = normalTransparent;
        yield return new WaitForSeconds(0.15f);
        sprite.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        sprite.color = normalTransparent;*/
    }
}