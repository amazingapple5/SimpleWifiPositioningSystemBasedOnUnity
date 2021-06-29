using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeController : MonoBehaviour
{
    private new Camera camera;
    private float d = 0;
    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        d = camera.transform.position.y / 10;
        if (d > 1)
        {
            gameObject.transform.localScale = new Vector3(d * 0.2f, d * 0.2f, d * 0.2f);
        }

        
    }
    private void OnGUI()
    {
        //得到AP头顶在3D世界中的坐标
        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        //根据AP头顶的3D坐标换算成它在2D屏幕中的坐标
        Vector2 position = camera.WorldToScreenPoint(worldPosition);
        //得到真实AP头顶的2D坐标
        position = new Vector2(position.x, Screen.height - position.y);
        string[] temp = name.Split(' ');
        string newName = "你所在的位置";
        newName += String.Format("\n({0:F},{1:F})", transform.position.x, transform.position.z);
        //计算AP名称的宽高
        Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(newName));
        //设置显示颜色为黑色
        GUI.color = Color.black;
        //绘制NPC名称
        GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y / 2, nameSize.x, nameSize.y), newName);
    }
}
