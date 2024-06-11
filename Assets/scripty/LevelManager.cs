using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("1LVL_1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("2LVL");
    }
    public void Level3()
    {
        SceneManager.LoadScene("3LVL_2");
    }

    public void BonusLVL()
    {
        SceneManager.LoadScene("Bonus_LVL");
    }
    public void BonusLVL2()
    {
        SceneManager.LoadScene("2bonusLvl");
    }
    public void BonusLVL3()
    {
        SceneManager.LoadScene("3bonusLvl");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Hlavni_menu");
    }
    


}
