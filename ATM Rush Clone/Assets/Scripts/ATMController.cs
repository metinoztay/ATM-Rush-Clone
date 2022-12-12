using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ATMController : MonoBehaviour
{
    [SerializeField] TextMeshPro counter;
    private int count;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            Deposit(other);
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<CollectController>().lastOne = other.gameObject;
        }
    }

    private void Update()
    {
        counter.text = count.ToString();
    }

    private void ChangeLastOne(Collider other)
    {
        //Change last one for each collected moneys & first one
        foreach (GameObject collected in GameObject.FindGameObjectsWithTag("Collected"))
        {

            collected.GetComponent<CollectController>().lastOne = other.GetComponent<NodeMovement>().connectedNode.gameObject;

        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<CollectController>().lastOne = other.GetComponent<NodeMovement>().connectedNode.gameObject;
    }

    private void Deposit(Collider other)
    {
        //Deposit money,gold or diamond and count.
        ChangeLastOne(other);
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
