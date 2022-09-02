using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAlarm : MonoBehaviour
{
    public Boss chest;
    public PlayerMovement player;
    public GameObject hiddenPillar;
    public GameObject hiddenTraps;

    public GameObject deleteObj;
    public GameObject showObj;

    public AudioSource rumbling;
    public AudioSource explosion;

    public bool hasBeenCalled = false;

    void Start()
    {
        hiddenTraps.SetActive(false);
        hiddenPillar.SetActive(false);
    }
    void Update()
    {
        if(chest.treasureTaken && hasBeenCalled == false)
        {
            hiddenPillar.SetActive(true);
            hiddenTraps.SetActive(true);

            hasBeenCalled = true;
            deleteObj.SetActive(false);
            showObj.SetActive(true);

            player.startingSound.Stop();
            player.escapeSound.Play();
            rumbling.Play();
            explosion.Play();
        }    
    }
}
