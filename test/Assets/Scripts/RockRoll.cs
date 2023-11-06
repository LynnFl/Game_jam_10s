using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class RockRoll : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isRolling;
    private float timer = 0;

    private float rollingSpeed;
    public GameObject timeline;

    RangeSlider rangeSlider;

    void Start()
    {
        isRolling = false;
        rangeSlider = timeline.GetComponent<RangeSlider>();
        rangeSlider.LowValue = 0.3f;
        rangeSlider.HighValue = 0.7f;
        rollingSpeed = 5f;
    }
    // Update is called once per frame
    public void Rolling()
    {
            rangeSlider = timeline.GetComponent<RangeSlider>();
            rollingSpeed = (1/ (rangeSlider.HighValue - rangeSlider.LowValue)) * 5;
            transform.position += Vector3.back * Time.deltaTime * rollingSpeed;
            transform.Rotate(Vector3.forward, 360 * Time.deltaTime * rollingSpeed/5);
       
    }

    public void ChangeState(){
        isRolling = true;
    }


    void Update()
    {
        if(isRolling == false){
            rangeSlider = timeline.GetComponent<RangeSlider>();
            timer = rangeSlider.LowValue * 5;
        }
        else if(isRolling == true){
            timer = timer - Time.deltaTime;
            if(timer <= 0){
                Rolling();
            }
        }
        
    }
}
