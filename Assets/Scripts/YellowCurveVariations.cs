using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCurveVariations : MonoBehaviour
{
    public Conductor myCond;
    public CharacterMovement myChar;

    public float amplitude = 1.1f;
    public float variationFrequency = 8f;
    public float maxAmplitude = 1.8f;

    public int count = 2;

    float baseAmplitude;
    float savedBeat;
    Sinewave savedCurve;

    bool isIncreasing = false;


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
            isIncreasing = true;
            count++;
        }

        if (isIncreasing)
        {
            if (savedCurve.amplitude < maxAmplitude)
            {
                Debug.Log("increase");
                Variation(myChar.curve, amplitude);
            }
            else
            {
                savedCurve.amplitude = maxAmplitude;
            }
        }
        else {

            if (savedCurve.amplitude > baseAmplitude)
            {
                Debug.Log("decrease");
                Variation(myChar.curve, -amplitude);
            }
            else
            {
                savedCurve.amplitude = baseAmplitude;
            }
        }

        if (myCond.songPositionInBeats >= savedBeat + 4)
        {
            isIncreasing = false;
        }

    }

    public void Variation(Sinewave curve, float amplitude)
    {
        curve.amplitude *= amplitude;
    }


}
