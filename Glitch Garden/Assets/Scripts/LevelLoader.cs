﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("OptionsScreen");
    }
}
