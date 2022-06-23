using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    // SWITCH TO NEXT STAGE
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }
}
