using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    new Animation animation;

    public GameObject childObject;

    [HideInInspector]
    public bool animationIsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponentInChildren<Animation>();
    }

    void Update()
    {
        animationIsPlaying = animation.isPlaying;
        if (animationIsPlaying == false)
        {
            transform.position = childObject.transform.position;
            childObject.transform.localPosition = Vector3.zero;
        }
    }

    public void CarForward()
    {
        animation.Play("Forward");
    }

    public void CarBackward()
    {
        animation.Play("Backward");
    }

    public void CarLeftward()
    {
        animation.Play("Leftward");
    }

    public void CarRightward()
    {
        animation.Play("Rightward");
    }

    public void CarIdle()
    {
        animation.Play("Idle");
    }

    public void CarTurnRight()
    {
        animation.Play("TurnRight");
    }

    public void CarTurnRightSmall()
    {
        animation.Play("TurnRightSmall");
    }

    public void CarTurnLeft()
    {
        animation.Play("TurnLeft");
    }
    
    public void CarTurnLeftSmall()
    {
        animation.Play("TurnLeftSmall");
    }

    public void PlayAnimation()
    {
        animation.Play();
    }
}
