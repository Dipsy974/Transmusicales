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
    private bool isChecked = false;

    public void CheckKey()
    {
        isChecked = true; 
    }

    public bool GetCheck()
    {
        return isChecked;
    }
}

