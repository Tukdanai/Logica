using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float speed = 4.0f;
    public float maxSpeed = 10.0f;
    public float jumpSpeed = 8.8f;
    public float JumpPower = 35f;
    public bool isGrounded;
    public bool Grounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rigidBody2D;
    private Physics2D physics2D;
    Animator animator;
    public int health;
    public bool isImmortal;
    public bool getHP;
    public bool canMove;
    public bool DisableMovementDone;
    [SerializeField] GameObject Sword;
    [SerializeField] GameObject Slash;
    [SerializeField] public GameObject absorbMonsterSoul;
    public bool IsHaveSword;
    public bool attack; 
    public bool attackCooldown;
    [SerializeField] GameObject Menu;
    [SerializeField] AudioSource OpenMenu;
    
    public bool isFalling;
    public bool wasFalling;
    public float positionBeforeFall;
    public float positionAfterFall;
    [SerializeField] GetDamage getDamage;
    public bool playerGetDamage;
    public string CurrentChapter;
    public string CurrentMapZone;
    [SerializeField] GameObject LoadScene;
    [SerializeField] HelpPage helpPage;
    public int autoSaveSlot;
    public bool ReadyToSave;
    public float playedTime;
    public bool isLoadFromMainMenu;
    public bool isCameraLocked;
    public bool canPause;
    public bool canAttack;
    public bool canHelp;
    public bool canClosePuzzle;
    [SerializeField] AudioSource Jump;
    [SerializeField] public AudioSource GetDamageSound;
    [SerializeField] AudioSource SlashSound;
    [SerializeField] GameObject DeadBody;
    [SerializeField] AudioSource Death;
    [SerializeField] AudioSource CloseUI;
    private bool isDeath;
    public int currentHelpPage;
    public int LogicWrongCount;
    public int BooleanWrongCount;
    public int JKWrongCount;
    public int JKBossHP;
    public bool canSaveInChapter3;

    //[SerializeField] GameObject inventoryGameObject;

    void Start()
    {
        rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        DisableMovementDone = false;
        isImmortal = false;
        getHP = false;
        isLoadFromMainMenu = false;
        Menu.SetActive(false);
        Slash.SetActive(false);
        absorbMonsterSoul.SetActive(false);
        isCameraLocked = false;
        canClosePuzzle = true;
        isDeath = false;
        Time.timeScale = 1f;
        DeadBody.SetActive(false);
        IsHaveSword = true;
        getDamage.AllNormalTransparent();
        JKBossHP = 5;
        canSaveInChapter3 = true;
    }

    void Update()
    {
        playedTime += Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer); //Check if on GroundLayer and for debug double jump.
        wasFalling = isFalling;

        transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,0);
        if(isGrounded == true)
        {
            animator.SetBool("Grounded", true); //for Animation
            if(canMove == true)
            {
                animator.SetBool("Jump",false); //when get attecked.
                animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));
            }
            if(canMove == false)
            {
                //transform.Translate(Vector2.right * 0);
                animator.SetFloat("Speed",0f);
            }
            isFalling = false;
            if(wasFalling && !isFalling) //if player is on a ground after falling.
            {
                positionAfterFall = transform.position.y;
                //Debug.Log("Player fell " + (positionBeforeFall - transform.position.y));
                if(positionBeforeFall - positionAfterFall >= 5 && positionBeforeFall - positionAfterFall < 7.5f && isImmortal == false) //Fall Damage System
                {
                    health -= 1;
                    if(health > 0) 
                    {
                        GetDamageSound.Play();
                        getDamage.getDamageAnimation();
                    }
                    KnockBackAnimation();
                    positionBeforeFall = 0;
                    positionAfterFall = 0;
                }
                if(positionBeforeFall - positionAfterFall >= 7.5f && positionBeforeFall - positionAfterFall < 10 && isImmortal == false) //Fall Damage System
                {
                    health -= 2;
                    if(health > 0) 
                    {
                        GetDamageSound.Play();
                        getDamage.getDamageAnimation();
                    }
                    KnockBackAnimation();
                    positionBeforeFall = 0;
                    positionAfterFall = 0;
                }
                if(positionBeforeFall - positionAfterFall >= 10 && isImmortal == false) //Fall Damage System
                {
                    health -= 3;
                    if(health > 0) 
                    {
                        GetDamageSound.Play();
                        getDamage.getDamageAnimation();
                    }
                    KnockBackAnimation();
                    positionBeforeFall = 0;
                    positionAfterFall = 0;
                }
            }
        }
        if(isGrounded != true)
        {
            animator.SetBool("Grounded", false); //for Animation
        }
        if(Input.GetAxis("Horizontal") < -0.1f && canMove == true) 
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,180);
        }
        if(Input.GetAxis("Horizontal") > 0.1f && canMove == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,0);
        }   
        if(Input.GetButtonDown("Jump") && isGrounded && canMove == true)
        {            
            if(Jump.isPlaying == false) Jump.Play();
            animator.SetBool("Jump",true);
            rigidBody2D.AddForce(jumpSpeed * (Vector2.up * JumpPower));
        }
        if(isGrounded == false && rigidBody2D.velocity.y < 0)
        {
            isFalling = true;
        }
        if(!wasFalling && isFalling) //save position at the highest y before fall.
        {
            positionBeforeFall = transform.position.y;
        }
        if(isGrounded == true && DisableMovementDone == true && LoadScene.activeSelf == false )
        {
            canMove = true;
            DisableMovementDone = false;
        }
        if(health > 5)
        {
            health = 5;
        }
        
        if(health <= 0)
        {
            if(transform.rotation.eulerAngles.y == 0) DeadBody.transform.eulerAngles = new Vector2(0,0);
            else if(transform.rotation.eulerAngles.y == 180) DeadBody.transform.eulerAngles = new Vector2(0,180);
            IsHaveSword = false;
            canMove = false;
            canAttack = false;
            canPause = false;
            getDamage.ZeroTransparent();
            DeadBody.SetActive(true);
            if(isDeath == false) Death.Play();
            isDeath = true;
            StartCoroutine(DelayDeadMenu());
        }
        if(IsHaveSword == false)
        {
            Sword.SetActive(false);
        }
        if(IsHaveSword == true)
        {
            Sword.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && attackCooldown == false && Sword.activeSelf == true && canPause == true && canAttack == true && Menu.activeSelf == false)
        {
            SlashSound.Play();
            attack = true;
            animator.SetBool("Attack", true);
            Slash.SetActive(true);
            StartCoroutine(AttackCooldown());
        }
        if(transform.eulerAngles.y == 180)
        {
            Slash.transform.position = new Vector3(Slash.transform.position.x,Slash.transform.position.y,-2);
        }
        if(transform.eulerAngles.y == 0)
        {
            Slash.transform.position = new Vector3(Slash.transform.position.x,Slash.transform.position.y,-2);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && helpPage.isHelpPageOpen != true && canPause == true && canClosePuzzle == true && Menu.activeSelf == false && player.activeSelf == true && attack == false)
        {
            OpenMenu.Play();
            Menu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && helpPage.isHelpPageOpen == true)
        {
            CloseUI.Play();
            helpPage.CloseCurrentPage();
        }
        if(helpPage.isHelpPageOpen == true || Menu.activeSelf == true || LoadScene.activeSelf == true)
        {
            canAttack = false;
            if(Menu.activeSelf == true || LoadScene.activeSelf == true) canMove = false;
        }
        if(helpPage.isHelpPageOpen == false && Menu.activeSelf == false && LoadScene.activeSelf == false) 
        {
            canAttack = true;
        }
    }

    public void KnockBackAnimation()
    {
        isImmortal = true;
        if(transform.rotation.eulerAngles.y == 0)
        {
            animator.SetBool("Jump",true);        
            rigidBody2D.velocity = new Vector2(-1 * 2.2f, 4f);
            canMove = false;
            DisableMovementDone = false;
            StartCoroutine(DisableMovement());
        }
        else if(transform.rotation.eulerAngles.y == 180)
        {
            animator.SetBool("Jump", true);        
            rigidBody2D.velocity = new Vector2(1 * 2.2f, 4f);
            canMove = false;
            DisableMovementDone = false;
            StartCoroutine(DisableMovement());
        }
    }

    public IEnumerator DisableMovement()
    {
        DisableMovementDone = false;
        yield return new WaitForSeconds(0.8f);
        DisableMovementDone = true;
        isImmortal = false;
    }

    public void KnockBackFromMonster(float monsterRotationY)
    {
        isImmortal = true;
        if((monsterRotationY >= 91 && monsterRotationY <= 270) || (monsterRotationY <= -91 && monsterRotationY >= -270))
        {
            animator.SetBool("Jump",true);        
            rigidBody2D.velocity = new Vector2(1 * 2.2f, 4f);
            canMove = false;
            DisableMovementDone = false;
            StartCoroutine(DisableMovement());
        }
        else if((monsterRotationY >= -90 && monsterRotationY <= 90) || (monsterRotationY <= -271 && monsterRotationY >= -450))
        {
            animator.SetBool("Jump", true);        
            rigidBody2D.velocity = new Vector2(-1 * 2.2f, 4f);
            canMove = false;
            DisableMovementDone = false;
            StartCoroutine(DisableMovement());
        }
    }

    public IEnumerator AttackCooldown()
    {
        attackCooldown = true;
        yield return new WaitForSeconds(0.001f);
        animator.SetBool("Attack", false);  
        yield return new WaitForSeconds(0.4f);
        attackCooldown = false;
        attack = false;
        Slash.SetActive(false);
    }

    public void WaitForCanPause()
    {
        StartCoroutine(DelayPause());
    }

    public IEnumerator DelayPause()
    {
        yield return new WaitForSeconds(0.01f);
        canPause = true;
    }

    public IEnumerator DelayDeadMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("DeadMenu");
    }
}
 

 
 

 