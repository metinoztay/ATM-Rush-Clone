using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] Camera cam;
    public float cameraThrow;
    public float playerThrow;
    private void OnTriggerEnter(Collider other)
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
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.5f, 0));
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
}
