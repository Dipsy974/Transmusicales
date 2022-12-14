using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MonSliderMieuxQueCeluiDunity : Slider
{
    public UnityAction<float> eventCalled;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public void RemoveListener(UnityAction<float> evnt)
    {
        onValueChanged.RemoveListener(evnt);
    }

    public void AddListener(UnityAction<float> evnt)
    {
        onValueChanged.AddListener(evnt);
    }
}
