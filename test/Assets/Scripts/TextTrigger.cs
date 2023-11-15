using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
public class TextTrigger : MonoBehaviour
{
    public TutorialManager tutorialManager; 

    void OnMouseDown() // This method is called when the collider is clicked
    {
        if(tutorialManager.GetCurrentTextIndex == 0 && TutorialManager.isFinished == false)
        tutorialManager.OnTextClicked();
    }
}