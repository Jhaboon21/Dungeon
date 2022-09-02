using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public LayerMask layers;
    public MazeKey mKey;
    public AudioSource openDoorSound;

    void CheckForKey()
    {
        if (mKey.hasKey == true)
        {
            Debug.Log("Player has the key");
            openDoorSound.Play();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No Key");
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Player touched door");
                CheckForKey();
            }
        }
    }
}
