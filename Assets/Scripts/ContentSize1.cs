using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentSize1 : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform rt;
    public ButtonSpawner spawn;
    public float size;
    void Start()
    {
        size = spawn.spacing + 15f;
        rt.sizeDelta = new Vector2(0, size * spawn.database.songs.Length);

    }
}
