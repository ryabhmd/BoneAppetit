using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] private float _monsterSpeed = 6f;
    private bool movingDown;
    private PlayerScript _player;

    // -- for counting damage
    private int _monster_lives=6;
    public GameObject[] healths;


    
    // Start is called before the first frame update
    void Start()
    {
        movingDown = true;
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MonsterMovement();
    }

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
    // a damage function to be used  when the player hits the monster
    public void Damage()
    {
        // UPDATE LIVES 
        if (_monster_lives >= 1)
        {
            _monster_lives--;
            healths[_monster_lives].SetActive(false);
            Debug.Log("Damage -1 Lives monster: " + _monster_lives);




            // DEATH
            if (_monster_lives == 0)
            {   
                Destroy(this.gameObject);
            }
        
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // DESTROY monster + BULLET if monster collides(6 times) with bullet
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            this.Damage();

        }

        // DAMAGE PLAYER if monster hits player
        if (other.CompareTag("Player"))
        {
            
            Destroy(this.gameObject);
            _player.Damage();
        }
    }
  
}
