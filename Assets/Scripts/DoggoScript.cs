using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoScript : MonoBehaviour
{
    private MaterialPropertyBlock _mpb;
    private float _colorChannel = 1f;
    
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
