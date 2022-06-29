using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JK1 : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject JK1_1;
    [SerializeField] GameObject JK1_2;
    [SerializeField] JK1Gate0 Gate0;
    [SerializeField] JK1Gate1 Gate1;
    [SerializeField] GameObject Gate0GameObject;
    [SerializeField] GameObject Gate1GameObject;
    private bool IsCollided;
    private bool canPressButton;
    private bool isStriking;
    private bool PuzzleCorrect;
    private bool PuzzleWrong;
    [SerializeField] protected TextMeshProUGUI Input1;
    [SerializeField] protected TextMeshProUGUI Input2;
    [SerializeField] protected TextMeshProUGUI Output1;
    [SerializeField] protected TextMeshProUGUI Gate0GateNumber;
    [SerializeField] protected TextMeshProUGUI Gate1GateNumber;
    private int random;
    private int randomWire;
    private string j1;
    private string k1;
    private string q1;
    private string qbar1;
    private string out1;
    private string Answer;
    [SerializeField] GetDamage getDamage;
    [SerializeField] AudioSource PlayerGetDamage;
    [SerializeField] GameObject Teleport;
    [SerializeField] Animator warp;
    [SerializeField] AudioSource WarpSound;
    [SerializeField] GameObject Lightning;
    [SerializeField] AudioSource LightningStrike;
    [SerializeField] AudioSource ClockTick;
    [SerializeField] Animator animator;
    [SerializeField] SavedManager savedManager;
    public List<string> DoorNum = new List<string>();
    private bool playerDied;
    
    void Start()
    {
        playerDied = false;
        IsCollided = false;
        canPressButton = true;
        isStriking = false;
        PuzzleCorrect = false;
        PuzzleWrong = false;
        DoorNum.Add("0");
        DoorNum.Add("1");
        Gate0GameObject.SetActive(false);
        Gate1GameObject.SetActive(false);
        Teleport.SetActive(false);
        Lightning.SetActive(false);
        JK1_1.SetActive(false);
        JK1_2.SetActive(false);

        //random Wire setting
        randomWire = Random.Range(1, 3);
        //Debug.Log(randomWire);
        if(randomWire == 1)
        {
            JK1_1.SetActive(true);
        }
        else if(randomWire == 2)
        {
            JK1_2.SetActive(true);
        }

        //setup variables of Current State
        JKFlipFlopRandomCurrentState();

        /*Debug.Log("j1 = " + j1);
        Debug.Log("k1 = " + k1);
        Debug.Log("q1 = " + q1);
        Debug.Log("qbar1 = " + qbar1);*/
    }

    void Update()
    {
        if(isStriking == false) Lightning.transform.position = new Vector3(player.transform.position.x+0.2f,player.transform.position.y+3.1f,player.transform.position.z);
        if(IsCollided == true && Input.GetKeyDown(KeyCode.E) && canPressButton == true)
        {
            if(ClockTick.isPlaying == false) ClockTick.Play();
            Output1.text = "?";
            Gate0GameObject.SetActive(true);
            Gate1GameObject.SetActive(true);
            RandomDoorNumber();
            Answer = JKFlipFlopNextStateCalculator();
            Debug.Log("Answer is " + Answer);
            AnswerChecking(Answer);
            canPressButton = false;
        }       

        if(Gate0.activate == true && Gate0.correct == true) PuzzleCorrect = true;
        else if(Gate1.activate == true && Gate1.correct == true) PuzzleCorrect = true;
        else if(Gate0.activate == true && Gate0.correct == false) PuzzleWrong = true;
        else if(Gate1.activate == true && Gate1.correct == false) PuzzleWrong = true;
        else 
        {
            PuzzleCorrect = false;
            PuzzleWrong = false;
        } 

        if(PuzzleCorrect == true)
        {
            player.canMove = false;
            StartCoroutine(WarpAnimation());
            Gate0.activate = false;
            Gate1.activate = false;
        }
        else if(PuzzleWrong == true)
        {
            player.canMove = false;
            StartCoroutine(LightningAnimation());
            Gate0.activate = false;
            Gate1.activate = false;
        }
        if(Teleport.activeSelf == true) player.canMove = false;
        if(Lightning.activeSelf == true) player.canMove = false;
        if(playerDied == true) player.canMove = false;
    }

    public IEnumerator WarpAnimation()
    {   
        player.canMove = false;
        if(WarpSound.isPlaying == false) WarpSound.Play();
        Teleport.SetActive(true);
        warp.SetBool("Warp",true);
        yield return new WaitForSeconds(2f);
        warp.SetBool("Warp",false);
        Teleport.SetActive(false);
        savedManager.SaveHPandTime();
        SceneManager.LoadScene("Chapter3_2");
    }

    public IEnumerator LightningAnimation()
    {
        player.canMove = false;
        isStriking = true;
        if(LightningStrike.isPlaying == false) LightningStrike.Play();
        Lightning.SetActive(true);
        animator.SetBool("Wrong",true);
        player.JKWrongCount += 1;
        player.health -= 1;
        if(player.health > 0)
        {
            PlayerGetDamage.Play();
            getDamage.getDamageAnimation();
        }
        player.KnockBackAnimation();
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Wrong",false);
        Lightning.SetActive(false);
        isStriking = false;
        yield return new WaitForSeconds(0.31f);
        player.canMove = false;
        if(player.health > 0)
        {
            player.canMove = false;
            Teleport.SetActive(true);
            if(WarpSound.isPlaying == false) WarpSound.Play();
            warp.SetBool("Warp",true);
            yield return new WaitForSeconds(2f);
            player.canMove = false;
            warp.SetBool("Warp",false);
            Teleport.SetActive(false);
            savedManager.SaveHPandTime();
            SceneManager.LoadScene("Chapter3_0");
        }
        else if(player.health <= 0)
        {
            playerDied = true;
            player.canMove = false;
            player.health = 5;
            savedManager.SaveHPandTime();
        }
    }

    public void JKFlipFlopRandomCurrentState()
    {
        //setup j1 and k1
        random = Random.Range(1, 3);
        if(random == 1)
        {
            Input1.text = "0";
            j1 = "0";
        }
        else if(random == 2)
        {
            Input1.text = "1";
            j1 = "1";
        }

        random = Random.Range(1, 3);
        if(random == 1)
        {
            Input2.text = "0";
            k1 = "0";
        }
        else if(random == 2)
        {
            Input2.text = "1";
            k1 = "1";
        }

        //setup q1, qbar1
        random = Random.Range(1, 3);
        if(random == 1)
        {
            Output1.text = "0";
            if(randomWire == 1)
            {
                q1 = "0";
                qbar1 = "1";
            }
            else if(randomWire == 2)
            {
                q1 = "1";
                qbar1 = "0";
            }
        }
        else if(random == 2)
        {
            Output1.text = "1";
            if(randomWire == 1)
            {
                q1 = "1";
                qbar1 = "0";
            }
            else if(randomWire == 2)
            {
                q1 = "0";
                qbar1 = "1";
            }
        }
    }

    public string JKFlipFlopNextStateCalculator()
    {
        //find q1 and qbar1
        if(j1 == "0" && k1 == "1")
        {
            q1 = "0";
            qbar1 = "1";
        }
        else if(j1 == "1" && k1 == "0")
        {
            q1 = "1";
            qbar1 = "0";
        }
        else if(j1 == "1" && k1 == "1")
        {
            if(q1 == "0") q1 = "1";
            else if(q1 == "1") q1 = "0";
            if(qbar1 == "0") qbar1 = "1";
            else if(qbar1 == "1") qbar1 = "0";
        }

        //set output1
        if(randomWire == 1) out1 = q1;
        else if(randomWire == 2) out1 = qbar1;
        
        return out1;
    }

    public void AnswerChecking(string answer)
    {
        /*Debug.Log(Gate0.number);
        Debug.Log(Gate1.number);
        Debug.Log("answer = " + answer);*/
        if(answer == "0") 
        {
            if(Gate0.number == "0") Gate0.correct = true;
            else if(Gate1.number == "0") Gate1.correct = true;
        }
        else if(answer == "1") 
        {
            if(Gate0.number == "1") Gate0.correct = true;
            else if(Gate1.number == "1") Gate1.correct = true;
        }
    }

    public void RandomDoorNumber()
    {
        int random0;
        int random1;
        random0 = Random.Range(0, 2);
        Gate0GateNumber.text = random0.ToString();
        Gate0.number = random0.ToString();
        for(int i = 0; i < DoorNum.Count; i++) 
        {
            if(DoorNum[i] == random0.ToString()) DoorNum.Remove(random0.ToString());
        }
        do
        {
            random1 = Random.Range(0, 2);
        }
        while(random1 == random0);
        for(int i = 0; i < DoorNum.Count; i++) 
        {
            if(DoorNum[i] == random1.ToString()) 
            {
                Gate1GateNumber.text = random1.ToString();
                Gate1.number = random1.ToString();
                DoorNum.Remove(random1.ToString());
            }
        }
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
}
