using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level duration in seconds")]
    [SerializeField] float levelDuration = 20f;
    bool triggeredLevelFinished = false;

    void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelDuration;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelDuration);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
