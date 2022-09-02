using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public LayerMask layers;
    public bool ending = false;
    public GameObject playercam;
    public GameObject cam1;
    public GameObject hideText;
    public GameObject newText;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            if (Input.GetKey(KeyCode.E) && ending == false)
            {
                ending = true;
                // display the end.
                playercam.SetActive(false);
                cam1.SetActive(true);
                hideText.SetActive(false);
                newText.SetActive(true);
            }
        }
    }
}
