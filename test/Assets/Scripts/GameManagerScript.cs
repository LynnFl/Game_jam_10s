using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public AudioClip windowPopsOutSound;
    public AudioClip winningMusic;
    public AudioClip losingMusic;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
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
}
