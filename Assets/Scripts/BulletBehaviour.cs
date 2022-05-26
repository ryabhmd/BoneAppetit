using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField] 
    private float _bulletSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // SHOOT BULLET (Vector3.up shoots it upwards)
        transform.Translate(Vector3.up * _bulletSpeed * Time.deltaTime);

        // DESTROY  the bullet GameObject if certain height is reached 
        if(transform.position.y > 10f)
        {
            Destroy(this.gameObject);
        }
    }
}
