using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraChapter3 : MonoBehaviour
{
    public float dampTime = 0.15f;
    public Vector3 velocity = Vector2.zero;
    public Transform target;
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;
    Camera mainCamera;
    public float elapsedTime;
    public float duration;
    
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {   
        if(playerController.isCameraLocked == true)
        {

        }
        else if(playerController.isCameraLocked == false)
        {
            elapsedTime += Time.deltaTime;
            if(target && player.activeSelf)    
            {
                Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
                Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.4f,0.25f,point.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
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
