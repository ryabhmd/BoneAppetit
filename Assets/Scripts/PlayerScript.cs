using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // variables should be made private; [SerializeField] makes it accessible in Unity
    [SerializeField]
    private float _speed = 5f;
    
    // this will be used in the jumping function
    [SerializeField] 
    private Rigidbody RB;
    [SerializeField] 
    private float _jumpingSpeed = 10f;
    // -- for time delay when jumping --
    [SerializeField]
    private float _nextJumpTime = 0f;
    [SerializeField]
    private float _coolDownTime = 1f;
    
    // -- for the bullet
    [SerializeField] private GameObject _bulletPrefab;
    private float _fireCoolDownTime = 0f;
    private float _nextFireTime = 0.5f;
    
    [SerializeField] 
    private DoggoScript _doggo;

    // -- for counting damage
    private int _lives = 3;

    // -- for changing colors
    private float _colorChannel = 1f;
    private MaterialPropertyBlock _mpb;
    
    [SerializeField]
    private SpawnManager _spawnManager;
    
    [SerializeField]
    private UIManager _uiManager;

    // Start is called before the first frame update -- only called once
    void Start()
    {
        // UPDATE LIVES
        _uiManager.UpdateLives(_lives);
        
        // initiate first position
        transform.position = new Vector3(0f, 0f, 0f);
        
        // SET MATERIAL
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();
            this.GetComponent<Renderer>().GetPropertyBlock(_mpb);
        }
        
        // instantiate spawn manager GameObject
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
        // SPAWN BULLET
        if (Input.GetKeyDown(KeyCode.E) && _nextFireTime < Time.time)
        {
            Instantiate(_bulletPrefab, transform.position + new Vector3(0f, 0.65f, 0f), Quaternion.identity);
            _nextFireTime = Time.time + _coolDownTime;
        }
    }
    
    // a damage function to be used in EnemyScript when the enemy hits the player
    public void Damage()
    {
        // UPDATE LIVES 
        _lives--;
        _uiManager.UpdateLives(_lives);
        Debug.Log("Damage -1 Lives: " + _lives);

        // CHANGE MATERIAL 
        _doggo.colorChange();
        
        // DEATH
        if (_lives == 0)
        {
            // STOP SPAWNING
            if (_spawnManager != null)
            {
                _spawnManager.onPlayerDeath();
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogError("SpawnManager not assigned");
            }

            delItems();

        }

    }
    
    public void delItems()
    {
        // DELETE ENEMYS IN HIERACHY
        foreach (Transform child in _spawnManager.transform)
        {
            Destroy(child.gameObject);
        }  
    }

    void PlayerMovement()
    {
        // Lock the movement on the z-axis
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
        
        // MOVEMENT
        
        // This gets the horizontal input (defined in edit --> input manager in Unity); meaning left+right keys
        // if the user presses the right arrow --> the variable will have the value 1 --> we multuply it in the Translate funct below, which makes the object move to the right
        // if nothing is clicked --> value = 0 --> nothing changes
        // if left arrow is pressed --> value = -1 --> object moves to the left
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // deltaTime adjusts the speed to the game rate, makes it run smoother
        // multiplying by a number will make the player slower or faster (0,5 makes it slower)
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        
        // This code can be used while debugging, it will display an error message in Unity
        //if (Input.GetKeyDown("e"))
        //{
        //    Debug.LogError("e button was pressed");
        //}
        
        
        
        // JUMPING
        
        if (Input.GetKeyDown("space") && _nextJumpTime < Time.time)
        {
            RB.velocity += new Vector3(0f, _jumpingSpeed, 0f);
            _nextJumpTime = Time.time + _coolDownTime;
        }
        
        // BOUNDARIES (TELEPORT) - if a player falls, automatically teleport it to the starting position
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0f, 2f, 0f);
        }
    }
}
