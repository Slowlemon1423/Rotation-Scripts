using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class RotateOpen : MonoBehaviour
{
    [Header("Axes")]
    public bool x;
    public bool y;
    public bool z;
    [Header("Values")]
    public float Targetx;
    public float Targety;
    public float Targetz;
    public float Speed;
    float r;
    public bool error=false;
    public bool Open = false;
    //public bool MultiAxisRotation;
    public float oldTarg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!error)
        {
            if ((x ^ y ? z : x)/*&&!MultiAxisRotation*/)
                //If x and y same: (xor returns false) return x because
                //If x is 1, y is also 1, mutliple axis
                //If x is 0 then y is also 0 and z is one.
                //if x and y different:
                //one of them is 1 and one of them is 0.
                //if z is one, then multiple axis.
                //if z is 0 then perfectly normal.
            {
                error = true;
                Debug.Log("Multiple Axis Detected");
                return;
                
            }
            if (x)
            {
                float Angle_x = Mathf.SmoothDampAngle(transform.eulerAngles.x, Targetx, ref r, Speed);
                transform.rotation = Quaternion.Euler(Angle_x, Targety, Targetz);
            }
            if (y)
            {
                float Angle_y = Mathf.SmoothDampAngle(transform.eulerAngles.y, Targety, ref r, Speed);
                transform.rotation = Quaternion.Euler(Targetx, Angle_y, Targetz);
            }
            if (z)
            {
                float Angle_z = Mathf.SmoothDampAngle(transform.eulerAngles.z, Targetz, ref r, Speed);
                transform.rotation = Quaternion.Euler(Targetx, Targety, Angle_z);
            }
            if (!(x|y|z))
            {
                error = true;
                Debug.Log("Did not select an Axis");
                
            }
        }
    }
    public void smoothrotation(float newtarg)
    {
        if (newtarg == oldTarg)
        {
            Open = false;
        }
        else
        {
            Open = true;
        }
        if (x)
        {
            Targetx = newtarg;

        }
        else
        if (y)
        {
            Targety = newtarg;
        }
        else
        if (z)
        {
            Targetz = newtarg;
        }


    }
}
