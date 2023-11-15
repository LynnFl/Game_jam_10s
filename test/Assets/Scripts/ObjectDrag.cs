using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset;
    public AudioClip clip;
    private AudioSource audioSource;
    


    private void ifStart(){
            OnMouseDown();
            OnMouseDrag();
    }
    private void OnMouseDown()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.loop = false;
        audioSource.volume = 100f;
        audioSource.Play();
        offset = transform.position - BuildingSystem.GetMouseWorldPosition();
        

    }


    private void OnMouseDrag()
    {
        Vector3 pos = BuildingSystem.GetMouseWorldPosition() + offset;
        if(BeginningAnimation.isReadyForPlayer == true && RockRoll.isVideoStarted == false){
            transform.position = BuildingSystem.current.SnapCoordinateToGrid(pos);
        }
    }

  
}
