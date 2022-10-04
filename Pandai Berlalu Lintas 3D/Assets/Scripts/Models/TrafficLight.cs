using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public bool startGreen;
 
    public Material greenOn;
    public Material greenOut;

    public Material redOn;
    public Material redOut;

    public Material yellowOn;
    public Material yellowOut;

    public MeshRenderer green1;
    public MeshRenderer green2;

    public MeshRenderer red1;
    public MeshRenderer red2;

    public MeshRenderer yellow1;
    public MeshRenderer yellow2;

    public bool nextIdle;
    public bool nextForward;
    public bool nextBackward;
    public bool nextTurnLeft;
    public bool nextTurnLeftSmall;
    public bool nextTurnRight;
    public bool nextTurnRightSmall;

    LevelManager levelManager;


    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        if (startGreen)
        {
            green1.material = greenOn;
            green2.material = greenOut;

            red1.material = redOut;
            red2.material = redOn;

            yellow1.material = yellowOut;
            yellow2.material = yellowOut;
        }
        else
        {
            green1.material = greenOut;
            green2.material = greenOn;

            red1.material = redOn;
            red2.material = redOut;

            yellow1.material = yellowOut;
            yellow2.material = yellowOut;
        }
    }

    public void GreenToRed()
    {
        StartCoroutine(DelayGreenToRed());
    }

    IEnumerator DelayGreenToRed()
    {
        // light 1
        green1.material = greenOut;
        yellow1.material = yellowOn;

        yield return new WaitForSeconds(1f);
        yellow1.material = yellowOut;
        red1.material = redOn;

        yield return new WaitForSeconds(1f);

        // light 2
        red2.material = redOut;
        yellow2.material = yellowOn;
        yield return new WaitForSeconds(1f);
        green2.material = greenOn;
        yellow2.material = yellowOut;
    }

    public void RedToGreen()
    {
        StartCoroutine(DelayRedToGreen());
    }

    IEnumerator DelayRedToGreen()
    {
        // light 2
        green2.material = greenOut;
        yellow2.material = yellowOn;
        yield return new WaitForSeconds(1f);
        red2.material = redOn;
        yellow2.material = yellowOut;
        
        yield return new WaitForSeconds(1f);

        // light 1
        red1.material = redOut;
        yellow1.material = yellowOn;

        yield return new WaitForSeconds(1f);
        yellow1.material = yellowOut;
        green1.material = greenOn;

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
    }
}
