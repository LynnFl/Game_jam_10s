using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        instance=this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
