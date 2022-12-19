using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorObstacleCrash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<CrashController>().CrashScript(other);
    }
}
