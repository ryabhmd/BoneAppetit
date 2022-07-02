using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void onClickButton()
    {
        Debug.Log("Game Start!");
        SceneManager.LoadScene("Stage1");
    }
    
    public void onClickControlsButton()
    {
        SceneManager.LoadScene("Controls");
    }
    
    public void backToMainPage()
    {
        SceneManager.LoadScene("MainPage");
    }
    
    public void onClickExitButton()
    {
        Application.Quit();
    }
    
}
