using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGetAway1 : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float speed = 0.3f;
    private float delay = 1.5f;
    private float delay_keyboard;

    public AudioClip keyboardSound;
    private AudioSource audioSource;
    private int playTime = 1;

    private bool beginCatMovement = false;

    public SceneLoader sceneLoader;

    public void BeginCatMovement(){
        beginCatMovement = true;
    }

    void Start(){
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x + 3f, startPosition.y, startPosition.z + 3f);
        beginCatMovement = false;
         delay = 1.9f;
        playTime = 1;

    }
        
    void Update()
    {
        if(beginCatMovement == false ){
            delay = 1.9f;

        }
        else if(beginCatMovement == true ){
                    if(delay <= 0.6f && playTime == 1){
                        audioSource = GetComponent<AudioSource>();
                        audioSource.clip = keyboardSound;
                        audioSource.loop = false;
                        audioSource.volume = 100f;
                        audioSource.Play();
                        playTime= 0;
                    }
                    if(delay <= 0f){
                   

                        if(Vector3.Distance(transform.position, endPosition) < 0.1f){
                            transform.position = endPosition;
                            beginCatMovement = false;
                        }
                    
                        transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * speed);

                        if(delay < -5f){
                            sceneLoader.LoadSceneWithFade();
                        }
                    }
                    delay = delay - Time.deltaTime;

            }

        
    }   
}        
