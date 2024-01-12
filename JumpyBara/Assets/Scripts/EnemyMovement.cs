using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("Flip", 1f, 1f);
    }

    void Update()
    {
        
    }

 
    void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
