using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    // Start is called before the first frame update
    

    public void Awake()
    {
        
    }

    public void ShowOptions(GameObject layer)
    {
        layer.SetActive(true);
    }

    public void HideOptions(GameObject layer)
    {
        layer.SetActive(false);
    }
}
