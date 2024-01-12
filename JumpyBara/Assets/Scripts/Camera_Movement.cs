using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform cel; // Postaæ, za któr¹ ma pod¹¿aæ kamera
    public float offsetPoziomy = 5f; // Offset kamery w osi poziomej

    void Update()
    {
        if (cel != null)
        {
            Podazaj();
        }
    }

    void Podazaj()
    {
        Vector3 nowaPozycja = new Vector3(cel.position.x + offsetPoziomy, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, nowaPozycja, Time.deltaTime * 5); // P³ynne pod¹¿anie kamery
    }
}
