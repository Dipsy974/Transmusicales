using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    public Conductor myCond;
    public UIMenu uiMenu;
    public GameObject gameUI;
    public GameObject victoryUI;
    public PauseControl pauseControl;
    public bool victory = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myCond.songPositionInBeats >= myCond.selectedSong.lastBeat && !victory)
        {
            victory = true;
            uiMenu.HideOptions(gameUI);
            uiMenu.ShowOptions(victoryUI);
            pauseControl.PauseGame();
        }
        
    }
}
