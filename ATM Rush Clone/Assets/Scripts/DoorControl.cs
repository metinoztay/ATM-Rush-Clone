using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled)
        {
            other.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
        }
        else if (other.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled)
        {
            other.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
