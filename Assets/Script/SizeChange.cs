using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeChange : MonoBehaviour
{
    public GameObject p;
    public InputField lInputField, wInputField;
    private float l, w;
    public GameObject plane;
    public void Cancel()
    {
        p.SetActive(false);
    }
    public void Sure()
    {
        l = float.Parse(lInputField.text);
        w = float.Parse(wInputField.text);
        p.SetActive(false);
        if(l>0 && w>0)
            plane.GetComponent<Transform>().localScale = new Vector3(l / 10, 1, w / 10);
    }
}
