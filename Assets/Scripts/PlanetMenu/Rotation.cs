using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    private float _speed;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _speed);
    }
}
