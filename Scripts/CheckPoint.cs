using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public LayerMask layers;
    public bool hasCheckpoint = false;

    private void OnTriggerEnter(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            Debug.Log("Player has touched Checkpoint!");
            hasCheckpoint = true;
        }
    }
}
