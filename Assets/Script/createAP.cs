using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAP : MonoBehaviour
{
    public GameObject AP;
    private GameObject ap;
    public Material m;
    private void Update()
    {
        if (ap != null)
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Plane")
                {
                    ap.GetComponent<Transform>().position = hit.point;//得到与地面碰撞点的坐标
                    
                }
                //Debug.Log(hit.transform.tag);
            }
            if (Input.GetMouseButtonDown(0))
            {

                Common.aps.Add(ap);
                ap = null;
            }
            if (Input.GetMouseButtonDown(1))
            {
                GameObject.Destroy(ap);
                ap = null;
            }
        }
        
        
    }
    public void CreateAP(WifiNode w)
    {

        if (Common.aps.Exists((GameObject g) => g.name == w.ssid + " " + w.dist))
        {
            GameObject a = Common.aps.Find((GameObject g) => g.name == w.ssid + " " + w.dist);
            Common.aps.Remove(a);
            GameObject.Destroy(a);
        }
        ap = Instantiate(AP, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        ap.name = w.ssid + " " + w.dist;
        ap.GetComponent<CircleCreate>().r = (float)w.dist;
        ap.AddComponent<APInfo>();
    }
    
}
