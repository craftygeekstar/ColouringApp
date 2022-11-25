using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxChanger : MonoBehaviour
{
    public Material[] skyboxes;

    public void changeSky0()
    {
        RenderSettings.skybox = skyboxes[0];
    }

    public void changeSky1()
    {
        RenderSettings.skybox = skyboxes[1];
    }

    public void changeSky2()
    {
        RenderSettings.skybox = skyboxes[2];
    }
}
