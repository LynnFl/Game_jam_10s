using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour
{
    public Button Level1Button;
    public Button Level2Button;
    public Button BackBtn;
    // Start is called before the first frame update
    void Start()
    {
        InitComp();
    }


    private void InitComp()
    {
        Level1Button.onClick.AddListener(()=>
        {
       // SceneLoadManager.instance.LoadScene("Level1");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        });

        

          Level2Button.onClick.AddListener(()=>
        {
        SceneLoadManager.instance.LoadScene("Level2");
        });

        
          BackBtn.onClick.AddListener(()=>
        {
        SceneLoadManager.instance.LoadScene("MainMenu");
        });

       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
