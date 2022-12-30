using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ATMController : MonoBehaviour
{
    [SerializeField] TextMeshPro counter;
    public int count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            Deposit(other);
            BreakApart(other);
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
    private void BreakApart(Collider other)
    {
        GameObject[] collecteds = GameObject.FindGameObjectsWithTag("Collected");
        foreach (GameObject collected in collecteds)
        {

            if (collected.transform.position.z > other.transform.position.z)
            {
                Destroy(collected.GetComponent<NodeMovement>());
                Destroy(collected.GetComponent<CollectController>());
                collected.GetComponent<BoxCollider>().isTrigger = true;
                collected.gameObject.tag = "Collectable";

                collected.transform.position = new Vector3(Random.Range(240.7f, 249.25f), -13.5f, collected.transform.position.z + Random.Range(1.0f, 5.0f));
            }
        }
    }
}
