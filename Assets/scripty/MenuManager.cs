using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void back()
    {
        SceneManager.LoadScene("HlavniMenu");
    }
    public void exit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void LevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void LevelComplete()
    {
        SceneManager.LoadScene("LevelComplete");
    }
    public void WinnnerMenu()
    {
        SceneManager.LoadScene("Winner Menu");
    }
    public void DeadMenu()
    {
        SceneManager.LoadScene("DeadMenu");
    }

}
