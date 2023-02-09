using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyBeats
{
    public float keyPosition;
    public int line;
    public bool linkedStart;
    public bool linkedEnd;
    public bool isObstacle;

    [System.NonSerialized]
    public bool isChecked = false;

    public void CheckKey()
    {
        isChecked = true; 
    }

    public bool GetCheck()
    {
        return isChecked;
    }
}


[System.Serializable]
public class Obstacles
{
    public float keyPosition;
    public int line;
    public bool isBig; 

}

[System.Serializable]
public class Collectibles
{
    public float keyPosition;
    public int line;

}

