using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level duration in seconds")]
    [SerializeField] float levelDuration = 20f;

    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelDuration;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelDuration);

        if (timerFinished)
        {
            Debug.Log("Times up!");
        }
    }
}
