using UnityEngine;
using System.Collections;

public class ScaleUpAnimation : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(0.029334f, 0.030602f, 0.071923f); // The original scale of the square
    public float duration = 1.0f; // Duration of the scale animation

    public AudioClip loadingSound;
    private AudioSource audioSource;
        

    public static bool beginLoadingDots;

    void Start()
    {
        beginLoadingDots = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = loadingSound;
        audioSource.loop = false;
        audioSource.volume = 0.2f;

    }

    public void BeginScaling()
    {
        // Start with the square scaled down to a point
        transform.localScale = Vector3.zero;
        
        // Begin the scale up animation
        StartCoroutine(ScaleUp());
        beginLoadingDots = true;
        
    }

    private IEnumerator ScaleUp()
    {
        float currentTime = 0f;
        Vector3 startScale = transform.localScale;

        yield return new WaitForSeconds(3.3f);

        audioSource.Play();
        
        while (currentTime < duration)
        {
            // Calculate the current time of the animation relative to its duration
            currentTime += Time.deltaTime;
            // Calculate the interpolated scale value
            float t = currentTime / duration;
            // Update the square's scale
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            // Wait until next frame before continuing the loop
            yield return null;
        }

        // Ensure the target scale is set precisely at the end of the animation
        transform.localScale = targetScale;
        
            
    }
}