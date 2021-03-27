using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float normalSpeed = 4f;
    float speed; //speed of up and down
    float rspeed; //speed of right (modified by dash)
    float lspeed; //speed of left (modified by dash)
    int rightCount = 0; //number of times right pressed in .5 seconds
    float rightTime = 0.0f; //tracks time since last right press
    float dashtimeR = 0.0f; //time spent dashing right
    int leftCount = 0; //number of times left pressed in .5 seconds
    float leftTime = 0.0f; //tracks time since last right press
    float dashtimeL = 0.0f; //time spent dashing left
    public float dashMult = 2.5f; //how much faster dashing is compared to normal speed
    float lookForDash = .3f; //for how long the game looks for the second press

    public Animator anim;
    //-(10f / (-(Time.time + .5f))) + 20

    //for the future : add a cooldown for how many times you can dash, make all of the dash code a void method and add a conditional if to activate the code (like if (iscooldownL == true))

    public KeyCode right = KeyCode.RightArrow;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode down = KeyCode.DownArrow;
    public KeyCode up = KeyCode.UpArrow;

    public KeyCode right2 = KeyCode.D;
    public KeyCode left2 = KeyCode.A;
    public KeyCode down2 = KeyCode.S;
    public KeyCode up2 = KeyCode.W;

    void Start()
    {
        speed = rspeed = lspeed = normalSpeed;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(up) || Input.GetKey(up2))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(down) || Input.GetKey(down2))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(right) || Input.GetKey(right2))
        {
            pos.x += rspeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(right) || Input.GetKeyDown(right2))
        {
            rightCount++;
            transform.Rotate(0f, 0f, -20f);
            if (rspeed == dashMult * (normalSpeed))
            {
                anim.SetBool("RDashing", true);
            }
        }
        if (Input.GetKeyUp(right) || Input.GetKeyUp(right2))
        {
            transform.Rotate(0f, 0f, 20f);
            anim.SetBool("RDashing", false);
        }
        if (Input.GetKey(left) || Input.GetKey(left2))
        {
            pos.x -= lspeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(left) || Input.GetKeyDown(left2))
        {
            leftCount++;
            transform.Rotate(0f, 0f, 20f);
            if (lspeed == dashMult * (normalSpeed))
            {
                anim.SetBool("LDashing", true);
            }
        }
        if (Input.GetKeyUp(left) || Input.GetKeyUp(left2))
        {
            transform.Rotate(0f, 0f, -20f);
            anim.SetBool("LDashing", false);
        }


        // RIGHT DASH/STRAFE CODE

        //reset if no double tap
        if (rightTime > lookForDash)
        {
            rightCount = 0;
            rightTime = 0.0f;
        }

        // activates dash
        if (rightTime < lookForDash && rightCount > 1)
        {
            rspeed = dashMult * (normalSpeed);
            anim.SetBool("RDashing", true);
        }

        //dash timer + end
        if (rspeed == dashMult * (normalSpeed))
        {
            dashtimeR += Time.deltaTime;
            if(dashtimeR > 1f)
            {
                dashtimeR = 0f;
                rspeed = normalSpeed;
            }
        }

        //sets the timer for the doubletap
        if (rightTime < lookForDash && rightCount > 0)
        {
            rightTime += Time.deltaTime;
        }



        // LEFT DASH/STRAFE CODE

        //reset if no double tap
        if (leftTime > lookForDash)
        {
            leftCount = 0;
            leftTime = 0.0f;
        }

        // activates dash
        if (leftTime < lookForDash && leftCount > 1)
        {
            lspeed = dashMult * (normalSpeed);
            anim.SetBool("LDashing", true);
        }

        //dash timer + end
        if (lspeed == dashMult * (normalSpeed))
        {
            dashtimeL += Time.deltaTime;
            if (dashtimeL > 1f)
            {
                dashtimeL = 0f;
                lspeed = normalSpeed;
            }
        }

        //sets the timer for the doubletap
        if (leftTime < lookForDash && leftCount > 0)
        {
            leftTime += Time.deltaTime;
        }

        //bounding box
        if(pos.x < -9.3)
        {
            pos.x += lspeed * Time.deltaTime;
        }
        if(pos.x > 9.3)
        {
            pos.x -= rspeed * Time.deltaTime;
        }
        if (pos.y < -5.25)
        {
            pos.y += speed * Time.deltaTime;
        }
        if (pos.y > 5.25)
        {
            pos.y -= speed * Time.deltaTime;
        }


        transform.position = pos;
    }
}
