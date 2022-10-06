using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VersionText : MonoBehaviour
{
    TextMeshProUGUI versionText;

    // Start is called before the first frame update
    void Start()
    {
        versionText = GetComponent<TextMeshProUGUI>();
        versionText.text = "Versi " + Application.version.ToString();
    }
}
