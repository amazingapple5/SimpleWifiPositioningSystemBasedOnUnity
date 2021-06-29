using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiNode
{
    public double dist;
    public string ssid;
    
    public WifiNode(double dist,string ssid)
    {
        this.dist = dist;
        this.ssid = ssid;
    }
    public override string ToString()
    {
        return "ssid:" + ssid + "\ndist" + dist;
    }
}
