using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string ActualScene;
    public string NewSceneName;
    public GameObject Music;

    private void Awake()
    {
        DontDestroyOnLoad(Music);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Scene CurrentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(NewSceneName);
            SceneManager.UnloadSceneAsync(ActualScene);
        }
    }
}

