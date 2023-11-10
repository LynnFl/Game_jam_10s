using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public AudioClip MovingSound;
    private AudioSource audioSource;
    void Start()
    {
        animator  = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(StatueCollision.isCollided == true){
            animator.SetBool("isCollided", true);
            PlaySound();
            StatueCollision.isCollided = false;
        }
    }

    public void PlaySound(){
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = MovingSound;
        audioSource.loop = false;
        audioSource.volume = 200f;
        audioSource.Play();
        Invoke("PauseSound", 3);
    
    }

    private void PauseSound(){
        audioSource.Pause();
    }

}
