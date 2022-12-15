using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatManager : MonoBehaviour
{
    public float globalScore;
    public float currentScore; 
    public float scorePerMiss;
    public float scorePerHit;
    public GameObject blurImage;
    public UIMenu uiMenu;
    public GameObject gameUI;
    public GameObject defeatUI;
    public PauseControl pauseControl;

    private bool defeatDone = false;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = globalScore;
        blurImage.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (checkDefeat() && !defeatDone)
        {
            defeatDone = true;
            uiMenu.HideOptions(gameUI);
            uiMenu.ShowOptions(defeatUI);
            pauseControl.PauseGame();
        }

        if(currentScore < 20)
        {
            blurImage.SetActive(true);
        }
    }

    public void IncreaseScore()
    {
        currentScore += scorePerHit;
        if (currentScore > globalScore)
        {
            currentScore = globalScore; 
        }

        Debug.Log(currentScore);
    }

    public void IncreaseProgressScore()
    {
        currentScore += scorePerHit * Time.deltaTime;
        if (currentScore > globalScore)
        {
            currentScore = globalScore;
        }

        Debug.Log(currentScore);
    }

    public void DecreaseScore()
    {
        currentScore -= scorePerMiss;
        Debug.Log(currentScore); 
    }

    public bool checkDefeat()
    {
        if(currentScore <= 0)
        {
            return true;
        }

        return false; 
    }
}
