using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMove : MonoBehaviour
{
    public bool nextIdle;
    public bool nextForward;
    public bool nextBackward;
    public bool nextLeftward;
    public bool nextRightward;
    public bool nextTurnLeft;
    public bool nextTurnLeftSmall;
    public bool nextTurnRight;
    public bool nextTurnRightSmall;
    public bool nextPlayAnimationName;
    public string animationName = "Forward";
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void NextMoveCar()
    {
        if (nextIdle)
        {
            levelManager.car.CarIdle();
        }

        if (nextForward)
        {
            levelManager.car.CarForward();
        }

        if (nextBackward)
        {
            levelManager.car.CarBackward();
        }

        if (nextLeftward)
        {
            levelManager.car.CarLeftward();
        }

        if (nextRightward)
        {
            levelManager.car.CarRightward();
        }

        if (nextTurnLeft)
        {
            levelManager.car.CarTurnLeft();
        }

        if (nextTurnLeftSmall)
        {
            levelManager.car.CarTurnLeftSmall();
        }

        if (nextTurnRight)
        {
            levelManager.car.CarTurnRight();
        }

        if (nextTurnRightSmall)
        {
            levelManager.car.CarTurnRightSmall();
        }

        if (nextPlayAnimationName)
        {
            levelManager.car.PlayAnimationName(animationName);
        }
    }

}
