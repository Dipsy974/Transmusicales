using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCurveVariations : MonoBehaviour
{
    public PlayerController myPlayerController;
    public CharacterController myChar;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VariationTest(Sinewave curve, float amplitude)
    {
        curve.amplitude *= amplitude;
    }
}
