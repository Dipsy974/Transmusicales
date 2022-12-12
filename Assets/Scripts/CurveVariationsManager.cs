using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveVariationsManager : MonoBehaviour
{
    public Conductor myCond;
    public YellowCurveVariations YellowVariations;
    // Start is called before the first frame update
    void Start()
    {
        if(myCond.selectedSong.planet == "yellow")
        {
            //YellowVariations.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
