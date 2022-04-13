using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ForceLine : MonoBehaviour
{
    public LineRenderer lineRen;

    private void Awake()
    {
        lineRen = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lineRen.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lineRen.SetPositions(points);
    }

    public void EndForceLine()
    {
        lineRen.positionCount = 0;
    }
}
