using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseSpawn : MonoBehaviour
{

    public GameObject moose;
    public GameObject moose2;
    public GameObject moose3;
    public GameObject moose4;
    public GameObject moose5;
    public float spawnEveryN;
    int mooseSelector;
    public float spawntimer = 0f;
    public static float globalTimer = 0f;
    float localTimer = 0f;
    // Update is called once per frame
    void Update()
    {
        globalTimer += Time.deltaTime;
        localTimer += Time.deltaTime;
        spawntimer += Time.deltaTime;
        if (spawntimer >= spawnEveryN)
        {
            mooseSelector = Random.Range(1, 6);
            if (mooseSelector == 1)
            {
                Debug.Log("moose 1 selected");
                Instantiate(moose, this.transform.position, this.transform.rotation);
                mooseSelector = 0;
            }
            if (mooseSelector == 2)
            {
                Debug.Log("moose 2 selected");
                Instantiate(moose2, this.transform.position, this.transform.rotation);
                mooseSelector = 0;
            }
            if (mooseSelector == 3)
            {
                Debug.Log("moose 3 selected");
                Instantiate(moose3, this.transform.position, this.transform.rotation);
                mooseSelector = 0;
            }
            if (mooseSelector == 4)
            {
                Debug.Log("moose 4 selected");
                Instantiate(moose4, this.transform.position, this.transform.rotation);
                mooseSelector = 0;
            }
            if (mooseSelector == 5)
            {
                Debug.Log("moose 5 selected");
                Instantiate(moose5, this.transform.position, this.transform.rotation);
                mooseSelector = 0;
            }
            if (mooseSelector == 6)
            {
                Debug.Log("boi you calculated this wrong");
                mooseSelector = 0;
            }
            spawntimer = 0f;
        }
        if (spawnEveryN >= 1.5f)
        {
            if (localTimer >= 15f)
            {
                spawnEveryN -= .5f;
                localTimer = 0f;
            }
        }
       
        
    }
}
