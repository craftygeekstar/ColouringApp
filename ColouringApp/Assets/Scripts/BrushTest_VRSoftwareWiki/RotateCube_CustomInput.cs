using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCube_CustomInput : MonoBehaviour
{
    public InputActionReference colorReference = null;
    private MeshRenderer meshRenderer = null;

    public bool isDrawing = false;
    List<Vector3> constPoints;
    GameObject newConst;
    LineRenderer drawConst;
    public Material constMaterial;
    public float lineWidth;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //Change colour of the cube if the trigger is pressed. When trigger pressed, value changes from 0 to 1.
        float value = colorReference.action.ReadValue<float>();
        UpdateColor(value);

        //now trying for drawing a line.
        float drawValue = colorReference.action.ReadValue<float>();
        DrawLine();
    }

    private void UpdateColor(float value)
    {
        meshRenderer.material.color = new Color(value, value, value);
    }

    private void DrawLine()
    {
        if (isDrawing)
        {
            //Continue to draw the constellation when the mouse button is down.
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), GetMousePosition(), Color.red);
            constPoints.Add(GetMousePosition());

            drawConst.positionCount = constPoints.Count;
            drawConst.SetPositions(constPoints.ToArray());
        }

        else
        {
            constPoints.Clear();
            newConst = new GameObject();
            drawConst = newConst.AddComponent<LineRenderer>();
            //Set the parameters for how the line will look.
            drawConst.material = new Material(Shader.Find("Sprites/Default"));
            drawConst.startColor = Color.yellow;
            drawConst.endColor = Color.white;
            drawConst.startWidth = lineWidth;
            drawConst.endWidth = lineWidth;
            
            isDrawing = true;
        }
    }

    Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction *10;
    }

}
