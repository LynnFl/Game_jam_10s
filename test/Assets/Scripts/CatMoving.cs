using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatMoving : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;

    

    [SerializeField] private float distanceThreshold = 0.1f;

    
    private bool isCollided = false;
    public static bool motionBegin = false;
    
    
    private Transform currentWaypoint;
    // Start is called before the first frame update

    private float speed;
    void Start()
    {
        motionBegin = false;
        speed = 1.3f;
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);


    }

    // Update is called once per frame
    void Update()
    {
        if(motionBegin == true && isCollided == false && DestinationTest.isFinished == false){
                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
                if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold){
                        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                }
        }
        
    }

    private void OnCollisionEnter(Collision other) {
      if(other.gameObject.tag == "Rock"){
         isCollided = true;
         
      }
   }

   public void GetStarted(){
      motionBegin = true;
   }
}
