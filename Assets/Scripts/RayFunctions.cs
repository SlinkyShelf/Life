using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayFunctions
{
    public static int doesIntersect(Circle circle, Line line)
    {
        if (line.isVertical)
        {
            
            if (Mathf.Abs(circle.x-line.x) == circle.r)
            {
                return 1;
            } else if(Mathf.Abs(circle.x-line.x) < circle.r) {
                return 2;
            } else {
                return 0;
            }
            // return (circle.x-line.x) <= circle.r;
        } else {
            float f = line.yintercept-circle.y;

            //Quadratic
            float qa = (line.slope*line.slope)+1;
            float qb = 2*line.slope*f + -2*circle.x;
            float qc = (circle.x*circle.x) + (f*f) - (circle.r*circle.r);

            float discriminant = qb*qb - (4 * qa * qc);

            if (discriminant < 0)
            {
                return 0;
            } else {
                return 2;
            } 
        }
    }

    public static Vector2[] getIntersect(Circle circle, Line line)
    {
        if (line.isVertical)
        {
            return new Vector2[] {
                new Vector2(line.x, circle.y + Mathf.Sin(1/Mathf.Cos((line.x-circle.x)/circle.r)) * circle.r), 
                new Vector2(line.x, circle.y - Mathf.Sin(1/Mathf.Cos((line.x-circle.x)/circle.r)) * circle.r), 
            };
            
        } else {
            float f = line.yintercept-circle.y;

            //Quadratic
            float qa = (line.slope*line.slope)+1;
            float qb = 2*line.slope*f + -2*circle.x;
            float qc = (circle.x*circle.x) + (f*f) - (circle.r*circle.r);

            float temp = Mathf.Sqrt(qb*qb - (4 * qa * qc));

            float posx = (-qb + temp)/(2*qa);
            float negx = (-qb - temp)/(2*qa);

            return new Vector2[] {
                new Vector2(posx, posx*line.slope+line.yintercept), 
                new Vector2(negx, negx*line.slope+line.yintercept), 
            };
        }
    }

    public static bool intersectionValid(Line line, Vector2 Origin, Vector2 Intersection)
    {
        Vector2 Normalized = (Intersection-Origin).normalized;
        float iangle = Mathf.Atan2(Normalized.y, Normalized.x);
        return Mathf.Cos(Mathf.Abs(iangle-line.r)) > 0;
    }

    public static Vector2 closestIntersect(Vector2 Origin, Vector2 Intersection1, Vector2 Intersection2)
    {
        if ((Origin-Intersection1).magnitude < (Origin-Intersection2).magnitude)
            return Intersection1;
        else   
            return Intersection2;
    }

    public static int getValidIntersects(Circle circle, Line line, Vector2 Origin)
    {
        int IntersectionCount = doesIntersect(circle, line);

        if (IntersectionCount > 0)
        {
            Vector2[] Intersects = getIntersect(circle, line);

            if (!intersectionValid(line, Origin, Intersects[0]))
                IntersectionCount--;
            if (!intersectionValid(line, Origin, Intersects[1]))
                IntersectionCount--;
            return IntersectionCount;
        } else
            return 0;
    }

    public static Vector2 firstIntersect(Circle circle, Line line, Vector2 Origin)
    {
        Vector2[] Intersections = getIntersect(circle, line);

        bool i0Valid = intersectionValid(line, Origin, Intersections[0]);
        bool i1Valid = intersectionValid(line, Origin, Intersections[1]);

        if (i0Valid && i1Valid)
        {
            return closestIntersect(Origin, Intersections[0], Intersections[1]);
        } else if (i0Valid) {
            return Intersections[0];
        } else {
            return Intersections[1];
        }
    }

    public static void debugPoint(Vector2 point)
    {
        Debug.DrawLine(new Vector3(point.x, point.y, 0), new Vector3(point.x, point.y+.1f), Color.black);
    }
}
