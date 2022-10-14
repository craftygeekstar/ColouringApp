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
        float value = colorReference.action.ReadValue<float>();
        UpdateColor(value);

        if (value == 0)
        {
            points.Clear();
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

            line.SetPositions(points.ToArray());
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
