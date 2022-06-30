using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // variables should be made private; [SerializeField] makes it accessible in Unity
    [SerializeField] private float _speed = 5f;

    // this will be used in the jumping function
    [SerializeField] private Rigidbody RB;

    [SerializeField] private float _jumpingSpeed = 10f;

    // -- for time delay when jumping --
    [SerializeField] private float _nextJumpTime = 0f;
    [SerializeField] private float _coolDownTime = 0.5f;

    // -- for the bullet
    [SerializeField] private GameObject _bulletPrefab;
    private float _fireCoolDownTime = 0f;
    private float _nextFireTime = 0.5f;

    [SerializeField] private DoggoScript _doggo;

    // -- for counting damage
    public GameObject[] healths;
    private int _lives;

    // -- for changing colors
    private float _colorChannel = 1f;
    private MaterialPropertyBlock _mpb;

    [SerializeField] private SpawnManager _spawnManager;

    [SerializeField] private UIManager _uiManager;

    private Scene currentScene;


    // Start is called before the first frame update -- only called once
    void Start()
    {
        // UPDATE LIVES
        _lives = healths.Length;
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

        // SPAWN HEART BULLET
        if (Input.GetKeyDown(KeyCode.E) && _nextFireTime < Time.time)
        {
            Instantiate(_bulletPrefab, transform.position + new Vector3(0.65f, 0f, 0f), Quaternion.identity);
            _nextFireTime = Time.time + _coolDownTime;
        }
    }


// a damage function to be used in EnemyScript when the enemy hits the player
    public void Damage()
    {
        // UPDATE LIVES 
        if (_lives >= 1)
        {
            _lives--;
            healths[_lives].SetActive(false);
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

        // MOVEMENT
        
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);

        // JUMPING

        if (Input.GetKeyDown("space") && _nextJumpTime < Time.time)
        {
            RB.velocity += new Vector3(0f, _jumpingSpeed, 0f);
            _nextJumpTime = Time.time + _coolDownTime;
        }

    }
    
    public void Heal(GameObject heart)
    {
        // UPDATE LIVES 
        if (_lives < 3f)
        {
            Destroy(heart);
            _lives++;
            healths[_lives - 1].SetActive(true);
            _uiManager.UpdateLives(_lives);
            // CHANGE MATERIAL 
            _doggo.colorChangeHeal();
        }
    }

}
