using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookUserInput : MonoBehaviour
{
    public bool RotateOnlyOnClickHold = true;
    private bool _freeLookActive;

    // Use this for initialization
    private void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }

    private void Update()
    {
        _freeLookActive = Input.GetMouseButton(1); // 0 = left mouse btn or 1 = right
        Cursor.visible = RotateOnlyOnClickHold && !_freeLookActive;
    }

    private float GetInputAxis(string axisName)
    {
        return !_freeLookActive&&RotateOnlyOnClickHold ? 0 : Input.GetAxis(axisName == "Mouse Y" ? "Mouse Y" : "Mouse X");
    }

    public void ToggleRotateOnly()
    {
        RotateOnlyOnClickHold = !RotateOnlyOnClickHold;
    }
}
