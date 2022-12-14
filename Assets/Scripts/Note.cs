using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float yDistance;
    public Transform outline;
    private bool doOnce;
    void Start()
    {
      outline.GetComponent<SpriteRenderer>().material.SetFloat("_MainAlpha", 0f);
       
    }
    public float delta;
    void Update()
    {
        if(transform.position.y<=yDistance && transform.position.y>=0)
        {
            delta = transform.position.y / yDistance;

            outline.localScale = Vector3.one * Mathf.Lerp(0.66f, 1.24f,delta );
            outline.GetComponent<SpriteRenderer>().material.SetFloat("_MainAlpha", 1 - delta);
     
      
        }
    }
}
