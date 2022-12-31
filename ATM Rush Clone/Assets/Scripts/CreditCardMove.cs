using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class CreditCardMove : MonoBehaviour
{
    public float moveSpeed;
    bool goLeft = true;


    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<CrashController>().CrashScript(other);
    }
    void Update()
    {
        CardMove();
    }

    private void CardMove()
    {
        if (goLeft)
        {
            GoLeft();
        }
        else
        {
            GoRight();
        }

        if (transform.position.x < 236.5f)
        {
            goLeft = false;
        }
        else if (transform.position.x > 253.5f)
        {
            goLeft = true;
        }
    }

    private void GoLeft()
    {

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, transform.position.x - moveSpeed, Time.deltaTime),
            transform.position.y,
            transform.position.z);
    }

    private void GoRight()
    {
        transform.position = new Vector3(
               Mathf.Lerp(transform.position.x, transform.position.x + moveSpeed, Time.deltaTime),
               transform.position.y,
               transform.position.z);
    }
}
