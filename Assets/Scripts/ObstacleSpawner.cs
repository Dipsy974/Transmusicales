using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Conductor myCond;
    public Sinewave[] myCurves;
    public GameObject sprt_obstacle;
    public GameObject sprt_bigObstacle;
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
            GameObject obstacle; 
            if (selectedSong.obstacles[i].isBig)
            {
                float pos = 0; 
                if(selectedSong.obstacles[i].line == 0)
                {
                    pos = -1.28f;     
                }
                else if(selectedSong.obstacles[i].line == 2)
                {
                    pos = 1.28f;
                }
                obstacle = (GameObject)Instantiate(sprt_bigObstacle, curve.transform.TransformPoint(obstaclesPos) + new Vector3(pos, 0, -0.8f), Quaternion.identity, myCurves[selectedSong.obstacles[i].line].transform);
            }
            else
            {
                obstacle = (GameObject)Instantiate(sprt_obstacle, curve.transform.TransformPoint(obstaclesPos) + new Vector3(0, 0, -0.8f), Quaternion.identity, myCurves[selectedSong.obstacles[i].line].transform);
                obstacle.transform.localScale = Vector3.one * obstacleScale;
            }
            
            
            obstacle.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
            listObstacles.Add(obstacle);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Song selectedSong = myCond.selectedSong;

        
        for (int i = 0; i < listObstacles.Count; i++)
        {
            float pos = 0;
            if (selectedSong.obstacles[i].line == 0 && selectedSong.obstacles[i].isBig)
            {
                pos = -1.28f;
            }
            else if (selectedSong.obstacles[i].line == 2 && selectedSong.obstacles[i].isBig)
            {
                pos = 1.28f;
            }

            Sinewave curve = myCurves[selectedSong.obstacles[i].line]; //Cible la courbe où doit être placée la obstacle
            Vector3 obstaclesPos = curve.GetComponent<LineRenderer>().GetPosition(Mathf.RoundToInt(selectedSong.obstacles[i].keyPosition * (curve.pointsRes - 1) / myCond.totalBeats));
            listObstacles[i].transform.position = curve.transform.TransformPoint(obstaclesPos) + new Vector3(pos, 0, -0.8f);

        }

    }
}
