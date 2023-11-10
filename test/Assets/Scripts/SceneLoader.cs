using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public Animator fadeAnimator; // Drag your Panel's Animator here
    public string sceneToLoad; // Assign the name of the scene you want to load

    public void LoadSceneWithFade()
    {
        StartCoroutine(BeginLoadSceneWithFade());
    }

    private IEnumerator BeginLoadSceneWithFade()
    {
        // Start the fade-in animation
        fadeAnimator.SetTrigger("FadeIn");

        // Wait for the animation to finish, assuming it's 2 seconds long
        yield return new WaitForSeconds(1f);

        // Load the next scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
