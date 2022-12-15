using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Conductor myCond; 
    public ScoreManager scoreManager;
    public TMPro.TextMeshProUGUI tM, tMsp; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tM.text = Mathf.Round(scoreManager.totalPoints).ToString();
        tMsp.text = myCond.songPositionInBeats.ToString();
    }
}
