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
            BreakApart(other);
            SetLastOne(other.GetComponent<NodeMovement>().connectedNode.gameObject);
            Destroy(other.gameObject);            
        }
    }

    private void SetLastOne(GameObject newLastOne)
    {
        GameObject[] collecteds = GameObject.FindGameObjectsWithTag("Collected");
        foreach (GameObject collected in collecteds)
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

    public void BreakApart(Collider other)
    {
        GameObject[] collecteds = GameObject.FindGameObjectsWithTag("Collected");
        foreach (GameObject collected in collecteds)
        {

            if (collected.transform.position.z > other.transform.position.z)
            {
                Destroy(collected.GetComponent<NodeMovement>());
                Destroy(collected.GetComponent<CollectController>());
                collected.GetComponent<BoxCollider>().isTrigger = true;
                collected.gameObject.tag = "Collectable";

                
                collected.transform.position = new Vector3(Random.Range(240.7f, 249.25f), -35.6681f, collected.transform.position.z + Random.Range(1.0f, 5.0f));

            }
        }
    }

}
