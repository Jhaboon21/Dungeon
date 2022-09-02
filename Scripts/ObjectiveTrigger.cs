using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public bool playerEntered = false;
    public LayerMask layers;
    public GameObject deleteObj;
    public GameObject showObj;

    public void OnTriggerEnter(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            Debug.Log("Player sees objective: " + this);
            playerEntered = true;
            Destroy(gameObject);
            deleteObj.SetActive(false);
            showObj.SetActive(true);
        }
    }
}
