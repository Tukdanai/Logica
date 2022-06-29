using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLoop : MonoBehaviour
{
    private float length;
    private float startPosition;
    private float distance;
    private float temp;
    public GameObject mainCamera;
    public float parallaxEffect;


    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void Update()
    {
        temp = (mainCamera.transform.position.x * (1 - parallaxEffect));
            distance = (mainCamera.transform.position.x * parallaxEffect);
            transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

            if(temp > startPosition + length)
            {
                startPosition += length;
            } 
            else if(temp < startPosition - length)
            {
                startPosition -= length;
            }
    }
}
