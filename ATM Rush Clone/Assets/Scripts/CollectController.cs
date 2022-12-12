using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    public GameObject lastOne;
    public string material = "Money";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Collect(other);
        }
     
    }

    private void Collect(Collider other)
    {
        other.gameObject.transform.position = lastOne.transform.position + Vector3.forward;
        other.gameObject.AddComponent<NodeMovement>().connectedNode = lastOne.transform;
        other.gameObject.AddComponent<CollectController>().lastOne = other.gameObject;

        foreach (GameObject money in GameObject.FindGameObjectsWithTag("Collected"))
        {
            money.GetComponent<CollectController>().lastOne = other.gameObject;
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<CollectController>().lastOne = other.gameObject;

        other.gameObject.tag = "Collected";
        other.gameObject.GetComponent<BoxCollider>().isTrigger = false;

    }
}
