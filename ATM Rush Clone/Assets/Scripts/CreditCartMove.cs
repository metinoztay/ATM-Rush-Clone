using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCartMove : MonoBehaviour
{
    [SerializeField] Camera cam;
    bool goLeft = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, Mathf.Lerp(other.transform.position.z, other.transform.position.z - 30, Time.deltaTime * 5));
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, Mathf.Lerp(cam.transform.position.z, cam.transform.position.z - 30, Time.deltaTime * 3));
            other.GetComponent<CollectController>().lastMoney = other.gameObject;
        }
        else if(other.CompareTag("Collected"))
        {
            Destroy(other.gameObject);
            foreach (GameObject collected in GameObject.FindGameObjectsWithTag("Collected"))
            {

                collected.GetComponent<CollectController>().lastMoney = other.GetComponent<NodeMovement>().connectedNode.gameObject;

            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<CollectController>().lastMoney = other.GetComponent<NodeMovement>().connectedNode.gameObject;
        }
    }
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
