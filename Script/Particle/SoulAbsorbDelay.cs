using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulAbsorbDelay : MonoBehaviour
{
    [SerializeField] PlayerController player;
    public bool start;
    [SerializeField] AudioSource MonsterDeath;
    public bool playSound;

    void Start()
    {
        playSound = true;
    }

    void Update()
    {
        if(start == true)
        {
            if(MonsterDeath.isPlaying == false && playSound == true) MonsterDeath.Play();
            playSound = false;
            transform.position = new Vector3(transform.position.x,transform.position.y,0);
            StartCoroutine(StartAbsorbSoul());
        }
    }

    public IEnumerator StartAbsorbSoul()
    {
        yield return new WaitForSeconds(2f);
        player.absorbMonsterSoul.SetActive(true);
        yield return new WaitForSeconds(3f);
        player.absorbMonsterSoul.SetActive(false);
        start = false;
    }
}
