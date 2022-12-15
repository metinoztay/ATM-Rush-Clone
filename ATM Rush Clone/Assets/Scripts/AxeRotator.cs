using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AxeRotator : MonoBehaviour
{
    bool goRight = true;

   
    void Update()
    {
        
        if (goRight)
        {
            transform.Rotate(0, 0, 50*Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -50*Time.deltaTime);
        }

        if (transform.rotation.z*100 > 40)
        {
            
            goRight = false;
        }
        else if ( transform.rotation.z*100 < -40)
        {
            
            goRight = true;
        }
    }
}
