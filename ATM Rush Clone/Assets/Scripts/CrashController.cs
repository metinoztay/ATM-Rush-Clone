using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float cameraThrow;
    [SerializeField] float playerThrow;

    float randX;
    float randZ;
    public void CrashScript(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Crash(other);
        }
        else if (other.CompareTag("Collected"))
        {
            DestroyObject(other);
        }
    }

    private void DestroyObject(Collider other)
    {
        Destroy(other.gameObject);
        foreach (GameObject collected in GameObject.FindGameObjectsWithTag("Collected"))
        {

            collected.GetComponent<CollectController>().lastOne = other.GetComponent<NodeMovement>().connectedNode.gameObject;

        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<CollectController>().lastOne = other.GetComponent<NodeMovement>().connectedNode.gameObject;
    }

    private void Crash(Collider other)
    {
        other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, Mathf.Lerp(other.transform.position.z, other.transform.position.z - 30, Time.deltaTime * playerThrow));
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, Mathf.Lerp(cam.transform.position.z, cam.transform.position.z - 30, Time.deltaTime * cameraThrow));
        other.GetComponent<CollectController>().lastOne = other.gameObject;

    }

    private void Throw(Collider other,GameObject gameObject)
    {
        randX = Random.Range(1f,5f);
        randZ = Random.Range(1f,5f);

        Destroy(other.GetComponent<NodeMovement>());
        other.GetComponent<BoxCollider>().enabled = true;
        
        gameObject.transform.position = new Vector3(other.transform.position.x + randX,0,other.transform.position.z+ randZ);
    }

    private void SetLastOne(Collider other)
    {

    }

}
