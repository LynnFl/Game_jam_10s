using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FrameMotion : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isStarted = false;

    private float floatSpeed = 2.0f; 
    void start(){
        startPosition = transform.localPosition;
    }
    public void MoveEnabled(){
        isStarted = true;
    }
    void Update()
    {
        if(isStarted == true && transform.localPosition.x < 900){
            transform.localPosition += Vector3.right * Time.deltaTime * floatSpeed * 85;
        }
        
    }
}
