using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public UIMenu uiMenu;
    public Conductor myCond;
    public GameObject layer;
    public Blur blur;
    public Image sprRenderer;
    public Sprite pauseSprite;
    public Sprite playSprite;
    public RectTransform buttonTransform;

    void Update()
    {
        if (gameIsPaused)
        {
            uiMenu.ShowOptions(layer);
            sprRenderer.sprite = playSprite;
        }
        else
        {
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

            //buttonTransform.position -= new Vector3(0, 520, 0);

        }
        else
        {
            Time.timeScale = 1;
            myCond.music.Play();
            myCond.dspSongTime = (float)AudioSettings.dspTime - myCond.songPosition;
            blur.enabled = false;

            //buttonTransform.position += new Vector3(0, 520, 0);
        }
    }

}
