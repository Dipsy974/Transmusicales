using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenu : MonoBehaviour
{
    public float swipeSensibility;
    public PlanetMenuRotation rotation;
    public SelectPlanet selectPlanet;
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            MenuSwipe();
        }
    }

    public void MenuSwipe()
    {
            if (Input.touches.Length > 0)
            {
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Began)
                {
                    //save began touch 2d point
                    firstPressPos = new Vector2(t.position.x, t.position.y);
                }
                if (t.phase == TouchPhase.Ended)
                {
                    //save ended touch 2d point
                    secondPressPos = new Vector2(t.position.x, t.position.y);

                    //create vector from the two points
                    currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                    //normalize the 2d vector
                    Vector2 currentSwipeNormalized = currentSwipe.normalized; //Pour gérer la direction du swipe à la verticale

                if (currentSwipe.x < -swipeSensibility && currentSwipeNormalized.y > -0.5f && currentSwipeNormalized.y < 0.5f)
                {
                    rotation.ChangePlanet("left");
                }
                //swipe right
                else if (currentSwipe.x > swipeSensibility && currentSwipeNormalized.y > -0.5f && currentSwipeNormalized.y < 0.5f)
                {
                    rotation.ChangePlanet("right");
                }
                else if (!rotation.isRotating)
                {
                    selectPlanet.Select();
                }

            }
            
        }

    }

}
