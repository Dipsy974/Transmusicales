using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPulse : MonoBehaviour
{
    public Conductor myCond;
    public SpriteRenderer spriteRenderer;
    public float minScale;
    public float maxScale;
    public float depth;

    public float opacity = 0.2f;
    public float scrollSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        opacity *= depth;
        scrollSpeed *= depth;
        minScale *= depth;
        maxScale *= depth;
    }

    // Update is called once per frame
    void Update()
    {


        transform.localScale = Vector3.one * Mathf.Lerp(maxScale, minScale, myCond.songPositionInBeats % 1) * 0.1f;

        Color spriteColor = spriteRenderer.color;
        spriteColor.a = opacity;
        spriteRenderer.color = spriteColor;

        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
