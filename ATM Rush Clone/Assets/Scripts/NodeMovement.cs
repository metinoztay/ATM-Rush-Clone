using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{
    public Transform connectedNode;
    
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * 20),transform.position.y,connectedNode.position.z + 0.5f);
    }
}
