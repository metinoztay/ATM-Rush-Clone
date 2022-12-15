using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float moveSpeedToATM;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.GetComponent<NodeMovement>());
        other.GetOrAddComponent<FinishMovement>().movementSpeed = moveSpeedToATM;
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
    }

}
