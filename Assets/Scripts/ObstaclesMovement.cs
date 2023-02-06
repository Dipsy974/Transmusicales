using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    private string[] directions = { "left", "right" };
    private string direction;
    private float speed;
    [SerializeField]
    private int[] speedRange; 

    // Start is called before the first frame update
    void Start()
    {
        direction = directions[Random.Range(0, 1)];
        speed = Random.Range(speedRange[0], speedRange[1]); 

    }

    // Update is called once per frame
    void Update()
    {
        if(direction == "left")
        {
            transform.Rotate(new Vector3(0, 0, -speed) * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
        }
    }
}
