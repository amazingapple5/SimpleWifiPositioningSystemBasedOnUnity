using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllor : MonoBehaviour
{
    public bool flag = false;
    private Vector3 begin = new Vector3(0, 0, 0);
    void Update()
    {

        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (gameObject.transform.position.y >= 10)
            {
                gameObject.GetComponent<Transform>().position -= new Vector3(0, 1, 0);

            }
                
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0,1,0);

        }
        

        
        //move
        if (Input.GetMouseButtonDown(2))
        {
            begin = Input.mousePosition;
            flag = true;
        }
        if (Input.GetMouseButtonUp(2))
        {
            flag = false;
        }
        if (flag)
        {
            //Debug.Log("end:"+ Input.mousePosition+ "\tbegin" + begin);
            Vector3 newtran = (Input.mousePosition - begin).normalized/10;
            gameObject.GetComponent<Transform>().position -= new Vector3(newtran.x,0,newtran.y) ;
        }
    }
    
}
