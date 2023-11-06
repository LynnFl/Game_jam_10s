using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningAnimationOfSandBlock : MonoBehaviour
{
    public float floatSpeed = 2.0f;
    public float waveSpeed = 1.0f;
    public float waveHeight = 0.5f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float startTime;
    private bool reachedEndPosition = false;

    public float resistance = 0.5f;
    private float closeness;

    void Start()
    {
        endPosition = transform.position;
        startPosition = new Vector3(endPosition.x, endPosition.y - 10.0f, endPosition.z);
        startTime = Time.time;
    }

    void Update()
    {
        // Move the cube up until it reaches the endPosition
        if (!reachedEndPosition)
        {
            float distCovered = (Time.time - startTime) * floatSpeed;
            float journeyFraction = distCovered / Vector3.Distance(startPosition, endPosition);
            transform.position = Vector3.Lerp(startPosition, endPosition, journeyFraction);

            if (transform.position == endPosition)
            {
                reachedEndPosition = true;
                startTime = Time.time; // Reset startTime for the wave movement
            }
        }
        else
        {
            closeness = waveHeight;
            while(closeness > 0.02f){
                float wave = Mathf.Sin((Time.time - startTime) * waveSpeed) * closeness;
                transform.position = new Vector3(endPosition.x, endPosition.y + wave, endPosition.z);
                waveHeight = waveHeight - resistance * Time.deltaTime;
            }
    }
}
}