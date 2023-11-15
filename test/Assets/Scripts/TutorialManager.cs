using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialManager : MonoBehaviour
{

    public static bool hasRun = false;
    public static bool isFinished = false;
   public GameObject textParent; // Parent GameObject containing Text elements as children
    public float initialFadeInDelay = 2.0f; // Delay before the first text fades in
    public float lastTextDisplayDuration = 4.0f; // Duration before the last text fades out
    private CanvasGroup[] textGroups; // Array for CanvasGroup components of the Text elements
    private int currentTextIndex = 0; // Index of the current text in the sequence
    private bool isFading = false; // To control the fading process
    
    void Start()
    {
        if(hasRun == false) {
            isFinished = false;
            InitializeTextGroups();
            currentTextIndex = 0;
            StartCoroutine(FadeInFirstText());
            hasRun = true;
        }
        else {
            textParent.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }


    public int GetCurrentTextIndex => currentTextIndex;
    private void InitializeTextGroups()
    {
        // Create an array of CanvasGroups from the children of textParent
        textGroups = new CanvasGroup[textParent.transform.childCount];
        for (int i = 0; i < textGroups.Length; i++)
        {
            var textObj = textParent.transform.GetChild(i);
            var canvasGroup = textObj.GetComponent<CanvasGroup>() ?? textObj.gameObject.AddComponent<CanvasGroup>();
            canvasGroup.alpha = 0; // Start with all text fully transparent
            textGroups[i] = canvasGroup;
        }
    }

    IEnumerator FadeInFirstText()
    {
        yield return new WaitForSeconds(initialFadeInDelay);
        StartCoroutine(FadeCanvasGroup(textGroups[currentTextIndex], 0f, 1f)); // Fade in the first text
    }

    public void OnTextClicked()
    {
        if (isFading) return; // If a fade is already in progress, do nothing
        
        if (currentTextIndex < textGroups.Length-1)
        {
            StartCoroutine(FadeCanvasGroup(textGroups[currentTextIndex], 1f, 0f));
            currentTextIndex++;
            // Fade in the next text
            StartCoroutine(FadeCanvasGroup(textGroups[currentTextIndex], 0f, 1f));
            if(currentTextIndex == 1) {
                StartCoroutine(FadeOutText(textGroups[currentTextIndex]));
                currentTextIndex++;
                StartCoroutine(SpecialAppear(textGroups[currentTextIndex]));
                }
            }
            if(currentTextIndex == 3) {
                StartCoroutine(FadeOutText(textGroups[currentTextIndex]));
                currentTextIndex++;
                StartCoroutine(SpecialDisappear(textGroups[currentTextIndex]));
                isFinished = true;

                }

        }
        
        

    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration = 0.6f)
    {
        isFading = true;
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = endAlpha;
        isFading = false;

        // Automatically fade out the last text after it has been displayed for some time
        if (currentTextIndex >= textGroups.Length)
        {
            yield return new WaitForSeconds(lastTextDisplayDuration);
            StartCoroutine(FadeCanvasGroup(canvasGroup, 1f, 0f, duration));
        }
    }

    IEnumerator FadeOutText(CanvasGroup canvasGroup)
    {
        yield return new WaitForSeconds(lastTextDisplayDuration);
        StartCoroutine(FadeCanvasGroup(canvasGroup, 1f, 0f, 0.6f)); // Fade out the last text
    }

    IEnumerator SpecialAppear(CanvasGroup canvasGroup){
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeCanvasGroup(canvasGroup, 0f, 1f, 0.6f));
    }

    IEnumerator SpecialDisappear(CanvasGroup canvasGroup){
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeCanvasGroup(canvasGroup, 0f, 1f, 0.6f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeCanvasGroup(canvasGroup, 1f, 0f, 0.6f));
    }

}


