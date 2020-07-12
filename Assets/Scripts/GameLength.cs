using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLength : MonoBehaviour
{
    TextMeshPro gameLength;
    void Start ()
    {
        gameLength = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        UpdateTime();
    }
    private void UpdateTime()
    {
        int minutes = (int)Time.timeSinceLevelLoad / 60;
        int seconds = (int)Time.timeSinceLevelLoad % 60;
        if(seconds < 10)
        {
            gameLength.text = minutes.ToString() + ":" + "0" + seconds.ToString();
        }
        else
            gameLength.text = minutes.ToString() + ":" + seconds.ToString();
    }

}
