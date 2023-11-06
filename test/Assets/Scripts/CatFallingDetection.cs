using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatFallingDetection : MonoBehaviour
{
    // Start is called before the first frame update

   private void OnTriggerEnter(Collider other) {
      if(other.gameObject.tag == "Cat"){
        SceneManager.LoadScene("Level1RollingRock");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

      }
 }

