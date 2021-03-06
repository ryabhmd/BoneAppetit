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
    private Text _mainmenutext;
    [SerializeField]
    private Text _monsterlivestext;
    [SerializeField] 
    private Text _stagestext;
	[SerializeField]
    private Text _statustext;
    [SerializeField]
    private Text _restarttext;

    public void UpdateLives(int health)
    {
        // UPDATE TEXT 
        _livestext.text = "Lives: " + health;
    }
    
    public void UpdateMonsterLives(int health)
    {
	    // UPDATE TEXT 
	    _monsterlivestext.text = "Monster Lives: " + health;
    }

	public void UpdateStages(int stage)
	{
		_stagestext.text = "STAGE " + stage;
	}


	public void gameOver()
		{
			_statustext.text = "Game Over";
			_restarttext.text = "Click here to restart";
		}

	public void win()
	{
		_statustext.text = "You win!";
		_mainmenutext.text = "Back to Main Menu";
	}
}
