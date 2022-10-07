using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class RotateCube_CustomInput : MonoBehaviour
{
    public InputActionReference colorReference = null;
    private MeshRenderer meshRenderer = null;

    
    GameObject newLine;
    LineRenderer line;
    public float lineWidth;
    public Material[] mats; 
    public GameObject penTip;

    private List<Transform> points = new List<Transform>();

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        //Make a new line and set it's position to the tip
        newLine = new GameObject();
        newLine.transform.position = penTip.transform.position;
        
        line = newLine.AddComponent<LineRenderer>();
        line.material = mats[0];
        
    }

    private void Update()
    {
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        
        float value = colorReference.action.ReadValue<float>();
        UpdateColor(value);

        if (value == 0)
        {
            points.Clear();
            //Destroy(arrayPoints);
            return;
        }
        
        int drawValue = colorReference.action.ReadValue<int>();
        DrawLine(drawValue);

    }

    private void UpdateColor(float value)
    {
        meshRenderer.material.color = new Color(value, value, value);
    }

    private void DrawLine(int drawValue)
    {
        line.material = mats[drawValue];
        points.Add(penTip.transform);

        line.positionCount = points.Count;
        this.points = points;

        Transform[] arrayPoints = points.ToArray();
    
        for (int i = 0; i < arrayPoints.Length; i++)
        {
            line.SetPositions(i, arrayPoints[i].position);
        }
    }


}
