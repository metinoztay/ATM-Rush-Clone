using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{

    Text counter;
    public static int count = 0;
    void Start()
    {
        counter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = count.ToString();
    }
}
