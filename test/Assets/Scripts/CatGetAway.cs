using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGetAway : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public AudioClip catSound;
    private AudioSource audioSource;

     void Start(){
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = catSound;
        audioSource.loop = false;
        audioSource.volume = 100f;
     }

     public void GetCatAway(){
            animator.SetBool("GetAway", true);
     }

     public void CatSound(){
            audioSource.Play();
     }
}
