using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    private float _delay = 10f;
    private bool _alive = true;
	private bool _win = false;
	[SerializeField]
	private UIManager _uiManager;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // public so we can access it in PlayerScript
    public void onPlayerDeath()
    {
        _alive = false;
		_uiManager.gameOver();
    }

	public void onPlayerWin()
    {
        _win = true; 
    }

    IEnumerator SpawnSystem()
    {
        // SPAWNING
        while (_alive && !_win)
        {
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-20f, 8f), 20f, 0), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
        }

        yield return null;
    }
    
}
