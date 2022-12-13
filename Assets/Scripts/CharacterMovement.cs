using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Sinewave[] curves; 
    public Sinewave curve;
    public Conductor myCond;
    public NoteSpawner myNS;
    public DefeatManager myDefeatManager;
    public int pathIndex = 1;
    public bool freeMode = false;
    public Transform parentTransform;
    
    
    private int _compteur = 0;
    private bool _isInCorridor = false;
    private bool _isTranslating = false;
    private Vector3 _target;
    private Vector3 _targetPosition;
    private float _x, _y;


    // Start is called before the first frame update
    void Start()
    {
        _compteur = 0;
        curve = curves[pathIndex]; 
        //transform.position = curve.myLR.GetPosition(0); //Initialisation au point de départ de la courbe
    }
    // Update is called once per frame
    void Update()
    {
       
        float progress = (myCond.songPositionInBeats) / myCond.totalBeats;
        _y = curve.ReturnActualY;
        _x = 0f;

        if (myCond.selectedSong.planet == "blue")
        {
            _x = curve.amplitude * Mathf.Sin(_y * 2 * Mathf.PI * curve.frequency);
        }
        else if (myCond.selectedSong.planet == "yellow")
        {
            _x = 2 * (((Mathf.PI / 2) - curve.amplitude * Mathf.Asin(Mathf.Cos(_y))) / Mathf.PI) - 1;
        }

            if (_compteur < myNS.listNotes.Count)
        {
            if (Approximation(transform.position.y, myNS.listNotes[_compteur].transform.position.y))
            {

                myNS.listNotes[_compteur].GetComponent<SpriteRenderer>().material.color = Color.red;
                _compteur++;
            }
        }

        if(!_isTranslating)
        {
            _targetPosition= curve.transform.TransformPoint(_x, _y, -1); //Suit la ligne
        }
        if (!freeMode)
        {
            transform.position = _targetPosition; //Suit la ligne
        }
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

    float Difference(float value, float valuedeux)
    {
        return Mathf.Abs(valuedeux - value); 
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

        StartCoroutine(ChangeCurve(pathIndex));
        
        _isTranslating = true; 
    }

    public void FollowInput(Vector2 position)
    {
        transform.position = new Vector3(position.x, transform.position.y, -1); 
    }

    public void SnapToClosestLine()
    {
        Sinewave closestCurve = curves[0]; 
        for(int i = 0; i < curves.Length; i++)
        {
             
            
            if(Difference(closestCurve.transform.position.x, transform.position.x) >= Difference(curves[i].transform.position.x, transform.position.x))
            {
                closestCurve = curves[i];
                pathIndex = i; 
            }
        }
 
        curve = closestCurve; 
    }

    public bool GetIsInCorridor()
    {
        return _isInCorridor; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isInCorridor = true; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isInCorridor = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "obstacle")
        {
            myDefeatManager.DecreaseScore();
        }
    }


    private IEnumerator ChangeCurve(int targetCurve)
    {
        float delta = 0;
        while(delta<=1)
        {
            delta += Time.deltaTime*3;
            _targetPosition = Vector3.Lerp(curve.transform.TransformPoint(_x, _y, -1), curves[targetCurve].transform.TransformPoint(_x, _y, -1),delta);
            yield return new WaitForEndOfFrame();
        }
        _isTranslating = false;
        curve = curves[targetCurve];
    }
}
