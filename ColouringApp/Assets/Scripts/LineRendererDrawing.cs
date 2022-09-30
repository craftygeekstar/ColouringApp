using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererDrawing : MonoBehaviour
{
    List<Vector3> linePoints;
    GameObject newLine;
    LineRenderer drawLine;
    public Material lineMaterial;
    public float lineWidth;
    public GameObject tip;

    void Update()
    {
        Draw();
    }

    public void Draw()
    {
        newLine = new GameObject();
        drawLine = newLine.AddComponent<LineRenderer>();
        //Set the parameters for how the line will look.
        drawLine.material = new Material(Shader.Find("Sprites/Default"));
        drawLine.startColor = Color.yellow;
        drawLine.endColor = Color.white;
        drawLine.startWidth = lineWidth;
        drawLine.endWidth = lineWidth;

        drawLine.transform.position = tip.transform.position;

        drawLine.positionCount = linePoints.Count;
        drawLine.SetPositions(linePoints.ToArray());
    }

    
}
