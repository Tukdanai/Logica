using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDestroy : MonoBehaviour
{
    public void OnParticleCollision(GameObject other) 
    {
        Destroy(other);
    }
}
