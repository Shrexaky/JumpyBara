using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeScript : MonoBehaviour
{
    public float levitationHeight = 0.1f;
    public float levitationSpeed = 3f;
    private float initialY;

    void Start()
    {
        initialY = transform.position.y;
    }
    
    private void Update()
    {
        Levitate();
    }

    private void Levitate()
    {
        float newY = initialY + Mathf.Sin(Time.time * levitationSpeed) * levitationHeight;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
