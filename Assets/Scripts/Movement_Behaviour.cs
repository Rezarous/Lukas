﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Behaviour : MonoBehaviour
{


    float speed = 100f;
    public bool startMoving = false;
    public Vector3 destination;
    private int direction;


    void Start()
    {
        direction = transform.parent.parent.GetComponent<Sun_Behaviour>().direction;
    }


    void Update()
    {

        if (startMoving)
        {

            float distance = Vector3.Distance(transform.GetChild(0).position, destination);

            transform.RotateAround(transform.position, Vector3.forward, Time.deltaTime * speed * direction);

            if (distance < 0.3f)
            {
                startMoving = false;
                transform.GetChild(0).position = destination;
                Game_Master.MoveIsHappening = false;
            }

        }

    }

    public void MoveThisPlanet(Vector3 dest)
    {

        destination = dest;
        startMoving = true;

    }


}
