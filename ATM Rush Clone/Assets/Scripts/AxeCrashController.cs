using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCrashController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Obstacles").GetComponent<CrashController>().CrashScript(other);
    }
}
