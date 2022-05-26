using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // camera should follow player = target
    
    [SerializeField]
    private Transform target;
    
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // LATEUPDATE - is called at the end of the frame (after the normal Update)
    void LateUpdate()
    {
        // NULL CHECK  
        if(target != null)
        {
            // ADD OFFSET - to our position in order to depict the player properly
            Vector3 newPosition = target.transform.position + offset;
            transform.position = newPosition; 
        }
    }
}
