using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] Material goldMaterial;
    [SerializeField] Material diamondMaterial;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CollectController>().material == "Money")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = goldMaterial;
            other.gameObject.GetComponent<CollectController>().material = "Gold";
        }
        else if (other.gameObject.GetComponent<CollectController>().material == "Gold")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = diamondMaterial;
            other.gameObject.GetComponent<CollectController>().material = "Diamond";
        }
       
    }

}
