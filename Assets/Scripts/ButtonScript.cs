using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public SelectedSong selectedSong;
    public Song attachedSong;
    public Image img;
    public Sprite newSprite;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSprite()
    {
        img.sprite = newSprite;
    }

    public void StartScene()
    {
        selectedSong.selectedSong = attachedSong;
        SceneManager.LoadScene("SampleScene");
    }

}
