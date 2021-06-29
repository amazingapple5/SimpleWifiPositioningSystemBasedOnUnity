using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWifi;
using System;
using System.Text;
public class Wifi : MonoBehaviour
{
    static string GetStringForSSID(Wlan.Dot11Ssid ssid)
    {
        return Encoding.UTF8.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
    }
    // Start is called before the first frame update

    void Start()
    {
        findWifi();
    }
    public static void findWifi()
    {
        Common.wifiNodes.Clear();
        WlanClient client = new WlanClient();

        foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
        {
            Wlan.WlanBssEntry[] bssworks = wlanIface.GetNetworkBssList();
            foreach (Wlan.WlanBssEntry bsswork in bssworks)
            {
                double dist = Math.Round( Math.Pow(10, ((27.55 - (20 * Math.Log10(bsswork.chCenterFrequency / 1000)) + Math.Abs(bsswork.rssi)) / 20)),2);
                //Debug.Log(wifiNode.ToString());
                if (!Common.wifiNodes.Exists((WifiNode w) => w.dist == dist && w.ssid == GetStringForSSID(bsswork.dot11Ssid)))
                {
                    WifiNode wifiNode = new WifiNode(dist, GetStringForSSID(bsswork.dot11Ssid));
                    Common.wifiNodes.Add(wifiNode);
                }

            }
        }
    }
}
