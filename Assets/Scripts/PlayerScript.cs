using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float _jumpingSpeed = 10f;

    // -- for time delay when jumping --
    [SerializeField] private float _nextJumpTime = 0f;
    [SerializeField] private float _coolDownTime = 0.5f;
    
    [SerializeField] private DoggoScript _doggo;

    // -- for counting damage
    public GameObject[] healths;
    private int _lives;

    // -- for changing colors
    private float _colorChannel = 1f;
    private MaterialPropertyBlock _mpb;

    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private SpawnManagerFire _fireSpawnManager;
    [SerializeField] private UIManager _uiManager;
    private Scene currentScene;


    // Start is called before the first frame update -- only called once
    void Start()
    {
        // UPDATE LIVES
        _lives = healths.Length;
        _uiManager.UpdateLives(_lives);

        transform.position = new Vector3(0f, 0f, 0f);

        // SET MATERIAL
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();
            this.GetComponent<Renderer>().GetPropertyBlock(_mpb);
        }
        
        // GET REGULAR SPAWN MANAGER (STAGES 1-3) + FIRE SPAWN MANAGER (STAGE 4)
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _fireSpawnManager = GameObject.Find("SpawnManagerFire").GetComponent<SpawnManagerFire>();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    
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
        }

        // DEATH
        if (_lives == 0)
        {
            // STOP SPAWNING CHOCOLATE BARS
            if (_spawnManager != null)
            {
                _spawnManager.onPlayerDeath();
                Destroy(this.gameObject);
            }
            // STOP SPAWNING FIRE
            if (_fireSpawnManager != null)
            {
                _fireSpawnManager.onPlayerDeath();
                Destroy(this.gameObject);
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
