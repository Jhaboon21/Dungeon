using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHint : MonoBehaviour
{
    public GameObject HintText;
    public LayerMask layers;

    private void OnTriggerEnter(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            Debug.Log("Player sees hint: " + this);
            HintText.SetActive(true);
        }
    }
}
