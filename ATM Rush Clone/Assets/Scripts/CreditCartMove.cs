using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class CreditCartMove : MonoBehaviour
{
    [SerializeField] Camera cam;
    bool goLeft = true;
    //public float cameraThrow;
    //public float playerThrow;


    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    Crash(other);
        //}
        //else if(other.CompareTag("Collected"))
        //{
        //    DestroyObject(other);
        //}
    }
    void Update()
    {
        CreditCardMove();
    }

    //private void DestroyObject(Collider other)
    //{
    //    Destroy(other.gameObject);
    //    foreach (GameObject collected in GameObject.FindGameObjectsWithTag("Collected"))
    //    {

    //        collected.GetComponent<CollectController>().lastOne = other.GetComponent<NodeMovement>().connectedNode.gameObject;

    //    }
    //    GameObject.FindGameObjectWithTag("Player").GetComponent<CollectController>().lastOne = other.GetComponent<NodeMovement>().connectedNode.gameObject;
    //}

    //private void Crash(Collider other)
    //{
    //    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, Mathf.Lerp(other.transform.position.z, other.transform.position.z - 30, Time.deltaTime * playerThrow));
    //    cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, Mathf.Lerp(cam.transform.position.z, cam.transform.position.z - 30, Time.deltaTime * cameraThrow));
    //    other.GetComponent<CollectController>().lastOne = other.gameObject;

    //}

    private void CreditCardMove()
    {
        if (goLeft)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x - 5, Time.deltaTime), transform.position.y, transform.position.z);

        }
        else
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 5, Time.deltaTime), transform.position.y, transform.position.z);
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
