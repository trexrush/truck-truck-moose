using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMidPath : MonoBehaviour
{
    private bool isLeft = true;
    public GameObject self;
    float timeup = 0;
    void Start()
    {
        if (transform.position.x < 0)
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }
    }
    void Update()
    {
        Vector3 pos = transform.position;

        pos.y -= .1f;

        if (isLeft == true)
        {
            pos.x += .15f;
        }
        if (isLeft == false)
        {
            pos.x -= .15f;
        }

        timeup += Time.deltaTime;
        if (timeup >= 4f)
        {
            Destroy(self);
        }
        transform.position = pos;
    }
}
