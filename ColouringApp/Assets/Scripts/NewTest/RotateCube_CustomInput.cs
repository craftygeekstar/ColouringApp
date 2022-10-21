using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class RotateCube_CustomInput : MonoBehaviour
{
    /*
        This script is attached to the cube gameobject in the LineRenderer scene.
        It controls the custom input action when the user presses the trigger button. The cube color value is changed from 0 to 1 (white to black),
        and the marker pen starts to draw using LineRenderer.

        PROBLEM: I am trying to 
    */

    public InputActionReference colorReference = null;
    private MeshRenderer meshRenderer = null; //meshrenderer of the cube

    //Line properties
    GameObject newLine;
    LineRenderer line;
    public float lineWidth;
    public Material[] mats; 
    public GameObject penTip;

    private List<Vector3> points = new List<Vector3>(); 

    //New
    private RaycastHit hit;
    private float tipHeight;

    [SerializeField]
    private Transform tip;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {        
        //When the trigger is pressed, value changes from 0 to 1. Update the color of the cube.
        float value = colorReference.action.ReadValue<float>();
        UpdateColor(value); 

        if (value == 0)
        {
            points.Clear();
            return;
        }

        // When the trigger is pressed, complete DrawLine() function
        int drawValue = colorReference.action.ReadValue<int>();
        DrawLine(drawValue);

    }

    private void UpdateColor(float value)
    {
        meshRenderer.material.color = new Color(value, value, value);
    }

    private void DrawLine(int drawValue)
    {
        /*
            HERE! In this function I want to instantiate a new Line when the trigger is pressed, at the Tip gameobject postion.
            Then, while the trigger button is being held, for the line to follow the tip position and draw a line.

            I am trying to convert PC mouse controls over to XR controller from PlayerControls script. This used OnMouseDown() functions. But I don't know the XR equivalent.
        */

        //Find where the marker pen tip is
        tipHeight = tip.transform.position.y;
        
        if (Physics.Raycast(tip.position, transform.up, out hit, tipHeight))
        {
            //Make a new line and set it's position to the tip
            newLine = new GameObject();
            line = newLine.AddComponent<LineRenderer>();
            // newLine.transform.position = hit.transform.position;
            
            // line.useWorldSpace = true;
            //line.material = mats[0];

            line.startWidth = lineWidth;
            line.endWidth = lineWidth;
            line.material = mats[drawValue];
            points.Add(penTip.transform.position);

            line.positionCount = points.Count;
            //this.points = points;

            line.SetPositions(points.ToArray()); //HERE! This doesn't work.
        }

        
       
        // Transform[] arrayPoints = points.ToArray();
    
        // for (int i = 0; i < arrayPoints.Length; i++)
        // {
        //     line.SetPositions(arrayPoints[i].position);
        // }

        // Vector3 tipPos = new Vector3(penTip.transform.position.x, penTip.transform.position.y, penTip.transform.position.z);
        // line.positionCount++;
        // line.SetPosition(line.positionCount - 1, tipPos);
    }


}
