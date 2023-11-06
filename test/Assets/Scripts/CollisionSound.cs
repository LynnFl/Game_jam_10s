using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    // Start is called before the
    public AudioClip collideWithGroundSound;

    private AudioSource audioSource; 

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SandGround")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = collideWithGroundSound;
            audioSource.loop = false;
            audioSource.volume = 100f;
            audioSource.Play();
        }
    }
}
