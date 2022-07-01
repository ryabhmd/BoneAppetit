using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CattoScript : MonoBehaviour
{
    [SerializeField] private float _cattospeed = 0.5f;
    private bool movingLeft;
    private float initial_position;
    private PlayerScript _player;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        initial_position = transform.position.x;
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        CattoMovement(initial_position);
    }

    private void CattoMovement(float initial_position)
    {
        if (transform.position.x <= initial_position - 3f)
        {
            movingLeft = false;
        }

        if (transform.position.x > initial_position)
        {
            movingLeft = true;
        }
        if (movingLeft)
        {
            transform.Translate(Vector3.back * _cattospeed * Time.deltaTime);
            Vector3 movement = new Vector3(0.1f, 0.0f, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 0);
        }
        
        if(!movingLeft)
        {
            transform.Translate(Vector3.forward * _cattospeed * Time.deltaTime);
            Vector3 movement = new Vector3(0.1f, 0.0f, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }

    }
    
    void OnCollisionEnter(Collision collision)
    {    
        // DAMAGE PLAYER if catto hits the player
        if (collision.gameObject.tag == "Player")

        {  
            _player.Damage();
        }
    }


} 
