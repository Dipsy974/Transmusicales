using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
 
    public Conductor myCond;
    public Sinewave[] myCurves;
    public GameObject sprt_note;
    public List<GameObject> listNotes; 

    // Start is called before the first frame update
    void Start()
    {
        SongDatabaseUpdated.Song selectedSong = myCond.selectedSong;


        ////SINGLE LINE SPAWNER
        //for (int i = 0; i < selectedSong.keyBeats.Length; i++)
        //{
        //    Vector3 keyBeatsPos = myCurve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.keyBeats[i] * (myCurve.pointsRes - 1)) / (int)myCond.songBpm); 
        //    GameObject note = (GameObject)Instantiate(sprt_note, keyBeatsPos, Quaternion.identity);
        //    listNotes.Add(note);
        //}


        //MULTIPLE LINE SPAWNER
        
        for (int i = 0; i < selectedSong.keyBeats.Length; i++)
        {
            Sinewave curve = myCurves[selectedSong.keyBeats[i].line]; //Cible la courbe où doit être placée la note
            Vector3 keyBeatsPos = curve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.keyBeats[i].keyPosition * (curve.pointsRes - 1)) / (int)myCond.songBpm);
            GameObject note = (GameObject)Instantiate(sprt_note, curve.transform.TransformPoint(keyBeatsPos) , Quaternion.identity);
            listNotes.Add(note);
        }

    }

    // Update is called once per frame
    void Update()
    {
        SongDatabaseUpdated.Song selectedSong = myCond.selectedSong;

        for (int i = 0; i < listNotes.Count; i++)
        {
            Sinewave curve = myCurves[selectedSong.keyBeats[i].line]; //Cible la courbe où doit être placée la note
            Vector3 keyBeatsPos = curve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.keyBeats[i].keyPosition * (curve.pointsRes-1)) / (int)myCond.songBpm);
            listNotes[i].transform.position = curve.transform.TransformPoint(keyBeatsPos);

        }
    }
}
