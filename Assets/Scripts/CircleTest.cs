using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTest : MonoBehaviour
{
    public GameObject target;
    private float rotation;

    public float rotSpeed = .5f * Mathf.PI*2;
    public float radius = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation += Time.deltaTime * rotSpeed;

        Circle targetHitbox = new Circle(target.transform.position.x, target.transform.position.y, radius);

        Vector2 Origin = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        Line ray = new Line(rotation, Origin);

        Color color = Color.red;

        if (RayFunctions.getValidIntersects(targetHitbox, ray, Origin) > 0)
        {
            
            RayFunctions.debugPoint(RayFunctions.firstIntersect(targetHitbox, ray, Origin));


        } 
        Debug.DrawRay(gameObject.transform.position, new Vector3(Mathf.Cos(rotation), Mathf.Sin(rotation), 0), color);
    }
}
