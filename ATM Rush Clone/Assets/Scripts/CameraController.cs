using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float turnSpeed = 10f;
    bool camFront = false;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !camFront)
        {
            

            Vector3 direction = new Vector3(25, 0, 0) - new Vector3(-15,180,0);
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime*2);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().movementSpeed = 5;
            camFront = true;

        }

        
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 2);
    }
}
