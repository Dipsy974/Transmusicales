using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TMPro.TextMeshProUGUI tM; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tM.text = scoreManager.totalPoints.ToString();
    }
}
