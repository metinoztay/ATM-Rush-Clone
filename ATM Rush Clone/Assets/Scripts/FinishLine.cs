using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float moveSpeedToATM;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            Destroy(other.GetComponent<Movement>());
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else if (other.CompareTag("Collected"))
        {
            Destroy(other.GetComponent<NodeMovement>());
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 2);
            other.AddComponent<FinishMovement>().movementSpeed = moveSpeedToATM;
        }
    }

}
