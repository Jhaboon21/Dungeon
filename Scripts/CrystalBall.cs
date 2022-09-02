using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBall : MonoBehaviour
{
    public bool hasBall = false;
    public LayerMask layers;
    public AudioSource collectSound;

    public void OnTriggerStay(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Player touched Crystal Ball");
                hasBall = true;
                collectSound.Play();
                Destroy(gameObject);
            }
        }
    }
}
