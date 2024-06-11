using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuManager : MonoBehaviour
{
    public void SelectLvl()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void exit()
    {
        Application.Quit();
    }
}
