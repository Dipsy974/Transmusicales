using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCurveVariations : MonoBehaviour
{
    public Conductor myCond;
    public CharacterMovement myChar;
    public float amplitude = 1.1f;
    public float variationFrequency;
    public float maxAmplitude;
    public float minAmplitude;
    public int count = 2;
    float baseAmplitude;
    float savedBeat;
    Sinewave savedCurve;


    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {

        if (myCond.songPositionInBeats >= variationFrequency * count)
        {
            baseAmplitude = myChar.curve.amplitude;
            savedCurve = myChar.curve;
            savedBeat = myCond.songPositionInBeats;
            Debug.Log("variation");
            VariationTest(myChar.curve, amplitude);
            count++;
        }

        if (myCond.songPositionInBeats >= savedBeat + 1)
        {
            savedCurve.amplitude = baseAmplitude;
        }

    }

    public void VariationTest(Sinewave curve, float amplitude)
    {
        curve.amplitude *= amplitude;
    }


}
