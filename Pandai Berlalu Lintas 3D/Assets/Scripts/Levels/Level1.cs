using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    new Animation animation;

    public GameObject childObject;
    
    bool forward = false;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponentInChildren<Animation>();
        CarForward();
    }

    void Update()
    {
        if (animation.isPlaying == false)
        {
            if (forward)
            {
                transform.position = childObject.transform.position;
                childObject.transform.localPosition = Vector3.zero;
                childObject.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                forward = false;
            }
        }
    }

    public void CarForward()
    {
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
