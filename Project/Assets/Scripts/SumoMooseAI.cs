using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoMooseAI : MonoBehaviour
{
    public Vector3 spawn;
    float eventtimer = 0f;
    public GameObject self;
    public GameObject player;
    float xDiff;
    float playerPosX;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        spawn.x = 0f;
        spawn.y = 7f;
        spawn.z = 0f;
        transform.position = spawn;
        player = GameObject.Find("Player");
        transform.Rotate(0, 0, 90f);
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        eventtimer += Time.deltaTime;
        playerPosX = player.transform.position.x;
        pos.y -= .1f;

        xDiff = playerPosX - pos.x;
        pos.x += xDiff/2 * Time.deltaTime;
        

        if (eventtimer >= 4f)
        {
            Destroy(self);
        }

        transform.position = pos;
    }
}
