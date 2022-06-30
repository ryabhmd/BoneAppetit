using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CattoScript : MonoBehaviour
{
    [SerializeField] private float _cattospeed = 0.5f;
    private bool movingLeft;
    Animator anim;
    private float initial_position;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        initial_position = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CattoMovement(float initial_position)
    {
        if (movingLeft)
        {
            transform.Translate(Vector3.back * _cattospeed * Time.deltaTime);
            Vector3 movement = new Vector3(0.1f, 0.0f, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);

            if (transform.position.x <= initial_position - 1f) movingLeft = false;
        }
        else
        {
            transform.Translate(Vector3.forward * _cattospeed * Time.deltaTime);
            Vector3 movement = new Vector3(0.1f, 0.0f, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }

    }
}

