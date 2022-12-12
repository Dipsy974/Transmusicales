using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatBar : MonoBehaviour
{
    public Image circleBar;
    public float defeatValue;
    public float defeatMaxValue;
    public DefeatManager myDefM; 

    // Start is called before the first frame update
    void Start()
    {
        defeatMaxValue = myDefM.globalScore;
        defeatValue = myDefM.currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        defeatValue = myDefM.currentScore;
        DefeatScoreChange(defeatValue, defeatMaxValue); 
    }

    void DefeatScoreChange(float defeatValue, float defeatMaxValue)
    {
        float progress = (defeatValue / defeatMaxValue);
        circleBar.fillAmount = progress; 
    }
}
