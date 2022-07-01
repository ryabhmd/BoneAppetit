using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField] 
    private float _bulletSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // SHOOT HEART BULLET
        transform.Translate(Vector3.right * _bulletSpeed * Time.deltaTime);

        // DESTROY HEART BULLET
        if(transform.position.x > 20f)
        {
            Destroy(this.gameObject);
        }
    }
}
