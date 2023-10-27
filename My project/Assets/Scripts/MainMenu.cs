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
        SceneManager.LoadSceneAsync("Level2_90BPM");
    }

    public void PlayLevelThree()
    {
        SceneManager.LoadSceneAsync("Level3_120BPM");
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("MenuScene");
    }
    public void EndScreen1()
    {
        SceneManager.LoadSceneAsync("EndScreen1");
    }
    public void EndScreen2()
    {
        SceneManager.LoadSceneAsync("EndScreen2");
    }
    public void EndScreen3()
    {
        SceneManager.LoadSceneAsync("EndScreen3");
    }
}