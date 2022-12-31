using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float turnSpeed = 1.5f;
    bool start = false; 

    [SerializeField] GameObject gamePosition;


    void Update()
    {
        
        if (!start && Input.GetMouseButtonDown(0))
        {
            start = true;
            target.gameObject.GetComponentInParent<Movement>().movementSpeed = 7f;
        }
        else if (start)
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, gamePosition.transform.rotation, Time.deltaTime * turnSpeed);
            
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime*5f);
        }
    }

}
