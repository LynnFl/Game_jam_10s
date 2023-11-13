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


   public bool isBlockedByRock = false;
   public  bool isFinished = false;
    
    public GameManagerScript gameManager;

    private Transform currentWaypoint;
    // Start is called before the first frame update

    private float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
        //anim = animator;
        motionBegin = false;
        speed = 1.3f;
        currentWaypoint = null;
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
         isFinished = false;
         isCollided = false;
       // animator.SetBool("Die", false);
        SetCatAnimState(CatAnimState.Sitting);


    }

    // Update is called once per frame
    void Update()
    {
        if(motionBegin == true && isCollided == false && DestinationTest.isFinished == false && isBlockedByRock == false){
                
                
                if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold){
                        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                       // transform.LookAt(currentWaypoint);
                        CanRotate=true;
                       
                       
                }
                else transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

                 TurnToTarget(currentWaypoint);
        }

        
    }
    //转向速度
    private float RotateSpeed=0.1f;
    //是否可以转向
    private bool CanRotate=false;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    private void TurnToTarget(Transform target)
    {
      if(CanRotate)
      {
         //获取方向
         Vector3 dir = target.position - transform.position;
         //计算方向
         Quaternion quaDir = Quaternion.LookRotation(dir, Vector3.up);
         //缓慢转动到目标点
         transform.rotation = Quaternion.Lerp(transform.rotation, quaDir, RotateSpeed);
         //判断是否已经转向目标点方向
         if (transform.rotation == quaDir)
         {
            CanRotate = false;
         }
      }

    }
    private void OnCollisionEnter(Collision other) {
      if(other.gameObject.tag == "Rock"){
         isCollided = true;
         //animator.SetBool("Walking", false);
         //animator.SetBool("Die", true);
         SetCatAnimState(CatAnimState.Die);
      }
      if(other.gameObject.tag == "Destination" && isFinished == false){
         isFinished = true;
         gameManager.GameWin();
        // animator.SetBool("Walking", false);
         SetCatAnimState(CatAnimState.Sitting);
      }

      
   }

   private void OnTriggerEnter(Collider other) {
      if(other.gameObject.tag == "FallIntoWater"){
         isCollided = true;
         gameManager.GameOver();
        // animator.SetBool("Walking", false);
        // animator.SetBool("Die", true);
         SetCatAnimState(CatAnimState.Die);
      }
   }

 


   public void GetStarted(){
      motionBegin = true;
      //animator.SetBool("Walking", true);
      SetCatAnimState(CatAnimState.Walking);
   }
   public void SetCatSit(){
      //animator.SetBool("Walking", false);
      SetCatAnimState(CatAnimState.Sitting);
   }


   public enum CatAnimState{
      Walking,
      Sitting,
      Die,
   }

   /// <summary>
   /// 猫动画控制
   /// </summary>
   /// <param name="catAnimState"></param>
   public void SetCatAnimState(CatAnimState catAnimState)
   {

      switch (catAnimState)
      {
         case CatAnimState.Walking:
           animator.SetBool("Walking", true);
            animator.SetBool("Die", false);
            break;
         case CatAnimState.Sitting:
          animator.SetBool("Walking", false);
            animator.SetBool("Die", false);
            break;
         case CatAnimState.Die:
          animator.SetBool("Walking", false);
            animator.SetBool("Die", true);
            break;
       

      }
   }
}
