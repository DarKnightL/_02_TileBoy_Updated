using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField]
    private int playerLives = 3;
    [SerializeField]
    private Text scoreText, lifeText;

    private int score = 0;

    private ResetOnRespawn[] objectsToReset;

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        objectsToReset = FindObjectsOfType<ResetOnRespawn>();
        scoreText.text = "Score: " + score.ToString();
        lifeText.text = "Life X " + playerLives.ToString();
    

    }




    public void ProcessPlayerDeath()
    {

        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }


    private void ResetGameSession()
    {
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetStatus();
        }
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }


    private void TakeLife()
    {
        playerLives--;
        lifeText.text = "Life X " + playerLives.ToString();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score.ToString();
    }
}
