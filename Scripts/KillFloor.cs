using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("You fell in Lava");
            other.transform.GetComponent<PlayerMovement>().RecieveDamage(100);
        }
    }
}
