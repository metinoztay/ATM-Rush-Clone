using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{
    [SerializeField] public Transform connectedNode;

    
    void Update()
    {
		try
		{
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * 20),
                transform.position.y,
                connectedNode.position.z + 0.66f);

        }
        catch (System.Exception)
		{
            //this area for break line code
            return;
			throw;
		}
        

    }
}
