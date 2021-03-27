using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //Class used to keep health and score (in seconds)
    float damage;
    public bool dead = false;
    public float damageMax = 100f;
    public int dmgval;
    public Image damageBar;
    public Text damageText;
    public Text timeText;
    public static float score = 0f;
    public AudioSource ouch;
    public AudioSource roadOuch;


    void Start()
    {
        damage = damageMax;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            ouch.Play();
            damage -= 20f;
            UpdateBar();
        }
        if (collision.gameObject.tag == "Hazard")
        {
            roadOuch.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hazard")
        {
            damage -= (15 * Time.deltaTime);
            UpdateBar();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            roadOuch.Stop();
        }
    }

    void Update()
    {
        score += Time.deltaTime;
        timeText.text = (score * 1f).ToString("f2");
        dmgval = (int)damage;
        if (dmgval <= 0)
        {
            dead = true;
            GameOver();
        }
        
       
    }

    void UpdateBar()
    {
        float ratio = damage / damageMax;
        damageBar.rectTransform.localScale = new Vector3(1, ratio, 1);
        damageText.text = (ratio * 100).ToString("0");
    }

    private static void GameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
