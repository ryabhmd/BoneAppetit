using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] 
    private float _fireSpeed = 5f;
    private PlayerScript _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT
        transform.Translate(Vector3.left * _fireSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        // DAMAGE PLAYER if fire hits player
        if (other.CompareTag("Player"))
        {
            Debug.Log("fire hit player");
            Destroy(this.gameObject);
            _player.Damage();
        }
    }
}
