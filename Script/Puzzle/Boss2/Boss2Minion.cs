using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Minion : MonoBehaviour
{
    [SerializeField] GameObject Minion;
    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] GameObject MinionBeam;
    [SerializeField] MinionBeam beam;
    [SerializeField] PlayerController player;
    [SerializeField] BooleanBoss boss;
    [SerializeField] SavedManager savedManager;
    Animator animator;
    public bool Correct;
    public bool alive;
    public bool immortal;
    public bool dead;
    [SerializeField] AudioSource MinionGetAttacked;
    [SerializeField] AudioSource MinionSpawnSound;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        MinionBeam.SetActive(false);
        alive = true;
        immortal = false;
        dead = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("ExCarrotSword"))
        {
            if(player.attack == true && Correct == true && immortal == false)
            {
                immortal = true;
                if(MinionGetAttacked.isPlaying == false) MinionGetAttacked.Play();
                StartCoroutine(Dead());
            }
            else if(player.attack == true && Correct == false && immortal == false)
            {
                immortal = true;
                StartCoroutine(Fire());
            }
        }
    }

    public void MinionSpawn()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Fire()
    {
        player.BooleanWrongCount += 1;
        beam.canDamage = true;
        MinionBeam.SetActive(true);
        boss.CloseAllPuzzle();
        savedManager.SaveWrongCount();
        yield return new WaitForSeconds(3f);
        MinionBeam.SetActive(false);
        yield return new WaitForSeconds(1f);
        alive = true;
        boss.minionImmortal = false;
    }

    public void MinionDead()
    {
        StartCoroutine(DeadNoShoot());
    }

    public IEnumerator Dead()
    {
        animator.SetBool("Dead", true);
        boss.CloseAllPuzzle();
        yield return new WaitForSeconds(0.8f);
        sprite.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.05f);
        sprite.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.05f);
        sprite.color = new Color(1f, 1f, 1f, 0.3f);
        yield return new WaitForSeconds(0.05f);
        sprite.color = new Color(1f, 1f, 1f, 0.2f);
        yield return new WaitForSeconds(0.05f);
        sprite.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Dead", false);
        dead = true;
        boss.Shoot();
        Minion.SetActive(false);
    }

    public IEnumerator Spawn()
    {
        animator.SetBool("Spawn", true);
        MinionSpawnSound.Play();
        yield return new WaitForSeconds(2f);
        alive = true;
        animator.SetBool("Spawn", false);
    }

    public IEnumerator DeadNoShoot()
    {
        animator.SetBool("Dead", true);
        boss.CloseAllPuzzle();
        yield return new WaitForSeconds(0.8f);
        sprite.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.05f);
        sprite.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.05f);
        sprite.color = new Color(1f, 1f, 1f, 0.3f);
        yield return new WaitForSeconds(0.05f);
        sprite.color = new Color(1f, 1f, 1f, 0.2f);
        yield return new WaitForSeconds(0.05f);
        sprite.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Dead", false);
        Minion.SetActive(false);
    }
}
