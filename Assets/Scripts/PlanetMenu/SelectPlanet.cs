using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlanet : MonoBehaviour
{
    public Camera mainCamera;
    public SelectedSong planetSelector;
    public PlanetMenuRotation changePlanet;
    // Start is called before the first frame update
    void Start()
    {
        planetSelector = FindObjectOfType<SelectedSong>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        planetSelector.selectedPlanet = changePlanet.planetList[changePlanet.currentPlanetIndex];
        SceneManager.LoadScene("ListMenu");
    }
}
