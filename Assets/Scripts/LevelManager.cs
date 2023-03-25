using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string ActualScene;
    public string NewSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.UnloadSceneAsync(ActualScene);
            SceneManager.LoadScene(NewSceneName);
        }
    }
}

