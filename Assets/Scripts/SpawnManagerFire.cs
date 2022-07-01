using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerFire : MonoBehaviour
{
    [SerializeField]
    private GameObject _firePrefab;

    private float _delay = 3f;
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
    
    public void onPlayerDeath()
    {
        _alive = false;
        _uiManager.gameOver();
    }

    public void onPlayerWin()
    {
        _win = true; 
    }

    // SPAWN FIRE IN STAGE4
    IEnumerator SpawnSystem()
    {
        // SPAWNING
        while (_alive && !_win)
        {
            Instantiate(_firePrefab, new Vector3(3.712f, Random.Range(-4f, 1f), 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
        }

        yield return null;
    }
}
