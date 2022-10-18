using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    new Animation animation;

    public GameObject childObject;

    SFXManager sfx;

    [HideInInspector]
    public bool animationIsPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
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
        sfx.SfxMove();
        animation.Play("Forward");
    }

    public void CarBackward()
    {
        sfx.SfxMove();
        animation.Play("Backward");
    }

    public void CarLeftward()
    {
        sfx.SfxMove();
        animation.Play("Leftward");
    }

    public void CarRightward()
    {
        sfx.SfxMove();
        animation.Play("Rightward");
    }

    public void CarIdle()
    {
        sfx.SfxIdle();
        animation.Play("Idle");
    }

    public void CarTurnRight()
    {
        sfx.SfxTurn();
        animation.Play("TurnRight");
    }

    public void CarTurnRightSmall()
    {
        sfx.SfxTurn();
        animation.Play("TurnRightSmall");
    }

    public void CarTurnLeft()
    {
        sfx.SfxTurn();
        animation.Play("TurnLeft");
    }

    public void CarTurnLeftSmall()
    {
        sfx.SfxTurn();
        animation.Play("TurnLeftSmall");
    }

    public void CarLeftwardDelay(float delay)
    {
        StartCoroutine(LeftwardDelay(delay));
    }

    IEnumerator LeftwardDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        CarLeftward();

    }

    public void PlayAnimation()
    {
        sfx.SfxMove();
        animation.Play();
    }

    public void PlayAnimationName(string name)
    {
        sfx.SfxMove();
        animation.Play(name);
    }

    public void StopAnimation()
    {
        transform.position = childObject.transform.position;
        childObject.transform.localPosition = Vector3.zero;
        animation.Stop();
    }
}
