using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    public SongDatabaseUpdated database;
    public RectTransform parent;
    public Button button;
    public SelectedSong selectedSong;
    public float spacing = 150f;
    //Dictionary<int, Song> songList =
    //new Dictionary<int, Song>();
    //public string planet;

    // Start is called before the first frame update
    void Start()
    {
        selectedSong = FindObjectOfType<SelectedSong>();

        float newY = transform.position.y;

        //for (int i = 0; i < database.songs.Length; i++)
        //{
        //    if (database.songs[i].genre == planet)
        //    {
        //        songList.Add(i, database.songs[i]);
        //    };
        //}

        //Dictionary<int, Song>.KeyCollection keyColl = songList.Keys;

        //foreach (int k in keyColl)
        //{
        //    newY -= spacing;
        //    Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
        //    transform.position = newPosition;
        //    Button thisInstance = Instantiate(button, newPosition, Quaternion.identity, parent);
        //    string name = database.songs[k].name;
        //    GameObject tmgm = thisInstance.transform.GetChild(0).gameObject;
        //    tmgm.GetComponent<TMPro.TextMeshProUGUI>().text = name;
        //    thisInstance.GetComponent<ButtonScript>().attachedSong = database.songs[k];
        //    thisInstance.GetComponent<ButtonScript>().selectedSong = selectedSong;
        //}

        for (int i = 0; i < database.songs.Length; i++)
        {
            Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
            transform.position = newPosition;
            Button thisInstance = Instantiate(button, newPosition, Quaternion.identity, parent);
            string name = database.songs[i].songName;
            string artistName = database.songs[i].artistName;
            GameObject tmgm = thisInstance.transform.GetChild(0).gameObject;
            tmgm.GetComponent<TMPro.TextMeshProUGUI>().text = name + " - " + artistName ;
            thisInstance.GetComponent<ButtonScript>().attachedSong = database.songs[i];
            thisInstance.GetComponent<ButtonScript>().selectedSong = selectedSong;
            newY -= spacing;
        }
    }
}
