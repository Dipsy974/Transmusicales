using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMenuRotation : MonoBehaviour

{

    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private string[] planetList;
    public int currentPlanetIndex = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlanetIndex == 1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, -130f, transform.rotation.z), _rotationSpeed);
        }
        else if (currentPlanetIndex == 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z), _rotationSpeed);
        }
        if (currentPlanetIndex == 2)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 130f, transform.rotation.z), _rotationSpeed);
        }

    }

    public void ChangePlanet(string direction)
    {
        if (direction == "right")
        {
            if (currentPlanetIndex > 1)
            {
                currentPlanetIndex = 0;
            }
            else
            {
                currentPlanetIndex += 1;
            }
        }
        else if (direction == "left")
        {
            if (currentPlanetIndex < 1)
            {
                currentPlanetIndex = 2;
            }
            else
            {
                currentPlanetIndex -= 1;
            }
        }
    }
}
