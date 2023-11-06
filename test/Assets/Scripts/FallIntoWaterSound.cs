using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallIntoWaterSound : MonoBehaviour
{
    public AudioClip fallingSound;
    private AudioSource audioSource;// Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other) {
        if(BeginningAnimation.isReadyForPlayer == true){
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = fallingSound;
            audioSource.loop = false;
            audioSource.volume = 100f;
            if(other.gameObject.tag == "Moveable"){
                audioSource.Play();
            }
        }
            
    }
}
