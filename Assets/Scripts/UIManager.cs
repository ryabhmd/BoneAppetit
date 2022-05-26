using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _livestext;
	[SerializeField]
    private Text _statustext;


    public void UpdateLives(int health)
    {
        // UPDATE TEXT 
        _livestext.text = "Lives: " + health;
    }

	public void gameOver()
	{
		_statustext.text = "Game Over! :(";
	}

	public void win()
	{
		_statustext.text = "You win!! :)";
	}
}
