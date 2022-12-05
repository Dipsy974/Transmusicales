using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRythm : MonoBehaviour
{
    public Conductor myCond;
    public NoteSpawner myNS;
    public CharacterMovement myCharacter;
    public PlayerController myPlayerController; 
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
        if(myCond.songPositionInBeats > currentNote.keyPosition + 0.5f && compteur < myCond.notes.Length - 1)
        {
            compteur++;
            currentNote = myCond.notes[compteur];
        }
    }

    public void CheckNote()
    {
        if(myCharacter.pathIndex == myCond.notes[compteur].line) //Seulement si le personnage est sur la bonne ligne
        {
            if (Approximation(myCond.songPositionInBeats, currentNote.keyPosition))
            {
                myNS.listNotes[compteur].GetComponent<SpriteRenderer>().enabled = false;

                if (currentNote.linkedStart)
                {
                    myCharacter.freeMode = true;
                }
            }
        }  
    }

    public void CheckCorridor()
    {
        
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
