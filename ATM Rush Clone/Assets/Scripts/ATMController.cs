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
            Destroy(other.gameObject);
            count++;
            
            
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        counter.text = count.ToString();
    }
}
