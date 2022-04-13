using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Shoot : MonoBehaviour
{
    public Rigidbody2D rb;
    public float power = 10f;

    public Vector2 minPower;
    public Vector2 maxPower;

    ForceLine fl; // Drawn Line between Mouse Start Position and End.

    Camera cam; // Convert Drag mouse position to world position.
    Vector2 force; // Force applied between two points.

    Vector3 startPoint;
    Vector3 endPoint;

    private void Start()
    {
        cam = Camera.main;
        fl = GetComponent<ForceLine>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 - Left Click
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15; // <-- To avoid Elements Blocking this Object.

            /* Debug   Area */
            //Debug.Log(startPoint); // <- Mouse clicked Position in Scene From Centre.
            //Debug.Log("Mouse Button 0 (Left) Pressed");
        }

        if(Input.GetMouseButton(0)) // Mouse held
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            fl.RenderLine(startPoint, currentPoint);
        }


        if(Input.GetMouseButtonUp(0)) // Released
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15; // <-- To avoid Elements Blocking this Object.
            //Debug.Log(endPoint);



            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse); // Velocity to Object.

            fl.EndForceLine();
        }
    }
}
