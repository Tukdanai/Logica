using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JK2 : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] JKBoss2 Boss;
    [SerializeField] GameObject BossGameObject;
    [SerializeField] GameObject JK2_1;
    [SerializeField] GameObject JK2_2;
    [SerializeField] GameObject JK2_3;
    [SerializeField] GameObject JK2_4;
    [SerializeField] JK2Gate0 Gate0;
    [SerializeField] JK2Gate1 Gate1;
    [SerializeField] JK2Gate2 Gate2;
    [SerializeField] JK2Gate3 Gate3;
    [SerializeField] public GameObject Gate0GameObject;
    [SerializeField] public GameObject Gate1GameObject;
    [SerializeField] public GameObject Gate2GameObject;
    [SerializeField] public GameObject Gate3GameObject;
    private bool IsCollided;
    private bool canPressButton;
    private bool isStriking;
    private bool PuzzleCorrect;
    private bool PuzzleWrong;
    [SerializeField] protected TextMeshProUGUI Input1;
    [SerializeField] protected TextMeshProUGUI Input2;
    [SerializeField] protected TextMeshProUGUI Output1;
    [SerializeField] protected TextMeshProUGUI Output2;
    [SerializeField] protected TextMeshProUGUI Gate0GateNumber;
    [SerializeField] protected TextMeshProUGUI Gate1GateNumber;
    [SerializeField] protected TextMeshProUGUI Gate2GateNumber;
    [SerializeField] protected TextMeshProUGUI Gate3GateNumber;
    private int random;
    private int randomWire;
    private string j1;
    private string k1;
    private string q1;
    private string qbar1;
    private string j2;
    private string k2;
    private string q2;
    private string qbar2;
    private string out1;
    private string out2;
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
    [SerializeField] AudioSource BossGetAttacked;
    [SerializeField] AudioSource BossDeath;
    
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
        DoorNum.Add("2");
        DoorNum.Add("3");
        Gate0.readyPress = false;
        Gate1.readyPress = false;
        Gate2.readyPress = false;
        Gate3.readyPress = false;
        Gate0GameObject.SetActive(false);
        Gate1GameObject.SetActive(false);
        Gate2GameObject.SetActive(false);
        Gate3GameObject.SetActive(false);
        Teleport.SetActive(false);
        Lightning.SetActive(false);
        JK2_1.SetActive(false);
        JK2_2.SetActive(false);
        JK2_3.SetActive(false);
        JK2_4.SetActive(false);

        //random Wire setting
        randomWire = Random.Range(1, 5);
        //Debug.Log(randomWire);
        if(randomWire == 1)
        {
            JK2_1.SetActive(true);
        }
        else if(randomWire == 2)
        {
            JK2_2.SetActive(true);
        }
        else if(randomWire == 3)
        {
            JK2_3.SetActive(true);
        }
        else if(randomWire == 4)
        {
            JK2_4.SetActive(true);
        }

        //setup variables of Current State
        JKFlipFlopRandomCurrentState();

        /*Debug.Log("j1 = " + j1);
        Debug.Log("k1 = " + k1);
        Debug.Log("q1 = " + q1);
        Debug.Log("qbar1 = " + qbar1);
        Debug.Log("j2 = " + j2);
        Debug.Log("k2 = " + k2);
        Debug.Log("q2 = " + q2);
        Debug.Log("qbar2 = " + qbar2);*/
    }

    void Update()
    {
        if(isStriking == false) Lightning.transform.position = new Vector3(player.transform.position.x+0.2f,player.transform.position.y+3.1f,player.transform.position.z);
        if(IsCollided == true && Input.GetKeyDown(KeyCode.E) && canPressButton == true)
        {
            if(ClockTick.isPlaying == false) ClockTick.Play();
            RandomDoorNumber();
            Answer = JKFlipFlopNextStateCalculator();
            Output1.text = "?";
            Output2.text = "?";
            Debug.Log("Answer is " + Answer);
            AnswerChecking(Answer);
            Gate0.readyPress = true;
            Gate1.readyPress = true;
            Gate2.readyPress = true;
            Gate3.readyPress = true;
            canPressButton = false;
        }

        if(Gate0.correct == true) BossGameObject.transform.position = new Vector2(Gate0GameObject.transform.position.x,Gate0GameObject.transform.position.y+1f);    
        else if(Gate1.correct == true) BossGameObject.transform.position = new Vector2(Gate1GameObject.transform.position.x,Gate1GameObject.transform.position.y+1f);
        else if(Gate2.correct == true) BossGameObject.transform.position = new Vector2(Gate2GameObject.transform.position.x,Gate2GameObject.transform.position.y+1f);
        else if(Gate3.correct == true) BossGameObject.transform.position = new Vector2(Gate3GameObject.transform.position.x,Gate3GameObject.transform.position.y+1f);        

        if(Gate0.activate == true && Gate0.correct == true) PuzzleCorrect = true;
        else if(Gate1.activate == true && Gate1.correct == true) PuzzleCorrect = true;
        else if(Gate2.activate == true && Gate2.correct == true) PuzzleCorrect = true;
        else if(Gate3.activate == true && Gate3.correct == true) PuzzleCorrect = true;
        else if(Gate0.activate == true && Gate0.correct == false) PuzzleWrong = true;
        else if(Gate1.activate == true && Gate1.correct == false) PuzzleWrong = true;
        else if(Gate2.activate == true && Gate2.correct == false) PuzzleWrong = true;
        else if(Gate3.activate == true && Gate3.correct == false) PuzzleWrong = true;
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
            Gate2.activate = false;
            Gate3.activate = false;
        }
        else if(PuzzleWrong == true)
        {
            player.canMove = false;
            StartCoroutine(LightningAnimation());
            Gate0.activate = false;
            Gate1.activate = false;
            Gate2.activate = false;
            Gate3.activate = false;
        }
        if(Teleport.activeSelf == true) player.canMove = false;
        if(Lightning.activeSelf == true) player.canMove = false;
        if(playerDied == true) player.canMove = false;
        
    }

    public IEnumerator WarpAnimation()
    {   
        player.canMove = false;
        player.JKBossHP -= 1;
        BossGameObject.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        if(player.JKBossHP > 0) 
        {
            BossGetAttacked.Play();
            Boss.animator.SetBool("Tired", true);
            if(WarpSound.isPlaying == false) WarpSound.Play();
            Teleport.SetActive(true);
            warp.SetBool("Warp",true);
            yield return new WaitForSeconds(2f);
            warp.SetBool("Warp",false);
            Boss.animator.SetBool("Tired", false);
            Teleport.SetActive(false);
            savedManager.SaveHPandTime();
            SceneManager.LoadScene("Chapter3_0");
        }
        else if(player.JKBossHP <= 0)
        {
            BossDeath.Play();
            Boss.animator.SetBool("Death", true);
            savedManager.SaveHPandTime();
            yield return new WaitForSeconds(3.8f);
            SceneManager.LoadScene("Result");
        }
    }

    public IEnumerator LightningAnimation()
    {
        player.canMove = false;
        player.JKWrongCount += 1;
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

        //setup q1, qbar1 and j2, k2
        random = Random.Range(1, 3);
        if(random == 1)
        {
            Output1.text = "0";
            if(randomWire == 1 || randomWire == 2)
            {
                q1 = "0";
                j2 = "0";
                qbar1 = "1";
                k2 = "1";
            } 
            else if(randomWire == 3 || randomWire == 4)
            {
                qbar1 = "0";
                k2 = "0";
                q1 = "1";
                j2 = "1";
            }
        }
        else if(random == 2)
        {
            Output1.text = "1";
            if(randomWire == 1 || randomWire == 2)
            {
                q1 = "1";
                j2 = "1";
                qbar1 = "0";
                k2 = "0";
            } 
            else if(randomWire == 3 || randomWire == 4)
            {
                qbar1 = "1";
                k2 = "1";
                q1 = "0";
                j2 = "0";
            }
        }

        //setup q2 and qbar2 
        random = Random.Range(1, 3);
        if(random == 1)
        {
            Output2.text = "0";
            if(randomWire == 1 || randomWire == 3)
            {
                q2 = "0";
                qbar2 = "1";
            } 
            else if(randomWire == 2 || randomWire == 4)
            {
                qbar2 = "0";
                q2 = "1";
            }
        }
        else if(random == 2)
        {
            Output2.text = "1";
            if(randomWire == 1 || randomWire == 3)
            {
                q2 = "1";
                qbar2 = "0";
            } 
            else if(randomWire == 2 || randomWire == 4)
            {
                qbar2 = "1";
                q2 = "0";
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
        if(randomWire == 1 || randomWire == 2) out1 = q1;
        else if(randomWire == 3 || randomWire == 4) out1 = qbar1;

        //find q2 and qbar2
        if(j2 == "0" && k2 == "1")
        {
            q2 = "0";
            qbar2 = "1";
        }
        else if(j2 == "1" && k2 == "0")
        {
            q2 = "1";
            qbar2 = "0";
        }
        else if(j2 == "1" && k2 == "1")
        {
            if(q2 == "0") q2 = "1";
            else if(q2 == "1") q2 = "0";
            if(qbar2 == "0") qbar2 = "1";
            else if(qbar2 == "1") qbar2 = "0";
        }

        //set output2
        if(randomWire == 1 || randomWire == 3) out2 = q2;
        else if(randomWire == 2 || randomWire == 4) out2 = qbar2;
        
        if(out1 == "0" && out2 == "0") return "0";
        else if(out1 == "0" && out2 == "1") return "1";
        else if(out1 == "1" && out2 == "0") return "2";
        else if(out1 == "1" && out2 == "1") return "3";
        else return "";
    }

    public void AnswerChecking(string answer)
    {
        Debug.Log(Gate0.number);
        Debug.Log(Gate1.number);
        Debug.Log(Gate2.number);
        Debug.Log(Gate3.number);
        Debug.Log("answer = " + answer);
        if(answer == "0") 
        {
            if(Gate0.number == "0") Gate0.correct = true;
            else if(Gate1.number == "0") Gate1.correct = true;
            else if(Gate2.number == "0") Gate2.correct = true;
            else if(Gate3.number == "0") Gate3.correct = true;  
        }
        else if(answer == "1") 
        {
            if(Gate0.number == "1") Gate0.correct = true;
            else if(Gate1.number == "1") Gate1.correct = true;
            else if(Gate2.number == "1") Gate2.correct = true;
            else if(Gate3.number == "1") Gate3.correct = true;
        }
        else if(answer == "2") 
        {
            if(Gate0.number == "2") Gate0.correct = true;
            else if(Gate1.number == "2") Gate1.correct = true;
            else if(Gate2.number == "2") Gate2.correct = true;
            else if(Gate3.number == "2") Gate3.correct = true;
        }
        else if(answer == "3") 
        {
            if(Gate0.number == "3") Gate0.correct = true;
            else if(Gate1.number == "3") Gate1.correct = true;
            else if(Gate2.number == "3") Gate2.correct = true;
            else if(Gate3.number == "3") Gate3.correct = true;
        }
    }

    public void RandomDoorNumber()
    {
        int random0;
        int random1;
        int random2;
        int random3;
        random0 = Random.Range(0, 4);
        Gate0GateNumber.text = random0.ToString();
        Gate0.number = random0.ToString();
        for(int i = 0; i < DoorNum.Count; i++) 
        {
            if(DoorNum[i] == random0.ToString()) DoorNum.Remove(random0.ToString());
        }
        do
        {
            random1 = Random.Range(0, 4);
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
        do
        {
            random2 = Random.Range(0, 4);
        }
        while(random2 == random0 || random2 == random1);
        for(int i = 0; i < DoorNum.Count; i++) 
        {
            if(DoorNum[i] == random2.ToString()) 
            {
                Gate2GateNumber.text = random2.ToString();
                Gate2.number = random2.ToString();
                DoorNum.Remove(random2.ToString());
            }
        }
        do
        {
            random3 = Random.Range(0, 4);
        }
        while(random3 == random0 || random3 == random1 || random3 == random2);
        for(int i = 0; i < DoorNum.Count; i++) 
        {
            if(DoorNum[i] == random3.ToString()) 
            {
                Gate3GateNumber.text = random3.ToString();
                Gate3.number = random3.ToString();
                DoorNum.Remove(random3.ToString());
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
