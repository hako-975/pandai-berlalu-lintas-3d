using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MusicManager");

        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        GetComponent<AudioSource>().volume = 1f;
    }
}
