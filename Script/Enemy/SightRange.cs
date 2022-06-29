using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SightRange : MonoBehaviour
{
    public LayerMask targetLayer;

    public Vector2 size;

    public Color gizmoColor = Color.green;
    public bool showGizmos = true;

    public bool PlayerFounded { get; internal set; }

    void Update()
    {
        var collider = Physics2D.OverlapBox(transform.position, size, 0, targetLayer);
        PlayerFounded = collider != null;
    }

    private void OnDrawGizmos() 
    {
        if(showGizmos == true)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(transform.position, size);
        }
    }
}
