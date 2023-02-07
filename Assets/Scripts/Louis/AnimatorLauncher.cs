using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorLauncher : MonoBehaviour
{
    public Animator animator;
    public GameObject holder;

    private bool coroutineLaunched;
    private IEnumerator LaunchAnimation(string str)
    {
        coroutineLaunched = true;

        
        animator.SetTrigger(str);
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Invisible");
        
        coroutineLaunched = false;

    }

    public void LaunchTap()
    {
        if(!coroutineLaunched)
        {
            StartCoroutine(LaunchAnimation("Tap"));
        }
    }

    public void LaunchHold()
    {
        if (!coroutineLaunched)
        {
            StartCoroutine(LaunchAnimation("Hold"));
        }
    }
    
    public void LaunchLeftSwipe()
    {
        if (!coroutineLaunched)
        {
            StartCoroutine(LaunchAnimation("SwipeLeft"));
        }
    }
    
    public void LaunchRightSwipe()
    {
        if (!coroutineLaunched)
        {
            StartCoroutine(LaunchAnimation("SwipeRight"));
        }
    }

}
