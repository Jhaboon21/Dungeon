using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScroll : MonoBehaviour
{
    private float speed = 0.1f;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveThis = Time.time * speed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, moveThis));
    }
}
