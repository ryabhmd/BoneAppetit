using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    private PlayerScript _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        // ADD LIFE if player collides with heart
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered if");
            _player.Heal(this.GameObject());
        }
    }
    
}
