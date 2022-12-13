using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float cameraThrow;
    [SerializeField] float playerThrow;
   
    public void CrashScript(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrashPlayer(other);
        }
        else if (other.CompareTag("Collected"))
        {
            SetLastOne(other.GetComponent<NodeMovement>().connectedNode.gameObject);
            Destroy(other.gameObject);
            
        }
    }

    private void SetLastOne(GameObject newLastOne)
    {        
        foreach (GameObject collected in GameObject.FindGameObjectsWithTag("Collected"))
        {

            collected.GetComponent<CollectController>().lastOne = newLastOne;

        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<CollectController>().lastOne = newLastOne;
    }

    private void CrashPlayer(Collider other)
    {
        other.transform.position = new Vector3(other.transform.position.x,
            other.transform.position.y, 
            Mathf.Lerp(other.transform.position.z, other.transform.position.z - 30, Time.deltaTime * playerThrow));
        cam.transform.position = new Vector3(cam.transform.position.x,
            cam.transform.position.y, 
            Mathf.Lerp(cam.transform.position.z, cam.transform.position.z - 30, Time.deltaTime * cameraThrow));
        other.GetComponent<CollectController>().lastOne = other.gameObject;

    }


}
