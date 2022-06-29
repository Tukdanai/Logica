using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using TMPro;

public class ResultPage : MonoBehaviour
{
    private string persistentPath1 = "";
    private string persistentPath2 = "";
    private string persistentPath3 = "";
    public float playedTime;
    [SerializeField] protected TextMeshProUGUI PlayedTime;
    private string FormattedTime;
    private int seconds;
    private int minutes;
    private int hours;
    public int LogicWrongCount;
    public int BooleanWrongCount;
    public int JKWrongCount;
    [SerializeField] GameObject logicStar0;
    [SerializeField] GameObject logicStar1;
    [SerializeField] GameObject logicStar2;
    [SerializeField] GameObject logicStar3;
    [SerializeField] GameObject booleanStar0;
    [SerializeField] GameObject booleanStar1;
    [SerializeField] GameObject booleanStar2;
    [SerializeField] GameObject booleanStar3;
    [SerializeField] GameObject jkStar0;
    [SerializeField] GameObject jkStar1;
    [SerializeField] GameObject jkStar2;
    [SerializeField] GameObject jkStar3;
    private bool play;
    [SerializeField] AudioSource starDrop;

    void Start()
    {
        play = true;
        logicStar0.SetActive(true);
        logicStar1.SetActive(false);
        logicStar2.SetActive(false);
        logicStar3.SetActive(false);
        booleanStar0.SetActive(true);
        booleanStar1.SetActive(false);
        booleanStar2.SetActive(false);
        booleanStar3.SetActive(false);
        jkStar0.SetActive(true);
        jkStar1.SetActive(false);
        jkStar3.SetActive(false);
        jkStar2.SetActive(false);
    
        persistentPath1 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData1.json";
        persistentPath2 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData2.json";
        persistentPath3 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData3.json";
        LoadResult();
    }

    void Update()
    {
        if(play == true) StartCoroutine(ShowStar());
    }

    public IEnumerator ShowStar()
    {
        play = false;

        yield return new WaitForSeconds(2f);

        if(LogicWrongCount <= 0 && logicStar3.activeSelf == false) 
        {
            starDrop.Play();
            logicStar1.SetActive(true);
            yield return new WaitForSeconds(1f);
            starDrop.Play();
            logicStar2.SetActive(true);
            yield return new WaitForSeconds(1f);
            starDrop.Play();
            logicStar3.SetActive(true);
        }
        else if((LogicWrongCount >= 1 && LogicWrongCount < 3) && logicStar2.activeSelf == false)
        {
            starDrop.Play();
            logicStar1.SetActive(true);
            yield return new WaitForSeconds(1f);
            starDrop.Play();
            logicStar2.SetActive(true);
        }
        else if((LogicWrongCount >= 3 && LogicWrongCount < 5) && logicStar1.activeSelf == false)
        {
            starDrop.Play();
            logicStar1.SetActive(true);
        }

        yield return new WaitForSeconds(1f);

        if(BooleanWrongCount <= 0 && booleanStar3.activeSelf == false)
        {
            starDrop.Play();
            booleanStar1.SetActive(true);
            yield return new WaitForSeconds(1f);
            starDrop.Play();
            booleanStar2.SetActive(true);
            yield return new WaitForSeconds(1f);
            starDrop.Play();
            booleanStar3.SetActive(true);
        }
        else if((BooleanWrongCount >= 1 && BooleanWrongCount < 3) && booleanStar2.activeSelf == false)
        {
            starDrop.Play();
            booleanStar1.SetActive(true);
            yield return new WaitForSeconds(1f);
            starDrop.Play();
            booleanStar2.SetActive(true);
        }
        else if((BooleanWrongCount >= 3 && BooleanWrongCount < 5) && booleanStar1.activeSelf == false)
        {
            starDrop.Play();
            booleanStar1.SetActive(true);
        }

        yield return new WaitForSeconds(1f);

        if(JKWrongCount <= 0 && jkStar3.activeSelf == false)
        {
            starDrop.Play();
            jkStar1.SetActive(true);
            yield return new WaitForSeconds(1f);
            starDrop.Play();
            jkStar2.SetActive(true);
            yield return new WaitForSeconds(1f);
            starDrop.Play();
            jkStar3.SetActive(true);
        }
        else if((JKWrongCount >= 1 && JKWrongCount < 3) && jkStar2.activeSelf == false)
        {
            starDrop.Play();
            jkStar1.SetActive(true);
            yield return new WaitForSeconds(1f);
            starDrop.Play();
            jkStar2.SetActive(true);
        }
        else if((JKWrongCount >= 3 && JKWrongCount < 5) && jkStar1.activeSelf == false)
        {
            starDrop.Play();
            jkStar1.SetActive(true);
        }
    }

    public void LoadResult()
    {
        int currentSlot = 0;

        if(File.Exists(persistentPath1))
        {
            string json1 = "";
            StreamReader reader1 = new StreamReader(persistentPath1);
            json1 = reader1.ReadToEnd();
            reader1.Close();
            SavedData savedData1 = JsonUtility.FromJson<SavedData>(json1);
            if(savedData1.isCurrentPlayingSlot == true) currentSlot = 1;
        }

        if(File.Exists(persistentPath2))
        {
            string json2 = "";
            StreamReader reader2 = new StreamReader(persistentPath2);
            json2 = reader2.ReadToEnd();
            reader2.Close();
            SavedData savedData2 = JsonUtility.FromJson<SavedData>(json2);
            if(savedData2.isCurrentPlayingSlot == true) currentSlot = 2;
        }

        if(File.Exists(persistentPath3))
        {
            string json3 = "";
            StreamReader reader3 = new StreamReader(persistentPath3);
            json3 = reader3.ReadToEnd();
            reader3.Close();
            SavedData savedData3 = JsonUtility.FromJson<SavedData>(json3);
            if(savedData3.isCurrentPlayingSlot == true) currentSlot = 3;
        }
        
        string json = "";

        if(currentSlot == 1)
        {
            StreamReader reader = new StreamReader(persistentPath1);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(currentSlot == 2)
        {
            StreamReader reader = new StreamReader(persistentPath2);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(currentSlot == 3)
        {
            StreamReader reader = new StreamReader(persistentPath3);
            json = reader.ReadToEnd();
            reader.Close();
        }
        
        SavedData savedData = JsonUtility.FromJson<SavedData>(json);

        //Load player Played Time.
        playedTime = savedData.playedTime;

        //Load player wrong answer count in Logic Gate Boss
        LogicWrongCount = savedData.wrongAnswerInLogicBoss;

        //Load player wrong answer count in Boolean Expression Boss
        BooleanWrongCount = savedData.wrongAnswerInBooleanBoss;

        //Load player wrong answer count in JK Flip-Flop
        JKWrongCount = savedData.wrongAnswerInJKBoss;

        seconds = (int)(savedData.playedTime % 60);
        minutes = (int)(savedData.playedTime / 60) % 60;
        hours = (int)(savedData.playedTime / 3600) % 24;

        FormattedTime = string.Format("{0:00} : {1:00} : {2:00}", hours, minutes, seconds);
        PlayedTime.text = FormattedTime;
    }
}
