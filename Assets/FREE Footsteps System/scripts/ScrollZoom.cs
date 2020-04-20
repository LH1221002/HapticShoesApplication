using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class ScrollZoom : MonoBehaviour
{
    private CinemachineFreeLook cam;
    void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
        cam.m_CommonLens = true;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            cam.m_Lens.FieldOfView++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            cam.m_Lens.FieldOfView--;
        }
    }
}
