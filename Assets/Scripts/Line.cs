using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line 
{
    public float slope;
    public float yintercept;

    public float r;

    public bool isVertical;
    public float x;

    public Line(float nslope, float nyintercept)
    {
        slope = nslope;
        yintercept = nyintercept;
        r = 1/Mathf.Tan(slope);
    }

    public Line(float nr, Vector2 Origin)
    {
        r = nr;
        slope = Mathf.Tan(r);

        yintercept = Origin.y-Origin.x*slope;
    }

    public Line(float newx)
    {
        x = newx;
        isVertical = true;
        r = Mathf.PI/2;
    }
}
