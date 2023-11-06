using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isCollided;

    void Start()
    {
        isCollided = false;
    }
   private void OnCollisionEnter(Collision other) {
      if(other.gameObject.tag == "Rock")
         isCollided = true;
   }
}
