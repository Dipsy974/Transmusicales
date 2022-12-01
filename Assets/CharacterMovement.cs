using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Sinewave[] curves; 
    public Sinewave curve;
    public Conductor myCond;
    public NoteSpawner myNS; 
    private Vector3 startPos;
    private Vector3 finalPos;
    private int compteur = 0;
    public int pathIndex = 1; 



    // Start is called before the first frame update
    void Start()
    {
        compteur = 0;
        curve = curves[pathIndex]; 

        transform.position = curve.myLR.GetPosition(0); //Initialisation au point de d�part de la courbe
        startPos = transform.position;
        finalPos = curve.myLR.GetPosition(curve.myLR.positionCount - 1); 
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(
        //startPos,
        //curve.myLR.GetPosition((int)nextNote),
        //(myCond.beatsShownInAdvance - (nextNote - myCond.songPositionInBeats)) / myCond.beatsShownInAdvance
        //);

        //nextNote = myCond.notes[compteur]; 
        float progress = (myCond.songPositionInBeats) / myCond.songBpm;
        float y = Mathf.Lerp(startPos.y, finalPos.y, progress);
        float x = curve.amplitude * Mathf.Sin(y * 2 * Mathf.PI * curve.frequency);
        //float x = 2 * (((Mathf.PI / 2) - curve.amplitude * Mathf.Asin(Mathf.Cos(y))) / Mathf.PI) - 1;

        if (compteur < myNS.listNotes.Count)
        {
            if (Approximation(transform.position.y, myNS.listNotes[compteur].transform.position.y))
            {

                myNS.listNotes[compteur].GetComponent<SpriteRenderer>().color = Color.red;
                compteur++;
            }
        }
        


        transform.position = curve.transform.TransformPoint(x, y, -1);
    }

    bool Approximation(float value, float valuedeux)
    {
        if(Mathf.Abs(valuedeux - value) < 0.1)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }

    public void ChangePath(string direction)
    {
        if(direction == "LEFT")
        {
            if(pathIndex < 2)
            {
                pathIndex++; 
            }
        }else if(direction == "RIGHT")
        {
            if(pathIndex > 0)
            {
                pathIndex--; 
            }
        }


        curve = curves[pathIndex];
        startPos = curve.myLR.GetPosition(0);
        finalPos = curve.myLR.GetPosition(curve.myLR.positionCount - 1);
    }
}
