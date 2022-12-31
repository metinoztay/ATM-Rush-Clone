using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float moveSpeedToATM;
    [SerializeField] Camera cam;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            Destroy(other.GetComponent<Movement>());
            Destroy(cam.GetComponent<CameraController>());
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else if (other.CompareTag("Collected"))
        {
            Destroy(other.GetComponent<NodeMovement>());
            Destroy(other.GetComponent<CollectController>());
            other.transform.position = new Vector3(other.transform.position.x-Random.Range(1f,3f), other.transform.position.y, other.transform.position.z + Random.Range(0.5f,2.5f));
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
          }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            other.transform.Translate(new Vector3(-moveSpeedToATM * Time.deltaTime, 0, 0));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Deposit
        Destroy(other.gameObject);
        foreach (GameObject ATM in GameObject.FindGameObjectsWithTag("ATM"))
        {
            if (other.transform.GetChild(1).GetComponent<MeshRenderer>().enabled)
            {
                ATM.GetComponent<ATMController>().count += 2;
            }
            else if (other.transform.GetChild(2).GetComponent<MeshRenderer>().enabled)
            {
                ATM.GetComponent<ATMController>().count += 3;
            }
            else
            {
                ATM.GetComponent<ATMController>().count++;
            }

        }
    }

}
