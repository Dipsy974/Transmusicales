using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPulse : MonoBehaviour
{
    public Conductor myCond;
    public float minScale;
    public float maxScale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            transform.localScale = Vector3.one * Mathf.Lerp(maxScale, minScale, myCond.songPositionInBeats % 1); 
    }
}
