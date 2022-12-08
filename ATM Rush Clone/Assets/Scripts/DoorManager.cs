using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] Material GoldMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            other.GetComponent<MeshRenderer>().material = GoldMaterial;
        }
    }
}
