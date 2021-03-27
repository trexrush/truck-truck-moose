using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MooseSound : MonoBehaviour
{

    public AudioSource m1;
    public AudioSource m2;
    public AudioSource m3;
    public AudioSource m4;
    public AudioSource m5;
    public AudioSource m6;

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;


    // Start is called before the first frame update
    void Start()
    {
        m1 = (AudioSource)gameObject.AddComponent(typeof (AudioSource));
        m2 = (AudioSource)gameObject.AddComponent(typeof (AudioSource));
        m3 = (AudioSource)gameObject.AddComponent(typeof (AudioSource));
        m4 = (AudioSource)gameObject.AddComponent(typeof (AudioSource));
        m5 = (AudioSource)gameObject.AddComponent(typeof (AudioSource));
        m6 = (AudioSource)gameObject.AddComponent(typeof(AudioSource));

        /*
        clip1 = GameObject.Find("cow") as AudioClip;
        clip1 = Resources.Load("Assets/Sounds/Moose/cow.wav") as AudioClip;
        clip2 = (AudioClip)Resources.Load("Assets/Sounds/Moose/horse.wav", typeof (AudioClip));
        clip3 = (AudioClip)Resources.Load("Assets/Sounds/Moose/trex.wav", typeof(AudioClip));
        clip4 = (AudioClip)Resources.Load("Assets/Sounds/Moose/trex2.wav", typeof(AudioClip));
        clip5 = (AudioClip)Resources.Load("Assets/Sounds/Moose/tiver.wav", typeof(AudioClip));
        */

        m1.clip = clip1;
        m2.clip = clip2;
        m3.clip = clip3;
        m4.clip = clip4;
        m5.clip = clip5;
        m6.clip = clip6;

        m1.loop = false;
        m2.loop = false;
        m3.loop = false;
        m4.loop = false;
        m5.loop = false;
        m6.loop = false;

        m1.playOnAwake = false;
        m2.playOnAwake = false;
        m3.playOnAwake = false;
        m4.playOnAwake = false;
        m5.playOnAwake = false;
        m6.playOnAwake = false;

        m1.volume = .5f;
        m2.volume = .5f;
        m3.volume = .5f;
        m4.volume = .5f;
        m5.volume = .5f;
        m6.volume = .5f;


    }

    // Update is called once per frame
    void Update()
    {
        float rand = Random.Range(0f, 100f);
        if (rand <= .25f)
        {
            int rand2 = (int)Random.Range(1, 7);
            switch(rand2)
            {
                case 1:
                    m1.Play();
                    break;
                case 2:
                    m2.Play();
                    break;
                case 3:
                    m3.Play();
                    break;
                case 4:
                    m4.Play();
                    break;
                case 5:
                    m5.Play();
                    break;
                case 6:
                    m6.Play();
                    break;
            }
        }
    }
}
