using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerMooseAI : MonoBehaviour
{
    int spawnpointnum;
    public Vector3 spawn1;
    public Vector3 spawn2;
    [HideInInspector]
    public float eventtimer = 0f;
    [HideInInspector]
    public float firemoment;
    public GameObject self;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;

    public Animator anim;

    public AudioSource poop;

    // Use this for initialization
    void Start()
    {
        firemoment = Random.Range(.5f, 1.5f);

        spawnpointnum = Random.Range(1, 3);
        //left spawn coords
        spawn1.x = -5f;
        spawn1.y = 7f;
        spawn1.z = 0f;

        //right spawn coords
        spawn2.x = 5f;
        spawn2.y = 7f;
        spawn2.z = 0f;

        if (spawnpointnum == 1)
        {
            transform.position = spawn1;
            transform.Rotate(0, 0, 180f);
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
        if ((eventtimer >= firemoment - .5f && eventtimer <= firemoment))
        {
            anim.SetBool("Shaking", true);
        }
        if ((eventtimer >= firemoment) & (eventtimer < firemoment + .01))
        {
            if (spawnpointnum == 2)
            {
                Instantiate(bullet1, this.transform.position, this.transform.rotation);
                Instantiate(bullet2, this.transform.position, this.transform.rotation);
                Instantiate(bullet3, this.transform.position, this.transform.rotation);
            }
            if (spawnpointnum == 1)
            {
                Instantiate(bullet1, this.transform.position, this.transform.rotation);
                Instantiate(bullet2, this.transform.position, this.transform.rotation);
                Instantiate(bullet3, this.transform.position, this.transform.rotation);
            }
            poop.Play();
            anim.SetBool("Shaking", false);
        }

        if (eventtimer >= 4f)
        {
            Destroy(self);
        }

        transform.position = pos;
    }
}
