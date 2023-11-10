using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public GameObject errorSound;

    public GameObject level2Token;

    public AudioClip windowPopsOutSound;
    public AudioClip winningMusic;
    public AudioClip losingMusic;
    private AudioSource audioSource1;
    private AudioSource audioSource2;

    public ScrollViewTest scrollViewTest_1;
    public ScrollViewTest scrollViewTest_2;
    public ScrollViewTest scrollViewTest_3;

    public static bool isLevel2TokenActive = false;


    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        audioSource1.clip = windowPopsOutSound;
        audioSource1.loop = false;
        audioSource1.volume = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(){
        gameOverUI.SetActive(true);
        audioSource1.Play();
        audioSource2 = GetComponent<AudioSource>();
        audioSource2.clip = losingMusic;
        audioSource2.loop = false;
        audioSource2.volume = 100f;
        audioSource2.Play();
    }

    public void GameWin(){
        
        gameWinUI.SetActive(true);
        audioSource1.Play();
        audioSource2 = GetComponent<AudioSource>();
        audioSource2.clip = winningMusic;
        audioSource2.loop = false;
        audioSource2.volume = 100f;
        audioSource2.Play();

    }

   

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }


    public void LoadScene1(){
        SceneManager.LoadScene("Level1");
    }


    public void GetBacktoLevelSelection(){
        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadLevel2Token(){
        if(isLevel2TokenActive == false){
            errorSound.SetActive(true);
            level2Token.SetActive(true);
        }
    }

    public void LoadScene2(){
        
        if(scrollViewTest_1.GetCurrentImageIndex() == 2 && scrollViewTest_2.GetCurrentImageIndex() == 1 && scrollViewTest_3.GetCurrentImageIndex() == 1){
            level2Token.SetActive(false);
            isLevel2TokenActive = true;
        }

        if(isLevel2TokenActive == true) 
            SceneManager.LoadScene("Level2");
           // Debug.Log("Level 2 is ready");
    }


    
}

