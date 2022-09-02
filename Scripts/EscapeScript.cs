using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeScript : MonoBehaviour
{
    public Boss chest;
    public GameObject escapeTrigger;

    bool hasBeenCalled = false;

    void Start()
    {
        escapeTrigger.SetActive(false);
    }

    void Update()
    {
        if (chest.treasureTaken && hasBeenCalled == false)
        {
            hasBeenCalled = true;
            escapeTrigger.SetActive(true);
        }
    }
}
