using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float horizontalSpeed;

    float horizontal;
    void Start()
    {
        
    }

    // 240.440 ve 249.440
    void Update()
    {
        if (transform.position.x > 240.440f && transform.position.x < 249.440f)
        {
            horizontal = Input.GetAxis("Horizontal");

            transform.Translate(new Vector3(horizontal * horizontalSpeed * Time.deltaTime, 0, movementSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(new Vector3(horizontal * -horizontalSpeed * Time.deltaTime, 0, movementSpeed * Time.deltaTime));
        }
    }
}
