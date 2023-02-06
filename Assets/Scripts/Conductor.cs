using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{

    //Base de données
    public SongDatabaseUpdated songDatabase; //SongDatabase pour la single line
    public Song selectedSong;
    public SelectedSong songSelector;

    //Position Tracking
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;
    public float timerSetter; 

    //Song Info
    public float songBpm;
    public KeyBeats[] notes;  
    public AudioSource music;
    public float totalBeats; 


    //Note sprite
    public GameObject sprt_note;
  



    // Start is called before the first frame update
    void Start()
    {
        //Récupère une chanson au hasard dans la base de données pour l'instant. Devra faire en sorte de récupérer la chanson sélectionnée par l'utilisateur
        //songSelector = FindObjectOfType<SelectedSong>();
        //selectedSong = songSelector.selectedSong;
        //selectedSong = songDatabase.songs[Random.Range(0, songDatabase.songs.Length)];        
        selectedSong = songDatabase.songs[1];
        songBpm = selectedSong.bpm;
        notes = selectedSong.keyBeats; 
        music.clip = selectedSong.audio;
     


        dspSongTime = (float)AudioSettings.dspTime;

        secPerBeat = 60f / songBpm;

        totalBeats = (songBpm * music.clip.length) / 60f;
        Debug.Log(totalBeats); 
       

        music.Play(); 

    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            songPosition = (float)(AudioSettings.dspTime - dspSongTime);

            songPositionInBeats = songPosition / secPerBeat;
        }
    }
}
