using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishMovement : MonoBehaviour
{
    public Transform ATM;
    void Update()
    {
        transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, ATM.position.x, Time.deltaTime * 20),
                transform.position.y,
                transform.position.z);
    }
}
