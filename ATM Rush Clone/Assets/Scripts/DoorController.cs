using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Material GoldMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected") || other.CompareTag("Player"))
        {
            other.GetComponent<MeshRenderer>().material = GoldMaterial;
        }
    }
}
