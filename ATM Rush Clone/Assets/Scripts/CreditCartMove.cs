using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCartMove : MonoBehaviour
{
    bool goLeft = true;

    void Update()
    {
        if (goLeft)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x - 8, Time.deltaTime), transform.position.y, transform.position.z);

        }
        else
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 8, Time.deltaTime), transform.position.y, transform.position.z);
        }

        if (transform.position.x < 245.5f)
        {
            goLeft = false;
        }
        else if (transform.position.x > 253.5f)
        {
            goLeft = true;
        }
        

    }
}
