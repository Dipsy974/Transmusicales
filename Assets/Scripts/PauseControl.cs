using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public VictoryManager victoryManager;
    public DefeatManager defeatManager;
    public UIMenu uiMenu;
    public Conductor myCond;
    public GameObject layer;
    public Blur blur;
    public Image sprRenderer;
    public Sprite pauseSprite;
    public Sprite playSprite;
    public GameObject pauseButton;



    void Update()
    {
        if (gameIsPaused && !victoryManager.victory && !defeatManager.defeatDone)
        {
            uiMenu.ShowOptions(layer);
            uiMenu.HideOptions(pauseButton);
            sprRenderer.sprite = playSprite;
            Debug.Log(Screen.height);
        }
        else
        {
            uiMenu.ShowOptions(pauseButton);
            uiMenu.HideOptions(layer);
            sprRenderer.sprite = pauseSprite;
        }
    }

    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            myCond.music.Pause();
            myCond.dspSongTime = (float)AudioSettings.dspTime;
            blur.enabled = true;

        }
        else
        {
            Time.timeScale = 1;
            myCond.music.Play();
            myCond.dspSongTime = (float)AudioSettings.dspTime - myCond.songPosition;
            blur.enabled = false;
        }
    }

}
