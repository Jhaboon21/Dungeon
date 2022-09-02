using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeTrigger : MonoBehaviour
{
    public LayerMask layers;
    public GameObject deleteObj;
    public GameObject showEnd;
    public GameObject boss;
    public GameObject endTriggerBox;
    public PlayerMovement player;
    public bool hasEscaped = false;

    private void Start()
    {
        endTriggerBox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            hasEscaped = true;
            Debug.Log("Player has escaped");
            Destroy(boss);
            deleteObj.SetActive(false);
            showEnd.SetActive(true);
            player.escapeSound.Stop();
            player.endSound.Play();
            endTriggerBox.SetActive(true);
        }
    }
}
