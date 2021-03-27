using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMooseAI : MonoBehaviour
{
    int spawnpointnum;
    public Vector3 spawn1;
    public Vector3 spawn2;
    float eventtimer = 0f;
    public GameObject self;

    // Use this for initialization
    void Start()
    {
       spawnpointnum = Random.Range(1, 3);
        //left spawn coords
        spawn1.x = -2.5f;
        spawn1.y = 7f;
        spawn1.z = 0f;

        //right spawn coords
        spawn2.x = 2.5f;
        spawn2.y = 7f;
        spawn2.z = 0f;

        if (spawnpointnum == 1)
        {
            transform.position = spawn1;
        }
        if (spawnpointnum == 2)
        {
            transform.position = spawn2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        eventtimer += Time.deltaTime;
        pos.y -= .1f;
        if (eventtimer >= 4f)
        {
            Destroy(self);
        }

        transform.position = pos;
    }
}
