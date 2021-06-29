using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

public class FindPosition : MonoBehaviour
{
    private Matrix<double> X;
    private Matrix<double> Y;
    public GameObject me;
    // Update is called once per frame
    void Update()
    {

        if (Common.aps.Count >= 3)
        {
            int c = Common.aps.Count;
            GameObject g1 = Common.aps[c - 1];
            double xn = g1.transform.position.x;
            double yn = g1.transform.position.z;
            string[] temp = g1.name.Split(' ');
            double dn = double.Parse(temp[temp.Length - 1]);
            //Debug.Log(String.Format("xn:{0},yn:{1}", xn, yn));
            double[] arrayX = new double[2 * (c - 1)];
            double[] arrayY = new double[c - 1];
            for (int i = 0; i < c - 1; i++)
            {
                GameObject g = Common.aps[i];
                double x = g.transform.position.x;
                double y = g.transform.position.z;
                arrayX[2 * i] = xn - x;
                arrayX[2 * i + 1] = yn - y;
                //Debug.Log(String.Format("x:{0},y:{1}", g.transform.position.x, g.transform.position.z));

                temp = g.name.Split(' ');
                double d = double.Parse(temp[temp.Length - 1]);
                arrayY[i] = (d * d - dn * dn + xn * xn + yn * yn - x * x - y * y) / 2;
            }
            X = Matrix.Build.DenseOfRowMajor(c - 1, 2, arrayX);
            Matrix<double> XT = X.Transpose();
            Y = Matrix.Build.DenseOfRowMajor(c - 1, 1, arrayY);
            me.SetActive(true);
            double[,] myposition = ((X.Transpose() * X).Inverse() * X.Transpose() * Y).ToArray();
            me.transform.position = new Vector3((float)myposition[0, 0], 0, (float)myposition[1, 0]);

        }
        else
        {
            me.SetActive(false);
        }
        
        
    }
}
