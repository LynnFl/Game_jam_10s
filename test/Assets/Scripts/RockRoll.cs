using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class RockRoll : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isVideoStarted = false;

    private float timer = 0;

    private float rollingSpeed;
    public GameObject timeline;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private bool reachedEndPosition = false;

    public AudioClip rollingSound;
    private AudioSource audioSource;
    private int playTime;
    
    public float beginningTime;
    public float endingTime;

    RangeSlider rangeSlider;

    void Start()
    {
        isVideoStarted = false;
        reachedEndPosition = false;

        rangeSlider = timeline.GetComponent<RangeSlider>();
        rangeSlider.LowValue = beginningTime;
        rangeSlider.HighValue = endingTime;

        rollingSpeed = 5f;

        
       
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = rollingSound;
        audioSource.loop = true;
        audioSource.volume = 100f;
        playTime = 1;
    }
    // Update is called once per frame


    public void ChangeState(){
        isVideoStarted = true;
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z - 7.2f);
    }

    void Update()
    {
        if(isVideoStarted == false){
            rangeSlider = timeline.GetComponent<RangeSlider>();
            timer = rangeSlider.LowValue;
        }
        else if(isVideoStarted == true && reachedEndPosition == false){
           
            timer = timer - Time.deltaTime;
            if(timer <= 0){
                
                if(playTime == 1){
                audioSource.Play();
                playTime = 0;
                }

                rangeSlider = timeline.GetComponent<RangeSlider>();
                rollingSpeed = (10/ (rangeSlider.HighValue - rangeSlider.LowValue));

                if(transform.position.z < endPosition.z + 0.05f && transform.position.z > endPosition.z - 0.05f){
                    reachedEndPosition = true;
                }
                transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * rollingSpeed);
                transform.Rotate(Vector3.forward, 360 * Time.deltaTime * rollingSpeed);
            }
        }
        else if(reachedEndPosition == true) {
            audioSource.Stop();
        }
        
    }
}
