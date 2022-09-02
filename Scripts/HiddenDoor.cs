using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenDoor : MonoBehaviour
{
    public LayerMask layers;
    public CrystalBall redBall;
    public CrystalBall blueBall;
    public GameObject hiddenDoor;
    public GameObject hiddenWall;
    public GameObject redKey;
    public GameObject blueKey;

    public AudioSource openDoorSound;

    public bool soundPlayedOnce = true;

    void Start()
    {
        hiddenDoor.SetActive(false);
        hiddenWall.SetActive(true);
        redKey.SetActive(false);
        blueKey.SetActive(false);
    }

    void CheckForBalls()
    {
        if (redBall.hasBall == true)
        {
            redKey.SetActive(true);
        }
        if (blueBall.hasBall == true)
        {
            blueKey.SetActive(true);
        }
        if (redBall.hasBall == true && blueBall.hasBall == true)
        {
            Debug.Log("Player has all the balls");
            hiddenDoor.SetActive(true);
            hiddenWall.SetActive(false);
            PlaySoundOnce();
        }
        else
        {
            Debug.Log("Missing balls");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Player touched door");
                CheckForBalls();
            }
        }
    }

    void PlaySoundOnce()
    {
        if (soundPlayedOnce)
        {
            soundPlayedOnce = false;
            openDoorSound.Play();
        }
    }
}
