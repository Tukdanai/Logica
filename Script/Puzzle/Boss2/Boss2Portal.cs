using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss2Portal : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject Warp;
    [SerializeField] Animator warpAnimator;
    [SerializeField] AudioSource WarpSound;
    Animator animator;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        Warp.SetActive(false);
        animator.SetBool("Loop", true);
    }

    void Update()
    {
        if(Warp.activeSelf == true) player.canMove = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Teleport());
        }
    }

    public IEnumerator Teleport()
    {
        if(WarpSound.isPlaying == false) WarpSound.Play();
        Warp.SetActive(true);
        warpAnimator.SetBool("Warp",true);
        yield return new WaitForSeconds(2f);
        warpAnimator.SetBool("Warp",false);
        Warp.SetActive(false);
        SceneManager.LoadScene("Chapter3_0");
    }
}
