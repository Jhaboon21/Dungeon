using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject launchPlank;
    GameObject[] planks;
    Rigidbody[] plankBodies;
    public LayerMask layers;
    public AudioSource breakSound;

    public bool triggerOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        planks = GameObject.FindGameObjectsWithTag("bridge");


        plankBodies = new Rigidbody[planks.Length];
        for (int i = 0; i < planks.Length; i++)
        {
            plankBodies[i] = planks[i].GetComponent<Rigidbody>();
        }
    }

    void triggerCollapse()
    {
        for (int i = 0; i < plankBodies.Length; i++)
        {
            plankBodies[i].isKinematic = false;
            plankBodies[i].AddForce(0, 300, 0);

            Destroy(gameObject, 4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer) && triggerOnce)
        {
            triggerOnce = false;
            Debug.Log("Player broke bridge");
            triggerCollapse();
            breakSound.Play();
            launchPlank.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
        }
    }
}
