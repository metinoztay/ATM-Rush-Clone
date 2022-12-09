using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] Material goldMaterial;
    [SerializeField] Material diamondMaterial;

    public string material = "Money";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            if (material == "Money")
            {
                gameObject.GetComponent<MeshRenderer>().material = goldMaterial;
                material = "Gold";
            }
            else if (material == "Gold")
            {
                gameObject.GetComponent<MeshRenderer>().material = diamondMaterial;
                material = "Diamond";
            }
        }
        else if (other.CompareTag("Collectable"))
        {
            other.gameObject.GetComponent<ChangeMaterial>().goldMaterial = goldMaterial;
            other.gameObject.GetComponent<ChangeMaterial>().diamondMaterial = diamondMaterial;
        }
    }

}
