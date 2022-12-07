using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public SelectedSong selectedSong;
    public Song attachedSong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartScene()
    {
        selectedSong.selectedSong = attachedSong;
        SceneManager.LoadScene(2);
    }
}
