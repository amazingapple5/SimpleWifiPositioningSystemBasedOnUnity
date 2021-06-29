using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APInfo : MonoBehaviour
{
    private new Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    private void OnGUI()
    {
        //得到AP头顶在3D世界中的坐标
        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        //根据AP头顶的3D坐标换算成它在2D屏幕中的坐标
        Vector2 position = camera.WorldToScreenPoint(worldPosition);
        //得到真实AP头顶的2D坐标
        position = new Vector2(position.x, Screen.height - position.y);
        string[] temp = name.Split(' ');
        string newName = "";
        for (int i = 0; i < temp.Length - 1; i++)
        {
            newName += temp[i];
        }
        newName += "\n"+ temp[temp.Length - 1]+"m";
        newName += String.Format("\n({0:F},{1:F})", transform.position.x, transform.position.z) ;
        //计算AP名称的宽高
        Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(newName));
        //设置显示颜色为黑色
        GUI.color = Color.black;
        //绘制AP名称
        GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y/2, nameSize.x, nameSize.y), newName);
    }
}
