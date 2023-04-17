using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update

    public void menuToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void gameToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void menuToSetting()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void SettingToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    
}
