using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class BridgeCircling : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isCircling;
    private float timer = 0;

    private float circleSpeed;
    public GameObject timeline;

    RangeSlider rangeSlider;

    void Start()
    {
        isCircling = false;
        rangeSlider = timeline.GetComponent<RangeSlider>();
        rangeSlider.LowValue = 0.3f;
        rangeSlider.HighValue = 0.7f;
        circleSpeed = 5f;
    }
    // Update is called once per frame
    public void Circling()
    {
            rangeSlider = timeline.GetComponent<RangeSlider>();
            circleSpeed = (1/ (rangeSlider.HighValue - rangeSlider.LowValue)) ;
            transform.Rotate(Vector3.up, 360 * Time.deltaTime * circleSpeed/50);
       
    }

    public void ChangeStateOfBridge(){
        isCircling = true;
    }


    void Update()
    {
        if(isCircling == false){
            rangeSlider = timeline.GetComponent<RangeSlider>();
            timer = rangeSlider.LowValue * 5;
        }
        else if(isCircling == true){
            timer = timer - Time.deltaTime;
            if(timer <= 0){
                Circling();
            }
        }
        
    }
}
