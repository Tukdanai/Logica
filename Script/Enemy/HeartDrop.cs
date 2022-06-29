using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDrop : MonoBehaviour
{
    [SerializeField] GameObject Heart;

    void Start()
    {
        int random = Random.Range(1, 11);
        if(random > 3) Destroy(Heart);
    }
}
