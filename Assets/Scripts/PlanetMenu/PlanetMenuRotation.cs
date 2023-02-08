using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMenuRotation : MonoBehaviour

{

    [SerializeField]
    private float _rotationSpeed, _range;
    public string[] planetList;
    public int currentPlanetIndex = 0;
    public bool isRotating;
    private float delta = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRotating)
        {
            delta += Time.deltaTime * _rotationSpeed;
        }
        if (currentPlanetIndex == 1 && isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, -129f, transform.rotation.z), delta);
        }
        else if (currentPlanetIndex == 0 && isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z), delta);
        }
        if (currentPlanetIndex == 2 && isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 129f, transform.rotation.z), delta);
        }

        if(delta >= 0.1f)
        {
            isRotating = false;
            delta = 0;
        }

    }

    public void ChangePlanet(string direction)
    {
        isRotating = true;
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
