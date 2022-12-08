using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            Destroy(other.gameObject);
            MoneyCounter.count += 1;
            
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
