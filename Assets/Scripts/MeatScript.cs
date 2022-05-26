using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatScript : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private SpawnManager _spawnManager;

    [SerializeField] 
    private PlayerScript _player;

    // DEFINE WINNING STATE 
    private void OnTriggerEnter(Collider other)
    {
        // IF PLAYER SELECTS THE GOLDEN COIN ...
        if (other.CompareTag("Player"))
        {
            _spawnManager.onPlayerWin();
            _uiManager.win();
            Destroy(this.gameObject);
            _player.delItems();
        }
    }
}
