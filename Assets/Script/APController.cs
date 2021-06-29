using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APController : MonoBehaviour
{
    private new Camera camera;
    private float d = 0;
    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        d = camera.transform.position.y/10;
        if (d > 1)
        {
            gameObject.transform.localScale = new Vector3(d * 0.2f, d * 0.2f, d * 0.2f);
            gameObject.GetComponent<CircleCreate>().w = d * 0.03f;
        }
    }
}
