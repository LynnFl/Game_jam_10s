using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
public class UIElementClickHandler : MonoBehaviour, IPointerClickHandler
{
    public TutorialManager tutorialManager;
    private int triggerIndex ;
    private int current;

    public void Start()
    {
        triggerIndex = 0;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
      if(gameObject.tag == "2")triggerIndex = 2;
      current = tutorialManager.GetCurrentTextIndex;
       
       if(triggerIndex == current)
        tutorialManager.OnTextClicked();
    }
}
