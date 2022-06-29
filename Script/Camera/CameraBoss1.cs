using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraBoss1 : MonoBehaviour
{
    public float dampTime = 0.15f;
    public Vector3 velocity = Vector2.zero;
    public Transform target;
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;
    Camera mainCamera;
    public float elapsedTime;
    public float duration;
    [SerializeField] GameObject greenBullet;
    [SerializeField] GameObject redBullet;
    public bool back;
    
    void Start()
    {
        back = true;
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {   
        if(playerController.isCameraLocked == true)
        {

        }
        else if(playerController.isCameraLocked == false && greenBullet.activeSelf == false && redBullet.activeSelf == false && back == true)
        {
            elapsedTime += Time.deltaTime;
            if(target && player.activeSelf)    
            {
                Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
                Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.22f,0.18f,point.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
        }
        else if(greenBullet.activeSelf == true)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(greenBullet.transform.position);
            Vector3 delta = greenBullet.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f,0.55f,point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
        else if(redBullet.activeSelf == true)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(redBullet.transform.position);
            Vector3 delta = redBullet.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f,0.55f,point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }

    public void ScreenShake(bool start, float length)
    {
        duration = length;
        if(start == true)
        {
            StartCoroutine(Shaking());
        }
    }

    public IEnumerator Shaking()
    {
        elapsedTime = 0f;
        while(elapsedTime < duration) 
        {
            transform.position = transform.position + Random.insideUnitSphere * 0.01f;
            yield return null;
        }
    }
}
