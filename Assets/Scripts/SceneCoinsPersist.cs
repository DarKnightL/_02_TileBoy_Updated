using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCoinsPersist : MonoBehaviour
{ 


    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<SceneCoinsPersist>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        //var firstSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       
        //if (currentSceneIndex!=firstSceneIndex)
        //{
        //    Destroy(gameObject);
        //}
    }

}
