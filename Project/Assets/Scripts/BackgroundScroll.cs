using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= .1f; //speed of .0666f is when pressing down makes the speed match the bg
        if (pos.y <= -11.4f)
        {
            pos.y += 22.8f;
        }

        transform.position = pos;
    }
}
