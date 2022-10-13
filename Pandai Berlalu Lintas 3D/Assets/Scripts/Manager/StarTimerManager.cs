using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarTimerManager : MonoBehaviour
{
    public float maxTimer = 10f;
    public TextMeshProUGUI timerText;
    public Image starTimer;

    [HideInInspector]
    public bool getStarTimer = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        timerText.text = maxTimer.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (getStarTimer == true)
        {
            maxTimer -= Time.deltaTime;

            if (maxTimer > 0f)
            {
                if (maxTimer.ToString().Length > 4)
                {
                    timerText.text = maxTimer.ToString().Substring(0, 4);
                }
                else
                {
                    timerText.text = maxTimer.ToString();
                }
            }
            else
            {
                getStarTimer = false;
            }
        }
        else
        {
            starTimer.color = new Color(0.2392157f, 0.2392157f, 0.2392157f);
            maxTimer = 0;
            timerText.text = maxTimer.ToString().Substring(0, 1);
        }
    }
}
