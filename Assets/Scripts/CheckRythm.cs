using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRythm : MonoBehaviour
{
    public Conductor myCond;
    public NoteSpawner myNS;
    public CharacterMovement myCharacter;
    public PlayerController myPlayerController;
    public DefeatManager myDefM;
    public ScoreManager myScoreM;
    public ParticleSystem corridorParticles; 
    public ParticleSystem noteParticles; 
    private int compteur = 0;
    private int compteurObstacles = 0;
    private int compteurCollectibles = 0;
    private KeyBeats currentNote;
    private Obstacles currentObstacle;
    private Collectibles currentCollectible; 
    public float range;

    public int onBoardingTouchNb;
    public float onBoardingHoldNb;
    public int onBoardingSwipeNb;
    private bool _onBoardingTouchChecked = false;
    private bool _onBoardingHoldChecked = false;
    private bool _onBoardingSwipeChecked = false;
    private int onBoardingTouchCompteur = 0;
    private float onBoardingHoldCompteur = 0;
    private float onBoardingSwipeCompteur = 0;

    private KeyBeats _previousNote;

    public AnimatorLauncher animator;


    // Start is called before the first frame update
    void Start()
    {
        currentNote = myCond.notes[compteur];
        currentObstacle = myCond.selectedSong.obstacles[compteurObstacles];
        currentCollectible = myCond.selectedSong.collectibles[compteurCollectibles];


        _previousNote = currentNote;

    }

    // Update is called once per frame
    void Update()
    {
        if(myCond.songPositionInBeats > currentNote.keyPosition + 0.4f && compteur < myCond.notes.Length) //Actualise la note à checker
        {
            if (!currentNote.GetCheck() && !currentNote.linkedEnd)
            {
                myDefM.DecreaseScore();
            }

            if(currentNote.linkedEnd && !currentNote.linkedStart) //Désactive le freemode à la fin d'un corridor
            {
                myCharacter.freeMode = false;
                myCharacter.SnapToClosestLine();
            }


            _previousNote = currentNote; 
            compteur++;
            currentNote = myCond.notes[compteur];
                
        }


        if (myCond.songPositionInBeats > currentObstacle.keyPosition + 0.4f && compteur < myCond.selectedSong.obstacles.Length) //Actualise l'obstacle checker
        {
            
            compteurObstacles++;
            currentObstacle = myCond.selectedSong.obstacles[compteurObstacles];
        }

        if (myCond.songPositionInBeats > currentCollectible.keyPosition + 0.4f && compteur < myCond.selectedSong.collectibles.Length) //Actualise le collectible à checker
        {
            
            compteurCollectibles++;
            currentCollectible = myCond.selectedSong.collectibles[compteurCollectibles];
      
        }

        if (myCharacter.freeMode)
        {
            CheckCorridor();
        }
        else
        {
            corridorParticles.Stop();
        }

        //Si l'onboarding touch n'est pas fini, lance l'animation quand la note se rapproche
        if (!_onBoardingTouchChecked)
        {
            if(!currentNote.linkedStart && !currentNote.linkedEnd)
            {
                if(myCond.songPositionInBeats > currentNote.keyPosition - 2f)
                { 
                    animator.LaunchTap(); 
                }
            }
        }

        if (!_onBoardingHoldChecked)
        {
            if (currentNote.linkedStart)
            {
                if (myCond.songPositionInBeats > currentNote.keyPosition - 2f)
                {
                    animator.LaunchHold();
                }
            }
            if (_previousNote.linkedStart)
            {
                animator.LaunchHold();  
            }
        }


        if (!_onBoardingSwipeChecked)
        {
            if(myCond.songPositionInBeats > currentNote.keyPosition - 2f)
            {
                if(myCharacter.pathIndex > currentNote.line)
                {
                    animator.LaunchLeftSwipe();
                }
                else if(myCharacter.pathIndex < currentNote.line)
                {
                    animator.LaunchRightSwipe();
                }
            }
            if (myCond.songPositionInBeats > currentObstacle.keyPosition - 2f)
            {
                if (myCharacter.pathIndex == currentObstacle.line && myCharacter.pathIndex == 0)
                {
                    animator.LaunchRightSwipe();
                }
                else if (myCharacter.pathIndex == currentObstacle.line && myCharacter.pathIndex >= 1)
                {
                    animator.LaunchLeftSwipe();
                }
            }
            if (myCond.songPositionInBeats > currentCollectible.keyPosition - 2f)
            {
                
                if (myCharacter.pathIndex > currentCollectible.line)
                {
                    animator.LaunchLeftSwipe();
                }
                else if (myCharacter.pathIndex < currentCollectible.line)
                {
                    animator.LaunchRightSwipe();
                }
            }
        }
    }

    public void CheckNote()
    {
        if(myCharacter.pathIndex == myCond.notes[compteur].line) //Seulement si le personnage est sur la bonne ligne
        {
            if (Approximation(myCond.songPositionInBeats, currentNote.keyPosition) && !currentNote.linkedEnd)
            {

                if (currentNote.linkedStart)
                {
                    myCharacter.freeMode = true;
                 
                }
                else
                {
                    if (!currentNote.isChecked)
                    {
                        myNS.listNotes[compteur].GetComponent<SpriteRenderer>().enabled = false;
                        myNS.listNotes[compteur].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                        noteParticles.transform.position = new Vector3(myNS.listNotes[compteur].transform.position.x, myNS.listNotes[compteur].transform.position.y, noteParticles.transform.position.z); 
                        noteParticles.Play(); 

                        myDefM.IncreaseScore();

                        myScoreM.AccuracyPoints(myCond.songPositionInBeats, currentNote.keyPosition);
                    }

                    CheckOnboarding("touch"); 

                }

                currentNote.CheckKey();

            }

        }
        if (_previousNote.linkedStart)
        {
            myCharacter.freeMode = true;

        }
    }

    public void CheckCorridor()
    {
        if (myCharacter.GetIsInCorridor())
        {
            corridorParticles.transform.position = myCharacter.transform.position + new Vector3(0, 0, -2);
            if (!corridorParticles.isPlaying)
            {
                corridorParticles.Play();
            }
            CheckOnboarding("hold");
            myDefM.IncreaseProgressScore();
            myScoreM.IncreaseProgressPoints();
        }
        else
        {
            corridorParticles.Stop();
        }
    }

    public void CheckOnboarding(string type)
    {
        if(type == "touch")
        {
            onBoardingTouchCompteur++;
        }
        else if(type == "hold")
        {
            onBoardingHoldCompteur++;
            Debug.Log(onBoardingHoldCompteur); 
        }else if(type == "swipe")
        {
            onBoardingSwipeCompteur++;
        }

        if(onBoardingHoldCompteur >= onBoardingHoldNb)
        {
            _onBoardingHoldChecked = true; 
        }

        if (onBoardingTouchCompteur >= onBoardingTouchNb)
        {
            _onBoardingTouchChecked = true;
        }

        if (onBoardingSwipeCompteur >= onBoardingSwipeNb)
        {
            _onBoardingSwipeChecked = true;
        }
    }

    bool Approximation(float value, float secondvalue)
    {
        if (Mathf.Abs(secondvalue - value) < range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
