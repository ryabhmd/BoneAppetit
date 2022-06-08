using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        // TRANSPORT BACK TO START
        if(transform.position.y < -4.5)
        {
            transform.position = new Vector3(Random.Range(-10f, 10f), 10f, 0f);
			
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // DESTROY ENEMY + BULLET if enemy collides with bullet
        if (other.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);

        }

        // DAMAGE PLAYER if enemy hits player
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            other.GetComponent<PlayerScript>().Damage();
            
        }
    }
}
