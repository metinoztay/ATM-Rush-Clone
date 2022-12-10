using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    float turnSpeed = 1.5f;
    bool start = false; 

    [SerializeField] GameObject gamePosition;
    


    void Update()
    {
        if (!start && Input.GetMouseButtonDown(0))
        {
            start = true;
            target.gameObject.GetComponent<Movement>().movementSpeed = 5f;
        }
        else if (start)
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, gamePosition.transform.rotation, Time.deltaTime * turnSpeed);
            
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime);
        }
        

    }
    
}
