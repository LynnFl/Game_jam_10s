using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DestinationTest : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isFinished;

    void start(){
        isFinished = false;
    }
   private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Cat"){
            isFinished = true;
            SceneManager.LoadScene("Level1RollingRock");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
