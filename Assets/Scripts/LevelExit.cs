using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    private float timeToLoad;
    [SerializeField]
    private string levelToUnlock;


    public GameObject deathExplosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(deathExplosion, transform.position, Quaternion.identity);
        StartCoroutine(LoadNextLevel());
    }

    public IEnumerator LoadNextLevel()
    {

        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(timeToLoad);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Level_UnlockedDoor");
        Time.timeScale = 1f;
        PlayerPrefs.SetInt(levelToUnlock, 1);
    }

}
