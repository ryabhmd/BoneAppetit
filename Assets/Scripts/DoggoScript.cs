using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoScript : MonoBehaviour
{
    private MaterialPropertyBlock _mpb;
    private float _colorChannel = 1f;
    [SerializeField] private SpawnManager _spawnManager;
    
    void Start()
    {
        // INITIALISE - the material property block
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();
            this.GetComponent<Renderer>().GetPropertyBlock(_mpb);
        }
    }

    private void Update()
    {
        // BOUNDARIES (TELEPORT) - if doggo falls, go to game over mode
        if (transform.position.y < -10)
        {
            Debug.Log("fell down");
            // STOP SPAWNING
            if (_spawnManager != null)
            {
                _spawnManager.onPlayerDeath();
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

    // CHANGE RED VALUE - gradually each time the function is called
    public void colorChange()
    {
        _colorChannel -= 0.5f;
        _mpb.SetColor("_Color", new Color(_colorChannel,0f,0f, 1f));
        this.GetComponent<Renderer>().SetPropertyBlock(_mpb);
    }
    
    public void colorChangeHeal()
    {
        _colorChannel += 0.5f;
        _mpb.SetColor("_Color", new Color(_colorChannel,0f,0f, 1f));
        this.GetComponent<Renderer>().SetPropertyBlock(_mpb);
    }
}
