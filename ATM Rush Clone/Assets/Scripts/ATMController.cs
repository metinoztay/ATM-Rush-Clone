using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMController : MonoBehaviour
{
    Text counter;
    public static int count = 0;

    void Start()
    {
        counter = GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            Destroy(other.gameObject);
            count++;
            counter.text = count.ToString();
            
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
