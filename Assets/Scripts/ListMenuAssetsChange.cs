using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMenuAssetsChange : MonoBehaviour
{
    public SelectedSong selectedSong;
    public GameObject[] canvasPrefabs;
    [SerializeField]
    private Transform _parent;
    public string planet;
    public int planetIndex;

    // Start is called before the first frame update
    void Start()
    {
        selectedSong = FindObjectOfType<SelectedSong>();

        planet = selectedSong.selectedPlanet;

        if (planet == "Nostalgia")
        {
            planetIndex = 0;
        }
        else if (planet == "Dreamy")
        {
            planetIndex = 1;
        }
        else if (planet == "Wild")
        {
            planetIndex = 2;
        }



        Instantiate(canvasPrefabs[planetIndex], _parent.position, Quaternion.identity, _parent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
