using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BooleanBoss : MonoBehaviour
{
    public int health;
    public Slider sliderHP;
    public bool isImmortal;
    public bool getAttack;
    public Animator animator;
    [SerializeField] SpriteRenderer BossSprite;
    [SerializeField] public GameObject Beam;
    [SerializeField] public BossBeam bossBeam;
    [SerializeField] Boss2Minion minion1;
    [SerializeField] Boss2Minion minion2;
    [SerializeField] GameObject minion1GameObject;
    [SerializeField] GameObject minion2GameObject;
    [SerializeField] PlayerController player;
    [SerializeField] GetDamage getDamage;
    [SerializeField] GameObject BossGameObject;
    [SerializeField] GameObject DeadEffect;
    [SerializeField] GameObject EndGate;

    [SerializeField] GameObject puzzle1;
    [SerializeField] GameObject puzzle2;
    [SerializeField] GameObject puzzle3;
    [SerializeField] GameObject puzzle4;
    [SerializeField] GameObject puzzle5;
    [SerializeField] GameObject puzzle6;
    [SerializeField] GameObject puzzle7;
    [SerializeField] GameObject puzzle8;
    [SerializeField] GameObject puzzle9;
    [SerializeField] GameObject puzzle10;
    [SerializeField] GameObject puzzle11;
    [SerializeField] GameObject puzzle12;
    [SerializeField] GameObject puzzle13;
    [SerializeField] GameObject puzzle14;
    [SerializeField] GameObject puzzle15;
    [SerializeField] GameObject puzzle16;
    [SerializeField] GameObject puzzle17;
    [SerializeField] GameObject puzzle18;
    [SerializeField] GameObject puzzle19;
    [SerializeField] GameObject puzzle20;
    [SerializeField] GameObject puzzle21;
    [SerializeField] GameObject puzzle22;
    [SerializeField] GameObject puzzle23;
    [SerializeField] GameObject puzzle24;
    [SerializeField] GameObject puzzle25;

    public int HeartRound;
    [SerializeField] GameObject Heart1;
    [SerializeField] GameObject Heart2;
    [SerializeField] GameObject Heart3;

    [SerializeField] AudioSource BossGetAttacked;
    [SerializeField] AudioSource BossDeath;
    private bool showBeamTutorial;
    [SerializeField] GameObject BeamTutorial;
    [SerializeField] AudioSource PopUp;
    [SerializeField] GameObject NextChapterTutorial;

    public bool question1;
    public bool question2;
    public bool question3;
    public bool dropHeart;
    public bool minionImmortal;
    public bool isDrop;
    public bool isDead;

    private Color normalTransparent = new Color(1f, 1f, 1f, 1f);
    private Color lowTransparent = new Color(1f, 1f, 1f, 0.5f);

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        health = 30;
        sliderHP.maxValue = health;
        sliderHP.value = health;
        isImmortal = false;
        getAttack = false;
        question1 = true;
        question2 = false;
        question3 = false;
        Beam.SetActive(false);
        dropHeart = true;
        minionImmortal = false;
        DeadEffect.SetActive(false);
        isDrop = true;
        isDead = false;
        EndGate.SetActive(false);
        showBeamTutorial = true;
    }

    void Update()
    {
        sliderHP.value = health;

        if(health <= 30 && health > 18) 
        {
            question1 = true;
            question2 = false;
            question3 = false;
        }
        
        if(health <= 18 && health > 6) 
        {
            question1 = false;
            question2 = true;
            question3 = false;
            HeartRound = 1;
            if(dropHeart == true)
            {
                dropHeart = false;
                Heart1.SetActive(true);
                Heart1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                StartCoroutine(DelayFreezeHeart());
            }
        }
        
        if(health <= 6 && health > 0) 
        {
            isDrop = false;
            question1 = false;
            question2 = false;
            question3 = true;
            HeartRound = 2;
            if(dropHeart == false)
            {
                dropHeart = true;
                Heart2.SetActive(true);
                Heart2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                StartCoroutine(DelayFreezeHeart());
            }
        }
        
        if(getAttack == true && isDead == false) 
        {
            StartCoroutine(Blinking());
            StartCoroutine(ImmortalDeley());
        }

        if(puzzle1.activeSelf == true || puzzle3.activeSelf == true || puzzle5.activeSelf == true || puzzle7.activeSelf == true || puzzle9.activeSelf == true || puzzle11.activeSelf == true || puzzle13.activeSelf == true || puzzle15.activeSelf == true || puzzle17.activeSelf == true || puzzle19.activeSelf == true || puzzle21.activeSelf == true || puzzle23.activeSelf == true || puzzle25.activeSelf == true)
        {
            minion1.Correct = true;
            minion2.Correct = false;
        }

        if(puzzle2.activeSelf == true || puzzle4.activeSelf == true || puzzle6.activeSelf == true || puzzle8.activeSelf == true || puzzle10.activeSelf == true || puzzle12.activeSelf == true || puzzle14.activeSelf == true || puzzle16.activeSelf == true || puzzle18.activeSelf == true || puzzle20.activeSelf == true || puzzle22.activeSelf == true || puzzle24.activeSelf == true)
        {
            minion1.Correct = false;
            minion2.Correct = true;
        }

        if(minion1.alive == true || minion2.alive == true)
        {
            minion1.alive = false;
            minion2.alive = false;
            ShowQuestion();
        }

        if(minion1.immortal == true || minion2.immortal == true)
        {
            minion1.immortal = true;
            minion2.immortal = true;
        }

        if(minionImmortal == false)
        {
            minion1.immortal = false;
            minion2.immortal = false;
            minionImmortal = true;
        }

        if(isDead == true) Beam.SetActive(false);
    }

    public void ShowQuestion()
    {
        int random;

        if(question1 == true)
        {
            random = Random.Range(1,11);
            if(random == 1) puzzle1.SetActive(true);
            else if(random == 2) puzzle2.SetActive(true);
            else if(random == 3) puzzle3.SetActive(true);
            else if(random == 4) puzzle4.SetActive(true);
            else if(random == 5) puzzle5.SetActive(true);
            else if(random == 6) puzzle6.SetActive(true);
            else if(random == 7) puzzle7.SetActive(true);
            else if(random == 8) puzzle8.SetActive(true);
            else if(random == 9) puzzle9.SetActive(true);
            else if(random == 10) puzzle10.SetActive(true);
        }
        else if(question2 == true)
        {
            random = Random.Range(11,21);
            if(random == 11) puzzle11.SetActive(true);
            else if(random == 12) puzzle12.SetActive(true);
            else if(random == 13) puzzle13.SetActive(true);
            else if(random == 14) puzzle14.SetActive(true);
            else if(random == 15) puzzle15.SetActive(true);
            else if(random == 16) puzzle16.SetActive(true);
            else if(random == 17) puzzle17.SetActive(true);
            else if(random == 18) puzzle18.SetActive(true);
            else if(random == 19) puzzle19.SetActive(true);
            else if(random == 20) puzzle20.SetActive(true);
        }
        else if(question3 == true)
        {
            random = Random.Range(21,26);
            if(random == 21) puzzle21.SetActive(true);
            else if(random == 22) puzzle22.SetActive(true);
            else if(random == 23) puzzle23.SetActive(true);
            else if(random == 24) puzzle24.SetActive(true);
            else if(random == 25) puzzle25.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("ExCarrotSword") && isImmortal == false && isDead == false)
        {
            if(player.attack == true)
            {
                getAttack = true;
                health -= 1;        
                BossGetAttacked.Play();
                if(health <= 0) 
                {
                    Heart3.SetActive(true);
                    StartCoroutine(DeadAnimation());
                }
            }
        }
    }

    public IEnumerator DelayFreezeHeart()
    {
        if(HeartRound == 1)
        {
            yield return new WaitForSeconds(1.41f);
            Heart1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else if(HeartRound == 2)
        {
            yield return new WaitForSeconds(1.41f);
            Heart2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    public void CloseAllPuzzle()
    {
        puzzle1.SetActive(false);
        puzzle2.SetActive(false);
        puzzle3.SetActive(false);
        puzzle4.SetActive(false);
        puzzle5.SetActive(false);
        puzzle6.SetActive(false);
        puzzle7.SetActive(false);
        puzzle8.SetActive(false);
        puzzle9.SetActive(false);
        puzzle10.SetActive(false);
        puzzle11.SetActive(false);
        puzzle12.SetActive(false);
        puzzle13.SetActive(false);
        puzzle14.SetActive(false);
        puzzle15.SetActive(false);
        puzzle16.SetActive(false);
        puzzle17.SetActive(false);
        puzzle18.SetActive(false);
        puzzle19.SetActive(false);
        puzzle20.SetActive(false);
        puzzle21.SetActive(false);
        puzzle22.SetActive(false);
        puzzle23.SetActive(false);
        puzzle24.SetActive(false);
        puzzle25.SetActive(false);
    }

    public void Shoot()
    {
        StartCoroutine(ShootBeam());
    }

    public IEnumerator ShootBeam()
    {
        if(minion1.dead == true)
        {
            minion1.dead = false;
            bossBeam.canDamage = false;
            yield return new WaitForSeconds(4f);
            if(showBeamTutorial == true)
            {
                PopUp.Play();
                BeamTutorial.SetActive(true);
            } 
            showBeamTutorial = false;
            Beam.SetActive(true);
            yield return new WaitForSeconds(5f);
            bossBeam.canDamage = true;
            if(BeamTutorial.activeSelf == true) BeamTutorial.SetActive(false);
            minion1GameObject.transform.eulerAngles = new Vector3(0,180,0);
            minion1.sprite.color = new Color(1f, 1f, 1f, 1f);
            if(isDead == false)
            {
                minion1GameObject.SetActive(true);
                minion1.MinionSpawn();
            }
            minionImmortal = false;
            yield return new WaitForSeconds(2f);
            Beam.SetActive(false);
        }
        else if(minion2.dead == true)
        {
            minion2.dead = false;
            bossBeam.canDamage = false;
            yield return new WaitForSeconds(4.5f);
            if(showBeamTutorial == true)
            {
                PopUp.Play();
                BeamTutorial.SetActive(true);
            } 
            showBeamTutorial = false;
            Beam.SetActive(true);
            yield return new WaitForSeconds(5f);
            bossBeam.canDamage = true;
            if(BeamTutorial.activeSelf == true) BeamTutorial.SetActive(false);
            minion2GameObject.transform.eulerAngles = new Vector3(0,180,0);
            minion2.sprite.color = new Color(1f, 1f, 1f, 1f);
            if(isDead == false)
            {
                minion2GameObject.SetActive(true);
                minion2.MinionSpawn();
            }
            minionImmortal = false;
            yield return new WaitForSeconds(2f);
            Beam.SetActive(false);
        }
    }

    public IEnumerator Blinking()
    {
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.15f);
    }

    public IEnumerator ImmortalDeley()
    {
        isImmortal = true;
        getAttack = false;
        yield return new WaitForSeconds(0.4f);
        isImmortal = false;
    }

    public IEnumerator DeadAnimation()
    {
        isDead = true;
        if(minion1GameObject.activeSelf == true) minion1.MinionDead();
        if(minion2GameObject.activeSelf == true) minion2.MinionDead();
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(1.5f);
        BossDeath.Play();
        DeadEffect.SetActive(true);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.15f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.2f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.1f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.1f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = normalTransparent;
        yield return new WaitForSeconds(0.05f);
        BossSprite.color = lowTransparent;
        yield return new WaitForSeconds(0.5f);
        DeadEffect.SetActive(false);
        PopUp.Play();
        NextChapterTutorial.SetActive(true);
        EndGate.SetActive(true);
        BossGameObject.SetActive(false);
    }
}
