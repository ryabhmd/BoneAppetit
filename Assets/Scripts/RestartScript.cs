using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    private Boolean _isPressed;

    // Update is called once per frame
    public void ResetGame()
    {
            Debug.Log("restarting");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
