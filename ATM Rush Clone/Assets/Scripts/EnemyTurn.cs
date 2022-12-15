using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<CrashController>().CrashScript(other);
    }
    void Update()
    {
        transform.Rotate(0, turnSpeed*Time.deltaTime, 0);
    }
}
