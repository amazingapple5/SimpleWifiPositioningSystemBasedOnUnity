using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllor : MonoBehaviour
{
    public GameObject p;
    private void OnGUI()    // UI显示
    {
        if (GUI.Button(new Rect(Screen.width-150, 40, 100, 40), "刷新"))
        {
            Wifi.findWifi();
        }
        if (GUI.Button(new Rect(Screen.width - 150, 90, 100, 40), "重画"))
        {
            foreach (GameObject g in Common.aps)
            {
                GameObject.Destroy(g);
            }
            Common.aps.Clear();

        }
        if (GUI.Button(new Rect(Screen.width - 150, 140, 100, 40), "修改画布大小"))
        {
            foreach (GameObject g in Common.aps)
            {
                GameObject.Destroy(g);
            }
            Common.aps.Clear();
            Debug.Log("修改画布大小");
            p.SetActive(true);
        }
        if (GUI.Button(new Rect(Screen.width - 150, 190, 100, 40), "退出"))
        {
            Application.Quit();
        }
        GUI.Label(new Rect(Screen.width - 150, Screen.height - 50, 200, 40), "by lenzo ");


        for (int i = 0;i<Common.wifiNodes.Count;i++)
        {
            if (GUI.Button(new Rect(10 + 160 * ((45 * i) / 540), 40 + (45 * i) % 540, 150, 40), Common.wifiNodes[i].ssid + ":\n" + Common.wifiNodes[i].dist + "m"))
            {
                this.SendMessage("CreateAP", Common.wifiNodes[i]);
            }
        }
        
    }
}
