using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElementsSpawner : MonoBehaviour
{
    public Conductor conductor;
    public BackgroundPulse prefab;
    public Transform beginning, end;

    private float currentTime;
    private float timeLimit = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= timeLimit)
        {
            var position = new Vector3(Random.Range(beginning.position.x, end.position.x), beginning.position.y, 0);
            BackgroundPulse instance = Instantiate(prefab, position, Quaternion.identity);
            instance.myCond = conductor;
            instance.depth = Random.Range(1f, 3f);
            timeLimit = Random.Range(1f, 3f);
            currentTime = 0f;
        }
        
    }
}