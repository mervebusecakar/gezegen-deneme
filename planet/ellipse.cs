using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ellipse : MonoBehaviour
{
    private float xAngle, zAngle;
    public ellipse(float xAngle,float zAngle)
    {
        this.xAngle = xAngle;
        this.zAngle = zAngle;
    }

    public Vector2 Evaluate(double t)
    {
        float angle = Mathf.Rad2Deg * (float)t * 360f;
        float x = Mathf.Sin(angle) * xAngle;
        float z = Mathf.Cos(angle) * zAngle;
        return new Vector2(x, z);
    }
 }
