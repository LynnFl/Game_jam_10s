using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XOnClick : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameObject;
    public GameObject errorSound;


    public void CloseOnClick()
    {
        gameObject.SetActive(false);
        errorSound.SetActive(false);
    }
}
