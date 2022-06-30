using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] private float _monsterSpeed = 6f;
    private bool movingDown;
    private PlayerScript _player;
    
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
}
