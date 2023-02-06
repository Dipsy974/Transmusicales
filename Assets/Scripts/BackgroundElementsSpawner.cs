using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElementsSpawner : MonoBehaviour
{
    public Conductor conductor;
    public BackgroundPulse[] prefabs;
    public Transform beginning, end;
    public Transform beginningVertical, endVertical;
    public float minTime, maxTime;
    public float minDepth, maxDepth;

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
            var index = Random.Range(0, 2);
            var position = new Vector3(); 

            if(index == 0)
            {
               position = new Vector3(Random.Range(beginning.position.x, end.position.x), beginning.position.y, 0);

            }else if(index == 1)
            {
                var startXIndex = Random.Range(0, 2);
                Transform[] positions = { beginning, end };
                var startX = positions[startXIndex]; 
                
               position = new Vector3(startX.position.x, Random.Range(beginningVertical.position.y, endVertical.position.y), 0);
            }
            
            BackgroundPulse instance = Instantiate(prefabs[Random.Range(0,2)], position, Quaternion.identity);
            instance.myCond = conductor;
            instance.transform.localScale = Vector3.one * 0.1f;
            instance.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 90));
            instance.depth = Random.Range(minDepth, maxDepth);
            timeLimit = Random.Range(minTime, maxTime);
            currentTime = 0f;
        }
        
    }
}
