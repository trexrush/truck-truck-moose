using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMooseAI : MonoBehaviour
{
    int spawnpointnum;
    public Vector3 spawn1;
    public Vector3 spawn2;
    float eventtimer = 0f;
    float jumpmoment;
    public GameObject self;
    private int rot = 1;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        jumpmoment = Random.Range(3.5f, 7f);

        spawnpointnum = Random.Range(1, 3);
        //left spawn coords
        spawn1.x = -4f;
        spawn1.y = -7f;
        spawn1.z = 0f;

        //right spawn coords
        spawn2.x = 4f;
        spawn2.y = -7f;
        spawn2.z = 0f;

        if (spawnpointnum == 1)
        {
            transform.position = spawn1;
            transform.Rotate(0f, 0f, 90f);
        }
        if (spawnpointnum == 2)
        {
            transform.position = spawn2;
            transform.Rotate(0f, 0f, 90f);
        }
        anim.SetBool("Lunging", false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        eventtimer += Time.deltaTime;
        
        if ((eventtimer >= 0 && eventtimer < jumpmoment) )// || (eventtimer >= (jumpmoment+1)))
        {
            pos.y += .04f;
        }
        if (eventtimer >= jumpmoment )// && eventtimer < (jumpmoment+1))
        {
            if (spawnpointnum == 2)
            {
                pos.x -= .08f;
                pos.y -= .1f;
                while (rot == 1)
                {
                    transform.Rotate(0, 0, 90f);
                    rot = 0;
                }

            }
            if (spawnpointnum == 1)
            {
                pos.x += .08f;
                pos.y -= .1f;
                while (rot == 1)
                {
                    transform.Rotate(0, 0, -90f);
                    rot = 0;
                }
            }
            anim.SetBool("Lunging", true);
        }

        if (eventtimer >= 11f)
        {
            Destroy(self);
        }

        transform.position = pos;
    }
}
