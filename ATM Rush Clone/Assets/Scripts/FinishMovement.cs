using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishMovement : MonoBehaviour
{
    [SerializeField] public float movementSpeed;
    void Update()
    {
        transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
    }
}
