using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Conductor myCond;
    public Sinewave[] myCurves;
    public GameObject sprt_obstacle;
    public List<GameObject> listObstacles;
    public float obstacleScale;

    // Start is called before the first frame update
    void Start()
    {
        Song selectedSong = myCond.selectedSong;

        for (int i = 0; i < selectedSong.obstacles.Length; i++)
        {
            Sinewave curve = myCurves[selectedSong.obstacles[i].line]; //Cible la courbe où doit être placée la obstacle
            Vector3 obstaclesPos = curve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.obstacles[i].keyPosition * (curve.pointsRes - 1) / myCond.totalBeats));
            GameObject obstacle = (GameObject)Instantiate(sprt_obstacle, curve.transform.TransformPoint(obstaclesPos) + new Vector3(0, 0, -0.8f), Quaternion.identity, myCurves[selectedSong.obstacles[i].line].transform);
            obstacle.transform.localScale = Vector3.one * obstacleScale;
            obstacle.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 90));
            listObstacles.Add(obstacle);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Song selectedSong = myCond.selectedSong;

        for (int i = 0; i < listObstacles.Count; i++)
        {
            Sinewave curve = myCurves[selectedSong.obstacles[i].line]; //Cible la courbe où doit être placée la obstacle
            Vector3 obstaclesPos = curve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.obstacles[i].keyPosition * (curve.pointsRes - 1) / myCond.totalBeats));
            listObstacles[i].transform.position = curve.transform.TransformPoint(obstaclesPos) + new Vector3(0, 0, -0.8f);

        }

    }
}
