using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Text highscore;

    public void PlayGame()
    {
        SceneManager.LoadScene("Highway");
    }

    public void Instruct()
    {
        SceneManager.LoadScene("Instructions");
    }

    private void Start()
    {
        highscore.text = ("Highscore = " + (EndScreen.highScore * 1f).ToString("f2"));
    }
}
