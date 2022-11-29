using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{

    //Base de donn�es
    public SongDatabaseUpdated songDatabase; //SongDatabase pour la single line
    public Song selectedSong; 

    //Position Tracking
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;
    public float firstBeatOffset;

    //Song Info
    public float songBpm;
    public KeyBeats[] notes;  
    public AudioSource music;


    //Note sprite
    public GameObject sprt_note;
  



    // Start is called before the first frame update
    void Start()
    {
        //R�cup�re une chanson au hasard dans la base de donn�es pour l'instant. Devra faire en sorte de r�cup�rer la chanson s�lectionn�e par l'utilisateur
        selectedSong = songDatabase.songs[Random.Range(0, songDatabase.songs.Length)];
        songBpm = selectedSong.bpm;
        notes = selectedSong.keyBeats; 
        music.clip = selectedSong.audio;
     


        dspSongTime = (float)AudioSettings.dspTime;

        secPerBeat = 60f / songBpm;

        music.Play(); 

    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        songPositionInBeats = songPosition / secPerBeat; 

    }
}
