using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    new Animation animation;

    public GameObject childObject;
    
    bool forward = false;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animation.isPlaying == false)
        {
            if (forward)
            {
                transform.position = childObject.transform.position;
                childObject.transform.localPosition = Vector3.zero;
                forward = false;
            }
        }
    }

    public void CarForward()
    {
        if (forward)
        {
            animation.Stop();
            transform.position = childObject.transform.position;
            childObject.transform.localPosition = Vector3.zero;
            forward = false;
        }
        animation.Play("Forward");
        forward = true;
    }

    public void CarBackward()
    {
        animation.Play("Backward");
    }

    public void CarIdle()
    {
        animation.Play("Idle");
    }
}
