using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevelOne()
    {
        SceneManager.LoadSceneAsync("Level1_60BPM");
    }

    public void PlayLevelTwo()
    {
        SceneManager.LoadSceneAsync("Level2_120BPM");
    }

    public void PlayLevelThree()
    {
        SceneManager.LoadSceneAsync("Level3_180BPM");
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("MenuScene");
    }
}