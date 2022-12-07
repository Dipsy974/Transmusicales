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
        if(myCond.songPositionInBeats > currentNote.keyPosition + 0.5f && compteur < myCond.notes.Length) //Actualise la note à checker
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

            if(compteur < myCond.notes.Length - 1) //Cap le compteur et la current note à la longueur de la liste -1 
            {
                compteur++;
                currentNote = myCond.notes[compteur];
            }      
        }

        if (myCharacter.freeMode)
        {
            CheckCorridor(); 
        }
    }

    public void CheckNote()
    {
        if(myCharacter.pathIndex == myCond.notes[compteur].line) //Seulement si le personnage est sur la bonne ligne
        {
            if (Approximation(myCond.songPositionInBeats, currentNote.keyPosition) && !currentNote.linkedEnd)
            {
                currentNote.CheckKey();

                if (currentNote.linkedStart)
                {
                    myCharacter.freeMode = true;
                 
                }
                else
                {
                    myNS.listNotes[compteur].GetComponent<SpriteRenderer>().enabled = false;

                    myDefM.IncreaseScore();
                   
                }
            }
        }  
    }

    public void CheckCorridor()
    {
        if (myCharacter.GetIsInCorridor())
        {
            myDefM.IncreaseScore();
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
