using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public UIMenu uiMenu;
    public Conductor myCond;
    public GameObject layer;
    public Blur blur;
    void Update()
    {

    }

    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            myCond.music.Pause();
            myCond.dspSongTime = (float)AudioSettings.dspTime;
            uiMenu.ShowOptions(layer);
            blur.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            myCond.music.Play();
            myCond.dspSongTime = (float)AudioSettings.dspTime - myCond.songPosition;
            uiMenu.HideOptions(layer);
            blur.enabled = false;
        }
    }

}
