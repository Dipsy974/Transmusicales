using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Song : ScriptableObject
{
    public string songName;
    public string artistName;
    public string planet;
    public int bpm;
    public AudioClip audio;
    public KeyBeats[] keyBeats;
    public Obstacles[] obstacles;
    
}
