using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] Camera cam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, Mathf.Lerp(other.transform.position.z, other.transform.position.z - 30, Time.deltaTime * 10));
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, Mathf.Lerp(cam.transform.position.z, cam.transform.position.z - 30, Time.deltaTime * 6));
            other.GetComponent<CollectController>().lastMoney = other.gameObject;
        }
        else if (other.CompareTag("Collected"))
        {
            Destroy(other.gameObject);
            foreach (GameObject collected in GameObject.FindGameObjectsWithTag("Collected"))
            {

                collected.GetComponent<CollectController>().lastMoney = other.GetComponent<NodeMovement>().connectedNode.gameObject;

            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<CollectController>().lastMoney = other.GetComponent<NodeMovement>().connectedNode.gameObject;
        }
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.5f, 0));
    }
}
