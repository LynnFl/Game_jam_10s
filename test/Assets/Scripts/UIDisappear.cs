using UnityEngine;
using System.Collections; // Required for coroutines

public class UIDisappear : MonoBehaviour
{
    public CanvasGroup uiCanvasGroup; // Assign the CanvasGroup of the UI element you want to disappear
    public float fadeDuration = 1.0f; // Time in seconds over which the fade will occur

    // Call this method when the button is clicked
    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        // While the canvas is still visible, reduce its alpha value over time
        yield return new WaitForSeconds(3f);
        while (uiCanvasGroup.alpha > 0)
        {
            uiCanvasGroup.alpha -= Time.deltaTime / fadeDuration;
            yield return null; // Wait for the next frame
        }

        // Optional: Deactivate the UI GameObject after fading out
        uiCanvasGroup.gameObject.SetActive(false);
    }
}
