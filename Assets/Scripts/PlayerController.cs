using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CheckRythm myCheck;
    public CharacterMovement myCharacter;
    public float swipeSensibility; 
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    

    // Start is called before the first frame update
    void Start()
    {
        myCharacter = CharacterMovement.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {

            Swipe();


            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
  
            if(touch.phase == TouchPhase.Began)
            {
                myCheck.CheckNote(); //check if note is pressed 
            }
            
            
            if (myCharacter.freeMode)
            {
                myCharacter.FollowInput(touchPosition);

                if (touch.phase == TouchPhase.Ended)
                {
                    myCharacter.freeMode = false;
                    myCharacter.SnapToClosestLine();
                }
            }
            
        }

    }


 
    public void Swipe()
    {
        if (!myCharacter.freeMode) // swipe disponibles que si le freemode est pas activé
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



                    //swipe left
                    if (currentSwipe.x < -swipeSensibility && currentSwipeNormalized.y > -0.5f && currentSwipeNormalized.y < 0.5f)
                    {
                        myCharacter.ChangePath("RIGHT");
                        myCheck.CheckOnboarding("swipe");
                    }
                    //swipe right
                    if (currentSwipe.x > swipeSensibility && currentSwipeNormalized.y > -0.5f && currentSwipeNormalized.y < 0.5f)
                    {
                        myCharacter.ChangePath("LEFT");
                        myCheck.CheckOnboarding("swipe");
                    }

                    
                }
            }
        }
        
    }


}
