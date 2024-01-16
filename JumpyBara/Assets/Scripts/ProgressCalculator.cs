using System;
using UnityEngine;

public class ProgressCalculator : MonoBehaviour
{
    public Vector3 startMarker;  
    public Vector3  endMarker;     
    private float totalDistance;
    public float progress;

    void Start()
    {
        startMarker = new Vector3(-6.28f,-3.05f,0);
        endMarker = new Vector3(304.0798f,-3.05222f,0f);
    }

    public void CalculateAndPrintProgress(Transform playerMarker)
    {
        totalDistance = Vector3.Distance(startMarker, endMarker);

        float playerDistance = Vector3.Distance(startMarker, playerMarker.position);

        progress = Mathf.Clamp01(playerDistance / totalDistance) * 100;
    }
}
