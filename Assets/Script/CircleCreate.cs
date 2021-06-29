using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCreate : MonoBehaviour
{
    public Material m; 
    public float r,x,y;
    private LineRenderer lineRenderer;
    public float w = 0.03f;
    // Start is called before the first frame update
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }
    void Update()
    {
        x = gameObject.GetComponent<Transform>().position.x;
        y = gameObject.GetComponent<Transform>().position.z;
        double theta_scale = 0.1;    //Set lower to add more points 
        int size = (int)((2.0 * Math.PI) / theta_scale)+1; //Total number of points in circle. 
        float cx,cy;
       
        lineRenderer.positionCount = size + 1;
        lineRenderer.startWidth = w;
        lineRenderer.endWidth = w;
        int i = 0;

        for (float theta = 0; theta < 2 * Math.PI+0.1; theta += 0.1f)
        {
            cx = (float)(r * Math.Cos(theta));
            cy = (float)(r * Math.Sin(theta));

            Vector3 pos = new Vector3(x+cx, 0.1f, y+cy);
            lineRenderer.SetPosition(i, pos);
            i += 1;
        }
    }

}
