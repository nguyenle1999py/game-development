using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSlow = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel()); 
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelExitSlow;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        var currentSceneId = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(3);
    }
}
