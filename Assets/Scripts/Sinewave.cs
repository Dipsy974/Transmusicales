using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinewave : MonoBehaviour
{
    public Conductor myCond; 
    public LineRenderer myLR;
    public int pointsRes; //R�solution de la courbe, nombre de points la composant
    public int pointsBeat; 
    public float amplitude = 1;
    public float frequency = 1;
    public Vector2 lineLimits = new Vector2(0, 1); 

    // Start is called before the first frame update
    void Start()
    {
        pointsBeat = myCond.selectedSong.keyBeats.Length;
        myLR.positionCount = pointsRes;

        Draw();
    }

    // Update is called once per frame
    void Update()
    {
        
        Draw(); 
    }

    private void Draw()
    {
        float xStart = lineLimits.x;
        float tau = 2 * Mathf.PI;
        float xEnd = lineLimits.y;


        for (int currentPoint = 0; currentPoint < pointsRes; currentPoint++)
        {
            float progress = (float)currentPoint / (pointsRes - 1);
            float x = Mathf.Lerp(xStart, xEnd, progress);
            float y = amplitude * Mathf.Sin(x * tau * frequency);
            myLR.SetPosition(currentPoint, new Vector3(y, x, 0));
        }


        //for (int currentPoint = 0; currentPoint < pointsRes; currentPoint++)
        //{
        //    float progress = (float)currentPoint / (pointsRes - 1);
        //    float x = Mathf.Lerp(xStart, xEnd, progress);
        //    float y = 2 * (((Mathf.PI / 2) - amplitude * Mathf.Asin(Mathf.Cos(x))) / Mathf.PI) - 1 * frequency;
        //    myLR.SetPosition(currentPoint, new Vector3(y, x, 0));
        //}

    }
}
