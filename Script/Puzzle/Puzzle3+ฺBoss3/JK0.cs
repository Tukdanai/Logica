using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JK0 : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    public Animator animator;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject QnGameObject;
    [SerializeField] JKFloor floor0;
    [SerializeField] JKFloor floor1;
    [SerializeField] GameObject Lightning0;
    [SerializeField] GameObject Lightning1;
    [SerializeField] protected TextMeshProUGUI J;
    [SerializeField] protected TextMeshProUGUI K;
    [SerializeField] protected TextMeshProUGUI Qn;
    [SerializeField] protected TextMeshProUGUI TimeLeft;
    public float time;
    private int seconds;
    private int random;
    private string nextQn;
    private bool startNextPuzzle;
    [SerializeField] GetDamage getDamage;
    [SerializeField] AudioSource PlayerGetDamage;
    [SerializeField] GameObject Teleport;
    [SerializeField] Animator warp;
    [SerializeField] AudioSource WarpSound;
    [SerializeField] AudioSource BossCast;
    [SerializeField] AudioSource BossCalculate;
    [SerializeField] AudioSource BossThunder;
    [SerializeField] AudioSource LightningStrike;
    [SerializeField] SavedManager savedManager;
    private bool playerDied;
    private bool canAnswer;

    void Start()
    {
        animator = Boss.GetComponent<Animator>();
        time = 19.00f;
        startNextPuzzle = true;     
        playerDied = false;
        canAnswer = false;
    }

    void Update() 
    {
        time -= Time.deltaTime; 
        if(time < 0f) time = 0.00f;
        seconds = (int)(time % 60);
        TimeLeft.text = seconds.ToString();

        if(startNextPuzzle == true) StartCoroutine(RandomPuzzle());

        if(floor0.activate == true && nextQn == "1" && TimeLeft.text == "0" && canAnswer == true) StartCoroutine(Lightning0Wrong());
        else if(floor0.activate == true && nextQn == "0" && TimeLeft.text == "0" && canAnswer == true) StartCoroutine(Lightning0Correct());
        else if(floor1.activate == true && nextQn == "0" && TimeLeft.text == "0" && canAnswer == true) StartCoroutine(Lightning1Wrong());
        else if(floor1.activate == true && nextQn == "1" && TimeLeft.text == "0" && canAnswer == true) StartCoroutine(Lightning1Correct());
        else if (floor0.activate == false && floor1.activate == false && nextQn == "0" && TimeLeft.text == "0" && canAnswer == true) StartCoroutine(Lightning1Wrong());
        else if (floor0.activate == false && floor1.activate == false && nextQn == "1" && TimeLeft.text == "0" && canAnswer == true) StartCoroutine(Lightning0Wrong());

        if(Teleport.activeSelf == true) player.canMove = false;
        if(Lightning0.activeSelf == true || Lightning1.activeSelf == true) player.canMove = false;
        if(playerDied == true) player.canMove = false;
    }

    public IEnumerator RandomPuzzle()
    {
        startNextPuzzle = false;
        QnGameObject.SetActive(false);
        BossCalculate.Play();
        animator.SetBool("Tired", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Tired", false);
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("Tired", true);
        yield return new WaitForSeconds(2.5f);
        animator.SetBool("Tired", false);
        animator.SetBool("Spell", true);
        BossCast.Play();
        time = 15.00f;
        random = Random.Range(1, 3);
        if(random == 1) J.text = "0";
        else if(random == 2) J.text = "1";
        random = Random.Range(1, 3);
        if(random == 1) K.text = "0";
        else if(random == 2) K.text = "1";
        random = Random.Range(1, 3);
        if(random == 1) Qn.text = "0";
        else if(random == 2) Qn.text = "1";

        if(J.text == "0" && K.text == "1") nextQn = "0";
        else if(J.text == "1" && K.text == "0") nextQn = "1";
        else if(J.text == "1" && K.text == "1")
        {
            if(Qn.text == "0") nextQn = "1";
            else if(Qn.text == "1") nextQn = "0";
        }
        else if(J.text == "0" && K.text == "0") nextQn = Qn.text;
        QnGameObject.SetActive(true);
        canAnswer = true;
    }

    public IEnumerator Lightning0Wrong()
    {
        canAnswer = false;
        QnGameObject.SetActive(false);
        BossCast.Pause();
        animator.SetBool("Spell", false);
        animator.SetBool("Thunder", true);
        player.canMove = false;
        BossThunder.Play();
        yield return new WaitForSeconds(2f);
        if(LightningStrike.isPlaying == false) LightningStrike.Play();
        Lightning1.SetActive(true);
        player.health -= 1;
        if(player.health > 0)
        {
            PlayerGetDamage.Play();
            getDamage.getDamageAnimation();
        }
        player.KnockBackAnimation();
        yield return new WaitForSeconds(0.5f);
        Lightning1.SetActive(false);
        animator.SetBool("Thunder", false);
        player.canMove = true;
        if(player.health <= 0)
        {
            playerDied = true;
            player.canMove = false;
            player.health = 5;
            savedManager.SaveHPandTime();
        }
        else if(player.health > 0) startNextPuzzle = true;
    }

    public IEnumerator Lightning0Correct()
    {
        canAnswer = false;
        QnGameObject.SetActive(false);
        BossCast.Pause();
        animator.SetBool("Spell", false);
        animator.SetBool("Thunder", true);
        player.canMove = false;
        BossThunder.Play();
        yield return new WaitForSeconds(2f);
        if(LightningStrike.isPlaying == false) LightningStrike.Play();
        Lightning0.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Lightning0.SetActive(false);
        animator.SetBool("Thunder", false);
        player.canMove = false;
        if(WarpSound.isPlaying == false) WarpSound.Play();
        Teleport.SetActive(true);
        warp.SetBool("Warp",true);
        yield return new WaitForSeconds(2f);
        warp.SetBool("Warp",false);
        Teleport.SetActive(false);
        savedManager.SaveHPandTime();
        SceneManager.LoadScene("Chapter3_1");
    }

    public IEnumerator Lightning1Wrong()
    {
        canAnswer = false;
        QnGameObject.SetActive(false);
        BossCast.Pause();
        animator.SetBool("Spell", false);
        animator.SetBool("Thunder", true);
        player.canMove = false;
        BossThunder.Play();
        yield return new WaitForSeconds(2f);
        if(LightningStrike.isPlaying == false) LightningStrike.Play();
        Lightning0.SetActive(true);
        player.health -= 1;
        if(player.health > 0)
        {
            PlayerGetDamage.Play();
            getDamage.getDamageAnimation();
        }
        player.KnockBackAnimation();
        yield return new WaitForSeconds(0.5f);
        Lightning0.SetActive(false);
        animator.SetBool("Thunder", false);
        player.canMove = true;
        if(player.health <= 0)
        {
            playerDied = true;
            player.canMove = false;
            player.health = 5;
            savedManager.SaveHPandTime();
        }
        else if(player.health > 0) startNextPuzzle = true;
    }

    public IEnumerator Lightning1Correct()
    {
        canAnswer = false;
        QnGameObject.SetActive(false);
        BossCast.Pause();
        animator.SetBool("Spell", false);
        animator.SetBool("Thunder", true);
        player.canMove = false;
        BossThunder.Play();
        yield return new WaitForSeconds(2f);
        if(LightningStrike.isPlaying == false) LightningStrike.Play();
        Lightning1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Lightning1.SetActive(false);
        animator.SetBool("Thunder", false);
        player.canMove = false;
        if(WarpSound.isPlaying == false) WarpSound.Play();
        Teleport.SetActive(true);
        warp.SetBool("Warp",true);
        yield return new WaitForSeconds(2f);
        warp.SetBool("Warp",false);
        Teleport.SetActive(false);
        savedManager.SaveHPandTime();
        SceneManager.LoadScene("Chapter3_1");
    }
}
