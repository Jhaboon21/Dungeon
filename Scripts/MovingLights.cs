using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLights : MonoBehaviour
{
    public Transform point;
    public Transform point2;
    public float speed = 1.0f;
    public Boss chest;

    void Update()
    {
        if (chest.treasureTaken)
            transform.position = Vector3.Lerp(point.position, point2.position, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
