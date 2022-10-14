using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    /*
        This script controls the creation of the "constellations" by clicking the mouse and creating GameObjects with LineRenderer components.
        Const here is shorthand for Constellation rather than constant. 
    */

    public GameObject pauseMenu;
    public bool isPaused;

    List<Vector3> constPoints;
    GameObject newConst;
    LineRenderer drawConst;
    public Material constMaterial;
    public float lineWidth;
    
    void Start()
    {
        isPaused = true;
        constPoints = new List<Vector3>();
    }

    void Update()
    {
        if (isPaused)
        {
            // if paused, stop the creation of more constellations.
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //On left mouse click create new gameobject with LinerRender component to begin drawing a constellation.
            newConst = new GameObject();
            drawConst = newConst.AddComponent<LineRenderer>();
            //Set the parameters for how the line will look.
            drawConst.material = new Material(Shader.Find("Sprites/Default"));
            drawConst.startColor = Color.yellow;
            drawConst.endColor = Color.white;
            drawConst.startWidth = lineWidth;
            drawConst.endWidth = lineWidth;
        }

        if (Input.GetMouseButton(0))
        {
            //Continue to draw the constellation when the mouse button is down.
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), GetMousePosition(), Color.red);
            constPoints.Add(GetMousePosition());

            drawConst.positionCount = constPoints.Count;
            drawConst.SetPositions(constPoints.ToArray());
        }

        if (Input.GetMouseButtonUp(0))
        {
            //Finish the constellation and reset list for next click.
            constPoints.Clear();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Pause();
            pauseMenu.SetActive(true);
        }

    }
    
    Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction *10;
    }
    
    // Pause the game and allow free movement of the mouse.
    public void Pause()
    {
        Debug.Log("right mouse click");
        Cursor.lockState = CursorLockMode.None;
        isPaused = true; 
    }

    public void Resume()
    {
        isPaused = false;
    }


    
}
