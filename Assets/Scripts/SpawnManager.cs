using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    private float _delay = 6f;
    private bool _alive = true;
	private bool _win = false;
	[SerializeField]
	private UIManager _uiManager;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }
    
    // INSTANTIATE PLAYER DEATH STATUS
    public void onPlayerDeath()
    {
        _alive = false;
		_uiManager.gameOver();
    }

    // INSTANTIATE PLAYER WIN STATUS
	public void onPlayerWin()
    {
        _win = true; 
    }

    // SPAWN CHOCOLATE BARS
    IEnumerator SpawnSystem()
    {
        // SPAWNING
        while (_alive && !_win)
        {
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-20f, 8f), 40f, 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
        }

        yield return null;
    }
    
}
