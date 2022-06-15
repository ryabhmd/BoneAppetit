using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _livestext;
	[SerializeField]
    private Text _statustext;
    [SerializeField]
    private Text _restarttext;

    public void UpdateLives(int health)
    {
        // UPDATE TEXT 
        _livestext.text = "Lives: " + health;
    }

	public void gameOver()
	{
		_statustext.text = "Game Over";
		_restarttext.text = "Click here to restart";
	}

	public void win()
	{
		_statustext.text = "You win!! :)";
		_restarttext.text = "Click here to restart";
	}
}
