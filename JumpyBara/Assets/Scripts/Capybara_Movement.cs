using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Capybara_Movement : MonoBehaviour
{
    public float predkoscSkoku = 15f;
    public Collider2D colliderStop;
    public LayerMask warstwaPodloza;

    private bool czyMoznaSkakac;

    void Update()
    {
        RuchGracza();

        if (czyMoznaSkakac && Input.GetButtonDown("Jump"))
        {
            Skok();
        }
    }

    void FixedUpdate()
    {
        JestNaPodlozu();
    }

    void JestNaPodlozu()
    {
        czyMoznaSkakac = Physics2D.Raycast(colliderStop.bounds.center, Vector2.down, colliderStop.bounds.extents.y + 0.1f, warstwaPodloza);
    }

    void RuchGracza()
    {
        // Automatyczne poruszanie siê postaci w prawo
        float predkoscPostaci = 5f;
        transform.Translate(new Vector2(predkoscPostaci * Time.deltaTime, 0));
    }

    void Skok()
    {
        if (czyMoznaSkakac)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, predkoscSkoku);
        }
    }
}
