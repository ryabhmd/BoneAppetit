using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // SWITCH TO LEVEL 2
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
