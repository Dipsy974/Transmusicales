using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongDatabase : MonoBehaviour
{

    [System.Serializable]
    public class Song
    {
        public string name;
        public string artist;
        public AudioClip audio; 
        public int bpm;
        public float[] keyBeats; 

    }
    [System.Serializable]
    public class Database
    {
        public Song[] songs; 

    }

    public Database myDB = new Database(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
