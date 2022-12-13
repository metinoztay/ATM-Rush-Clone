using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class CreditCartMove : MonoBehaviour
{
    
    bool goLeft = true;


    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<CrashController>().CrashScript(other);
    }
    void Update()
    {
        CreditCardMove();
    }


    private void CreditCardMove()
    {
        if (goLeft)
        {
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, transform.position.x - 5, Time.deltaTime),
                transform.position.y,
                transform.position.z);

        }
        else
        {
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, transform.position.x + 5, Time.deltaTime),
                transform.position.y,
                transform.position.z);
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

}
