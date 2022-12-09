using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    public GameObject lastMoney;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {

            other.gameObject.transform.position = lastMoney.transform.position + Vector3.forward;
            other.gameObject.AddComponent<ChangeMaterial>();
            other.gameObject.AddComponent<NodeMovement>().connectedNode = lastMoney.transform;
            other.gameObject.AddComponent<CollectController>().lastMoney = other.gameObject;
            


            foreach (GameObject money in GameObject.FindGameObjectsWithTag("Collected"))
            {
                money.GetComponent<CollectController>().lastMoney = other.gameObject;
            }

            GameObject.FindGameObjectWithTag("Player").GetComponent<CollectController>().lastMoney = other.gameObject;

            other.gameObject.tag = "Collected";
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;

        }
     
    }
}
