using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRoomSound : MonoBehaviour
{
    public LayerMask layers;
    public AudioSource lavaSound;
    public bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer) && playerInside == false)
        {
            playerInside = true;
            lavaSound.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer) && playerInside == true)
        {
            playerInside = false;
            lavaSound.Stop();
        }
    }
}
