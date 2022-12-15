using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesSpawner : MonoBehaviour
{
    public Conductor myCond;
    public Sinewave[] myCurves;
    public GameObject sprt_collectible;
    public List<GameObject> listCollectibles;
    public float collectibleScale;

    // Start is called before the first frame update
    void Start()
    {
        Song selectedSong = myCond.selectedSong;

        for (int i = 0; i < selectedSong.collectibles.Length; i++)
        {
            Sinewave curve = myCurves[selectedSong.collectibles[i].line]; //Cible la courbe où doit être placée la collectible
            Vector3 collectiblesPos = curve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.collectibles[i].keyPosition * (curve.pointsRes - 1) / myCond.totalBeats));
            GameObject collectible = (GameObject)Instantiate(sprt_collectible, curve.transform.TransformPoint(collectiblesPos) + new Vector3(0, 0, -1), Quaternion.identity, myCurves[selectedSong.collectibles[i].line].transform);
            collectible.transform.localScale = Vector3.one * collectibleScale;
            listCollectibles.Add(collectible);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Song selectedSong = myCond.selectedSong;

        for (int i = 0; i < listCollectibles.Count; i++)
        {
            Sinewave curve = myCurves[selectedSong.collectibles[i].line]; //Cible la courbe où doit être placée la collectible
            Vector3 collectiblesPos = curve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.collectibles[i].keyPosition * (curve.pointsRes - 1) / myCond.totalBeats));
            listCollectibles[i].transform.position = curve.transform.TransformPoint(collectiblesPos) + new Vector3(0, 0, -1);

        }

    }
}
