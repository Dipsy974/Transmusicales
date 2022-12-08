using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatManager : MonoBehaviour
{
    public float globalScore;
    public float currentScore; 
    public float scorePerMiss;
    public float scorePerHit;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = globalScore; 
    }

    // Update is called once per frame
    void Update()
    {
        if (checkDefeat())
        {
            Debug.Log("Perdu"); 
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
