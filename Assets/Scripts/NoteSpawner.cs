using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
 
    public Conductor myCond;
    public Sinewave[] myCurves;
    public GameObject sprt_note;
    public List<GameObject> listNotes; 
    public List<GameObject> listNotesLinkedStart; 
    public List<GameObject> listLinks;
    public Material corridorMat; 

    // Start is called before the first frame update
    void Start()
    {
        Song selectedSong = myCond.selectedSong;


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
            Vector3 keyBeatsPos = curve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.keyBeats[i].keyPosition * (curve.pointsRes - 1) / myCond.totalBeats));
            GameObject note = (GameObject)Instantiate(sprt_note, curve.transform.TransformPoint(keyBeatsPos) , Quaternion.identity, myCurves[selectedSong.keyBeats[i].line].transform);
            listNotes.Add(note);
        }

        for (int i = 0; i < selectedSong.keyBeats.Length; i++)
        {
            if(selectedSong.keyBeats[i].linkedStart || selectedSong.keyBeats[i].linkedEnd)
            {
                listNotes[i].GetComponent<SpriteRenderer>().material.SetColor("_MainColor", Color.magenta); 
            }
        }


        //Link les notes entre elles : Corridors
        for (int i = 0; i < selectedSong.keyBeats.Length; i++)
        {
            if (selectedSong.keyBeats[i].linkedStart)
            {
                Vector3 startLine = listNotes[i].transform.position;
                Vector3 endLine = listNotes[i + 1].transform.position;

                GameObject myLine = new GameObject();
                myLine.transform.position = startLine;
                myLine.AddComponent<LineRenderer>();
                myLine.AddComponent<EdgeCollider2D>();
                myLine.GetComponent<EdgeCollider2D>().isTrigger = true;
                LineRenderer lr = myLine.GetComponent<LineRenderer>();

                lr.startWidth = 5f;
                lr.endWidth = 5f;
                lr.startColor = Color.magenta;
                lr.endColor = Color.magenta;

                lr.material = corridorMat; 
                lr.SetPosition(0, startLine);
                lr.SetPosition(1, endLine);

                listNotesLinkedStart.Add(listNotes[i]); 
                listLinks.Add(myLine);

                SetCorridorCollider(myLine); //Initalise les colliders de la ligne

            }
        }

      



    }

    // Update is called once per frame
    void Update()
    {
        Song selectedSong = myCond.selectedSong;

        for (int i = 0; i < listNotes.Count; i++)
        {
            Sinewave curve = myCurves[selectedSong.keyBeats[i].line]; //Cible la courbe où doit être placée la note
            Vector3 keyBeatsPos = curve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.keyBeats[i].keyPosition * (curve.pointsRes - 1) / myCond.totalBeats));
            listNotes[i].transform.position = curve.transform.TransformPoint(keyBeatsPos);
    
        }

        for(int i = 0; i < listNotesLinkedStart.Count; i++) //Update positions des corridors et leurs colliders
        {
            LineRenderer lr = listLinks[i].GetComponent<LineRenderer>();
            lr.SetPosition(0, listNotesLinkedStart[i].transform.position);
            lr.SetPosition(1, listNotes[listNotes.IndexOf(listNotesLinkedStart[i])+ 1].transform.position);

            SetCorridorCollider(listLinks[i]); //Update les colliders de la line
        }



    }

    public void SetCorridorCollider(GameObject line)
    {
        LineRenderer lr = line.GetComponent<LineRenderer>();
        EdgeCollider2D edgeCollider = line.GetComponent<EdgeCollider2D>();
        Transform lineTransform = lr.transform;

        List<Vector2> edges = new List<Vector2>();

        for(int point = 0; point < lr.positionCount; point++)
        {
            Vector3 lineRendererPoint = lr.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x - lineTransform.position.x, lineRendererPoint.y - lineTransform.position.y)); 
        }

        edgeCollider.SetPoints(edges); 
    }
}
