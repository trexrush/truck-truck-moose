using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static float highScore = 0;
    public Text finalScore;
    public Text boolHighscore;
    public AudioSource deathSound;
    //optimizations = merge Health.score with MooseSpawn.globalTimer since they serve the same purpose
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Highway");
    }

    void UpdateScore()
    {
        finalScore.text = ("Your score was = " + (Health.score * 1f).ToString("f2"));
        if (Health.score > highScore)
        {
            highScore = Health.score;
            boolHighscore.text = ("New Highscore!!");
        }
        else
        {
            boolHighscore.text = ("Better Luck Next Time");
        }
        Debug.Log(Health.score);
        Health.score = 0;
    }

    private void Start()
    {
        UpdateScore();
        MooseSpawn.globalTimer = 0;
        deathSound.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMainMenu();
        }
    }
}
