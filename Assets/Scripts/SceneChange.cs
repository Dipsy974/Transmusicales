using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public PauseControl pauseControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneSelection(string nextScene)
    {

        SceneManager.LoadScene(nextScene);
    }

    public void WebPage(string webpage)
    {

        Application.OpenURL(webpage);
    }

    public void Reload()
    {
        pauseControl.PauseGame();
    }

}
