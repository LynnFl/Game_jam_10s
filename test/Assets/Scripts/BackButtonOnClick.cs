using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnClick()
    {
        Application.LoadLevel("Level2");
    }
}
