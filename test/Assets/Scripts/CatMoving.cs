using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatMoving : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;

    

    [SerializeField] private float distanceThreshold = 0.5f;

    
    public  bool isCollided = false;
    public static bool motionBegin = false;

    public Animator animator;
    public static Animator anim;


   public bool isBlockedByRock = false;
   public  bool isFinished = false;
    
    public GameManagerScript gameManager;

    private Transform currentWaypoint;
    // Start is called before the first frame update

    private float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
        anim = animator;
        motionBegin = false;
        speed = 1.3f;
        currentWaypoint = null;
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
         isFinished = false;
         isCollided = false;
        animator.SetBool("Die", false);


    }

    // Update is called once per frame
    void Update()
    {
        if(motionBegin == true && isCollided == false && DestinationTest.isFinished == false && isBlockedByRock == false){
                
                
                if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold){
                        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                        transform.LookAt(currentWaypoint);
                       
                }
                else transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

                
        }
    }

    private void OnCollisionEnter(Collision other) {
      if(other.gameObject.tag == "Rock"){
         isCollided = true;
         animator.SetBool("Walking", false);
         animator.SetBool("Die", true);
      }
      if(other.gameObject.tag == "Destination" && isFinished == false){
         isFinished = true;
         gameManager.GameWin();
         animator.SetBool("Walking", false);
         
      }

      
   }

   private void OnTriggerEnter(Collider other) {
      if(other.gameObject.tag == "FallIntoWater"){
         isCollided = true;
         gameManager.GameOver();
         animator.SetBool("Walking", false);
         animator.SetBool("Die", true);
      }
   }

 


   public void GetStarted(){
      motionBegin = true;
      animator.SetBool("Walking", true);
   }
   public void SetCatSit(){
      anim.SetBool("Walking", false);
   }
}
