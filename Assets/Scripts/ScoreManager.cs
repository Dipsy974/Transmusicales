using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float minPoints, midPoints, maxPoints;
    public float midRange, maxRange;
    public float totalPoints = 0f;
    public float pointsPerSecondCorridor = 20f;
    public CheckRythm myCheckRythm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(totalPoints<= 0f)
        {
            totalPoints = 0f;
        }

    }

    public void AccuracyPoints(float currentPosition, float notePosition)
    {
        if(notePosition - currentPosition <= myCheckRythm.range * maxRange)
        {
            IncreasePoints(maxPoints);
        }
        else if(notePosition - currentPosition <= myCheckRythm.range * midRange)
        {
            IncreasePoints(midPoints);
        }
        else if (notePosition - currentPosition <= myCheckRythm.range)
        {
            IncreasePoints(minPoints);
        }
    }

    public void IncreasePoints(float value)
    {
        totalPoints += value;
    }

    public void DecreasePoints(float value)
    {
        totalPoints -= value;
    }

    public void IncreaseProgressPoints()
    {
        totalPoints += pointsPerSecondCorridor * Time.deltaTime;
    }

}
