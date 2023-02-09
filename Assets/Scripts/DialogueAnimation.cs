using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("StartFade", 2);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartFade()
    {
        animator.SetTrigger("Fade");
    }

}
