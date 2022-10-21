using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class LineRendererThree : MonoBehaviour
{
    public InputActionReference colorReference = null;
    private MeshRenderer meshRenderer = null;

    LineRenderer line;
    public float lineWidth;
    public Material[] mats; 
    public GameObject penTip;

    private List<Transform> points = new List<Transform>();

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        //Make a new line and set it's position to the tip
        line = penTip.GetComponent<LineRenderer>();
        line.material = mats[0];
        
    }

    private void Update()
    {
        float value = colorReference.action.ReadValue<float>();
        UpdateColor(value);
        
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
        Vector3 tipPos = new Vector3(penTip.transform.position.x, penTip.transform.position.y, penTip.transform.position.z);
        line.positionCount++;
        line.SetPosition(line.positionCount - 1, tipPos);
    }
}
