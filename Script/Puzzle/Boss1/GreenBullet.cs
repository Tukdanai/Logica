using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Shield;
    [SerializeField] Cannon cannon;
    Vector3 originalPosition;
    Animator animator;
    Animator shieldAnimator;
    [SerializeField] CameraBoss1 Boss1Camera;
    [SerializeField] LogicBoss boss;
    
    void Start()
    {
        originalPosition = transform.position;
        animator = this.GetComponent<Animator>();
        shieldAnimator = Shield.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Shield"))
        {
            StartCoroutine(Boom());
        }
    }

    public IEnumerator Boom()
    {
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        boss.ShieldBreak.Play();
        Boss1Camera.back = false;
        animator.SetBool("Hit", true);
        shieldAnimator.SetBool("Break", true);
        yield return new WaitForSeconds(0.5f);
        shieldAnimator.SetBool("Break", false);
        animator.SetBool("Hit", false);
        transform.position = originalPosition;
        Shield.SetActive(false);
        cannon.greenAnimator.SetBool("Shoot", false);
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        cannon.green.SetActive(false);
        cannon.noPower.SetActive(true);
        cannon.greenAnswerCheck = true;
        Bullet.SetActive(false);
    }
}
