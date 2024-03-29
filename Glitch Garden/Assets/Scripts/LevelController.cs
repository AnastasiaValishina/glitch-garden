﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{    
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    float winDelay;
    bool priorityLose = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        winDelay = GetComponent<AudioSource>().clip.length;
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <=0 && levelTimerFinished && !priorityLose)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winDelay);
        GetComponent<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        priorityLose = true;
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}
