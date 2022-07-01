using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] private float _monsterSpeed = 6f;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private SpawnManagerFire _fireSpawnManager;
    private bool movingDown;
    private PlayerScript _player;
    private int _monsterLives;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _monsterLives = 5;
        movingDown = true;
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MonsterMovement();
    }
    
    // MAKE MONSTER CONSTANTLY MOVE UP AND DOWN
    private void MonsterMovement()
    {
        if (transform.position.y <= -4)
        {
            movingDown = false;
        }

        if (transform.position.y > 1)
        {
            movingDown = true;
        }
        if (movingDown)
        {
            transform.Translate(Vector3.down * _monsterSpeed * Time.deltaTime);
            Vector3 movement = new Vector3(0f, 0.1f, 0);
        }
        
        if(!movingDown)
        {
            transform.Translate(Vector3.up * _monsterSpeed * Time.deltaTime);
            Vector3 movement = new Vector3(0f, 0.1f, 0);
        }

    }
    // DAMAGE MONSTER IF HIT BY A HEART BULLET
    private void MonsterDamage()
    {
        // UPDATE LIVES 
        if (_monsterLives >= 1)
        {
            _monsterLives--;
            Debug.Log("Damage -1 Lives monster: " + _monsterLives);
            _uiManager.UpdateMonsterLives(_monsterLives);

            // DEATH
            if (_monsterLives == 0)
            {   
                Destroy(this.gameObject);
                _uiManager.win();
                _fireSpawnManager.onPlayerWin();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // DESTROY BULLET + DAMAGE MONSTER if monster collides with bullet
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("monster collided with bullet");
            Destroy(other.gameObject);
            this.MonsterDamage();
        }

    }
  
}
