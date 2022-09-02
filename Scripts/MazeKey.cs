using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeKey : MonoBehaviour
{
    public bool hasKey = false;
    public LayerMask layers;
    public GameObject trapWallOne;
    public GameObject trapWallTwo;
    public AudioSource collectKeySound;
    public AudioSource mazeSound;

    private void Start()
    {
        trapWallOne.SetActive(false);
        trapWallTwo.SetActive(true);
    }

    public void OnTriggerStay(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Player Grabbed the Key");
                hasKey = true;
                collectKeySound.Play();
                mazeSound.Play();
                Destroy(gameObject);

                trapWallOne.SetActive(true);
                trapWallTwo.SetActive(false);
            }
        }
    }
}
