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
    private int compteur = 0;
    private KeyBeats currentNote;
    public float range; 

    // Start is called before the first frame update
    void Start()
    {
        currentNote = myCond.notes[compteur];
     
    }

    // Update is called once per frame
    void Update()
    {
        if(myCond.songPositionInBeats > currentNote.keyPosition + 0.4f && compteur < myCond.notes.Length) //Actualise la note à checker
        {
            Debug.Log(currentNote.GetCheck());
            if (!currentNote.GetCheck() && !currentNote.linkedEnd)
            {
                myDefM.DecreaseScore(); 
            }

            if(currentNote.linkedEnd && !currentNote.linkedStart) //Désactive le freemode à la fin d'un corridor
            {
                myCharacter.freeMode = false;
                myCharacter.SnapToClosestLine();
            }


            compteur++;
            currentNote = myCond.notes[compteur];
                
        }

        if (myCharacter.freeMode)
        {
            CheckCorridor();
        }
        else
        {
            corridorParticles.Stop();
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

                        myDefM.IncreaseScore();

                        myScoreM.AccuracyPoints(myCond.songPositionInBeats, currentNote.keyPosition);
                    }

                }

                currentNote.CheckKey();


            }
        }  
    }

    public void CheckCorridor()
    {
        if (myCharacter.GetIsInCorridor())
        {
            corridorParticles.transform.position = myCharacter.transform.position; 
            corridorParticles.Play(); 
            myDefM.IncreaseProgressScore();
        }
        else
        {
            corridorParticles.Stop();
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
