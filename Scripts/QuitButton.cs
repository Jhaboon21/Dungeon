using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void ButtonInteract()
    {
        Debug.Log("Exit application");
        Application.Quit();
    }
}
